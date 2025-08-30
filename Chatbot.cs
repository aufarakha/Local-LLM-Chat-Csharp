using LLama;
using LLama.Common;
using LLama.Native;
using LLama.Sampling;
using System.Diagnostics;

/// <summary>
/// This class wraps a LLamaSharp chat session and exposes events 
/// to make it easier to engage in chat with a model while invoking 
/// events to update the GUI at various points along the way.
/// </summary>
namespace Local_LLM_Chat;
internal class ChatBot
{
    readonly LLama.ChatSession Session;
    readonly LLamaContext Context;
    readonly LLamaWeights Weights;

    public EventHandler<string> TextGenerated = delegate { };
    public EventHandler ResponseStarted = delegate { };
    public EventHandler ResponseEnded = delegate { };

    public ChatBot(string modelPath)
    {
        if (!File.Exists(modelPath))
            throw new FileNotFoundException($"Model file not found: {modelPath}");

        ModelParams modelParams = new(modelPath);
        Weights = LLamaWeights.LoadFromFile(modelParams);
        Context = Weights.CreateContext(modelParams);

        InteractiveExecutor executor = new(Context);
        Session = new LLama.ChatSession(executor);

        // Apply output transforms to hide unwanted prefixes
        var hideWords = new LLamaTransforms.KeywordTextOutputStreamTransform(["User:", "Bot: ", "Assistant:", "Human:"]);
        Session = Session.WithOutputTransform(hideWords);
    }

    public async Task AskAsync(string userInput, float temperature = 0.6f,
        float topP = 0.9f, int topK = 40, int maxTokens = 512,
        float repeatPenalty = 1.1f, CancellationToken cancellationToken = default)
    {
        Debug.WriteLine($"Chatbot Debug: Temp {temperature} TopP {topP} TopK {topK} Penalty {repeatPenalty} uinput {userInput}");
        ResponseStarted.Invoke(this, EventArgs.Empty);

        try
        {
            InferenceParams infParams = new()
            {
                SamplingPipeline = new DefaultSamplingPipeline
                {
                    Temperature = temperature,
                    TopP = topP,
                    TopK = topK,
                    RepeatPenalty = repeatPenalty
                },
                MaxTokens = maxTokens > 0 ? maxTokens : -1,
                AntiPrompts = ["User:", "Human:"]
            };

            Debug.WriteLine($"Chatbot Debug (Try Exec): Temp {temperature} TopP {topP} TopK {topK} Penalty {repeatPenalty} uinput {userInput}");

            // Create the user message
            ChatHistory.Message msg = new(AuthorRole.User, userInput);

            // Display answer text as it is being generated
            await foreach (string text in Session.ChatAsync(msg, infParams).WithCancellation(cancellationToken))
            {
                if (cancellationToken.IsCancellationRequested)
                    break;

                TextGenerated.Invoke(this, text);
            }
        }
        catch (OperationCanceledException)
        {
            // This is expected when cancellation is requested
            throw;
        }
        catch (Exception)
        {
            // Re-throw other exceptions
            throw;
        }
        finally
        {
            ResponseEnded.Invoke(this, EventArgs.Empty);
        }
    }

    public void ClearMemory()
    {
        // Clear the chat history in the session
        Session.History.Messages.Clear();
    }

    public void Dispose()
    {
        Context?.Dispose();
        Weights?.Dispose();
    }
}