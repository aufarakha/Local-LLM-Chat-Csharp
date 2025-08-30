using LLama;
using LLama.Common;
using Local_LLM_Chat;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Text;

namespace Local_LLM_Chat;

public partial class Form1 : Form
{
    private ChatBot? chatter; //initialize chatbot that were created by some sigmas
    private List<ChatConversation> chatSessions = new(); //conversation list
    private int currentChatIndex = -1; //current chat index set to -1 cuz yknow first index was 0
    private CancellationTokenSource? currentCancellation; //for stopping chat?
    private string currentModelPath = ""; //model pathhhh for yknow settings :))))))

    //boring ahh initialization
    public Form1()
    {
        InitializeComponent();
        InitializeForm();
    }

    //initialize form ._.
    private void InitializeForm()
    {
        try
        {
            string path = GetModelPath(); //OpenFileDialog and the get dialog result yknoww boring shi
            currentModelPath = path; //for settings yknowwww
            Text = $"Local LLM Chat - {Path.GetFileNameWithoutExtension(path)}";

            // Initialize ChatBot clazzz
            chatter = new(path); //set argument to model path
            //some kind of event handler (like empty void that can be filed i think 🤔)
            chatter.TextGenerated += Chatter_TextGenerated;
            chatter.ResponseStarted += Chatter_ResponseStarted;
            chatter.ResponseEnded += Chatter_ResponseEnded;

            // Initialize model selection
            InitializeModelSettings();

            // Wire up event handlers
            WireUpEvents();

            // Start with a new chat
            CreateNewChat();

            // Update UI
            UpdateSettingsToggleUI();
            UpdateChatButtons();
        }
        catch (Exception ex)
        {
            //showing error messages so you dont need to check up your debug console ;)
            MessageBox.Show($"Error initializing application: {ex.Message}", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            Application.Exit(); //i mean your app state is error, you want it to continue?
        }
    }

    private void LoadModel(string modelPath)
    {
        try
        {
            // Dispose previous model if exists
            chatter?.Dispose();

            // Create new ChatBot with the model (Repeat all same shi over again hoping it would work)
            chatter = new ChatBot(modelPath);
            chatter.TextGenerated += Chatter_TextGenerated;
            chatter.ResponseStarted += Chatter_ResponseStarted;
            chatter.ResponseEnded += Chatter_ResponseEnded;

            currentModelPath = modelPath;

            // Update UI
            Text = $"Local LLM Chat - {Path.GetFileNameWithoutExtension(modelPath)}";
            UpdateModelDisplay(); //updating combo box in settings yknow boring shi

            // Clear current chats since we're switching models
            chatSessions.Clear();
            currentChatIndex = -1;
            CreateNewChat();

            MessageBox.Show($"Model loaded successfully!\n{Path.GetFileName(modelPath)}",
                "Model Loaded", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading model: {ex.Message}", "Model Load Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            //this one doesnt need an exit because ts is not 90% of the apps
        }
    }

    private void InitializeModelSettings()
    {
        // Set default values for sampling parameters
        nudTemperature.Value = 0.7m;
        nudTopP.Value = 0.9m;
        nudTopK.Value = 40;
        nudMaxTokens.Value = 512;
        nudRepeatPenalty.Value = 1.1m;

        // Update model display
        UpdateModelDisplay();
    }

    private void WireUpEvents()
    {
        //im moving it to form1.cs not in design one so its manageable
        // Button events
        btnSend.Click += BtnSend_Click;
        btnStop.Click += BtnStop_Click;
        btnNewChat.Click += BtnNewChat_Click;
        btnDeleteChat.Click += BtnDeleteChat_Click;
        btnClearHistory.Click += BtnClearHistory_Click;
        btnToggleSettings.Click += BtnToggleSettings_Click;

        // Input events
        tbInput.KeyDown += TbInput_KeyDown;
        lstChatHistory.SelectedIndexChanged += LstChatHistory_SelectedIndexChanged;

        // Parameter validation events
        nudTemperature.ValueChanged += ValidateParameters;
        nudTopP.ValueChanged += ValidateParameters;
        nudTopK.ValueChanged += ValidateParameters;
        nudMaxTokens.ValueChanged += ValidateParameters;
        nudRepeatPenalty.ValueChanged += ValidateParameters;

        //Combo box AI paths
        cmbModel.SelectedIndexChanged += cmbModel_SelectedIndexChanged;

    }

    #region Chat Management

    private void CreateNewChat()
    {
        var newSession = new ChatConversation
        {
            Id = Guid.NewGuid(),
            Name = $"Chat {chatSessions.Count + 1}",
            Messages = new List<ChatMessage>(),
            CreatedAt = DateTime.Now
        };

        chatSessions.Add(newSession);
        currentChatIndex = chatSessions.Count - 1;

        RefreshChatHistory();
        lstChatHistory.SelectedIndex = currentChatIndex;
        //i just found out you dont need to do like textbox.Text = "" or textbox.Text = null
        rtbOutput.Clear();
        tbInput.Clear();
        tbInput.Focus();
    }

    private void RefreshChatHistory()
    {
        //ts called in 3 method btw (onCreate,onDelete chat,and Onclearchat)
        //kind of like freezing the listbox until end update were called
        lstChatHistory.BeginUpdate();

        //clearing old chat data/items
        lstChatHistory.Items.Clear();

        //adding new one
        foreach (var session in chatSessions)
        {
            //add items
            lstChatHistory.Items.Add($"{session.Name} ({session.CreatedAt:HH:mm})");
        }
        //annddd finally we are done now this thing will be renderedd
        lstChatHistory.EndUpdate();
    }

    private void LoadChatSession(int index)
    {
        //index < 0 = no chat index >= chatSessions.Count = something wrong and i aint accept that
        if (index < 0 || index >= chatSessions.Count) return;

        currentChatIndex = index;
        var session = chatSessions[index];

        rtbOutput.Clear();
        foreach (var message in session.Messages)
        {
            AppendMessageToOutput(message);
        }

        UpdateChatButtons();
    }

    private void UpdateModelDisplay()
    {
        if (!string.IsNullOrEmpty(currentModelPath))
        {
            string fileName = Path.GetFileName(currentModelPath);
            string directory = Path.GetDirectoryName(currentModelPath) ?? "";

            // Show filename and partial path if too long
            if (fileName.Length > 30)
            {
                fileName = fileName.Substring(0, 27) + "...";
            }

            cmbModel.Items.Clear();
            cmbModel.Items.Add($"📁 {fileName}");
            cmbModel.Items.Add("Load Different Model...");
            cmbModel.SelectedIndex = 0;
            cmbModel.SelectedItem = currentModelPath;
        }
    }

    private void AppendMessageToOutput(ChatMessage message)
    {
        rtbOutput.SelectionFont = new Font("Consolas", 11.25F, FontStyle.Bold);
        rtbOutput.SelectionColor = message.IsUser ? Color.Blue : Color.Green; //bool ? true : false
        rtbOutput.AppendText($"{(message.IsUser ? "You" : "AI")}: ");

        rtbOutput.SelectionFont = new Font("Consolas", 11.25F, FontStyle.Regular);
        rtbOutput.SelectionColor = Color.Black;
        rtbOutput.AppendText($"{message.Content}\n\n");

        rtbOutput.ScrollToCaret();
    }

    private void UpdateChatButtons()
    {
        bool hasChats = chatSessions.Count > 0;
        bool hasSelectedChat = currentChatIndex >= 0 && currentChatIndex < chatSessions.Count;

        btnDeleteChat.Enabled = hasSelectedChat;
        btnClearHistory.Enabled = hasChats;
    }

    private void ValidateParameters(object? sender, EventArgs e)
    {
        // Validate and constrain parameter values
        if (sender == nudTemperature)
        {
            if (nudTemperature.Value > 2.0m) nudTemperature.Value = 2.0m;
            if (nudTemperature.Value < 0.0m) nudTemperature.Value = 0.0m;
        }
        else if (sender == nudTopP)
        {
            if (nudTopP.Value > 1.0m) nudTopP.Value = 1.0m;
            if (nudTopP.Value < 0.0m) nudTopP.Value = 0.0m;
        }
        else if (sender == nudTopK)
        {
            if (nudTopK.Value > 1000) nudTopK.Value = 1000;
            if (nudTopK.Value < 1) nudTopK.Value = 1;
        }
        else if (sender == nudMaxTokens)
        {
            if (nudMaxTokens.Value > 16384) nudMaxTokens.Value = 16384;
            if (nudMaxTokens.Value < 1) nudMaxTokens.Value = 1;
        }
        else if (sender == nudRepeatPenalty)
        {
            if (nudRepeatPenalty.Value > 2.0m) nudRepeatPenalty.Value = 2.0m;
            if (nudRepeatPenalty.Value < 0.5m) nudRepeatPenalty.Value = 0.5m;
        }

        // Update tooltip with current values for reference
        //UpdateParameterTooltips();
    }

    /*private void UpdateParameterTooltips()
    {
        nudTemperature.ToolTipText = $"Temperature: {nudTemperature.Value} (0.0-2.0, higher = more creative)";
        nudTopP.ToolTipText = $"Top P: {nudTopP.Value} (0.0-1.0, nucleus sampling)";
        nudTopK.ToolTipText = $"Top K: {nudTopK.Value} (1-1000, top-k sampling)";
        nudMaxTokens.ToolTipText = $"Max Tokens: {nudMaxTokens.Value} (1-16384, response length limit)";
        nudRepeatPenalty.ToolTipText = $"Repeat Penalty: {nudRepeatPenalty.Value} (0.5-2.0, penalize repetition)";
    }*/

    private void ShowParameterInfo()
    {
        string info = "Parameter Guidelines:\n\n" +
                     "Temperature (0.0-2.0):\n" +
                     "• 0.1-0.3: Very focused, deterministic\n" +
                     "• 0.7-0.9: Balanced creativity\n" +
                     "• 1.0-2.0: Very creative, random\n\n" +
                     "Top P (0.0-1.0):\n" +
                     "• 0.9: Good balance\n" +
                     "• 0.1: Very focused\n" +
                     "• 1.0: No filtering\n\n" +
                     "Top K (1-1000):\n" +
                     "• 40: Good default\n" +
                     "• Lower = more focused\n" +
                     "• Higher = more diverse\n\n" +
                     "Max Tokens: Maximum response length\n" +
                     "Repeat Penalty: Higher values reduce repetition";

    }

    #endregion

    #region Event Handlers

    private async void BtnSend_Click(object? sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(tbInput.Text) || chatter == null) return;

        await SendMessage();
    }

    private async void TbInput_KeyDown(object? sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter && !e.Shift)
        {
            e.SuppressKeyPress = true;
            if (!string.IsNullOrWhiteSpace(tbInput.Text) && chatter != null)
            {
                await SendMessage();
            }
        }
    }

    private async Task SendMessage()
    {
        if (currentChatIndex == -1)
            CreateNewChat();

        string userMessage = tbInput.Text.Trim();
        tbInput.Clear();

        // Add user message to current session
        var currentSession = chatSessions[currentChatIndex];
        currentSession.Messages.Add(new ChatMessage { Content = userMessage, IsUser = true, Timestamp = DateTime.Now });

        // Display user message
        AppendMessageToOutput(new ChatMessage { Content = userMessage, IsUser = true });

        // Create cancellation token for this request
        currentCancellation = new CancellationTokenSource();

        try
        {
            // Prepare AI response message
            var aiMessage = new ChatMessage { Content = "", IsUser = false, Timestamp = DateTime.Now };
            currentSession.Messages.Add(aiMessage);

            // Start AI response
            rtbOutput.SelectionFont = new Font("Consolas", 11.25F, FontStyle.Bold);
            rtbOutput.SelectionColor = Color.Green;
            rtbOutput.AppendText("AI: ");
            rtbOutput.SelectionFont = new Font("Consolas", 11.25F, FontStyle.Regular);
            rtbOutput.SelectionColor = Color.Black;

            // Get inference parameters from UI
            var temperature = (float)nudTemperature.Value;
            var topP = (float)nudTopP.Value;
            var topK = (int)nudTopK.Value;
            var maxTokens = (int)nudMaxTokens.Value;
            var repeatPenalty = (float)nudRepeatPenalty.Value;

            Debug.WriteLine($"Form1 Debug: Temperature: {temperature} topP {topP} topK{topK} maxTokens {maxTokens} Penalty {repeatPenalty} Message {userMessage}");

            await chatter.AskAsync(userMessage, temperature, topP, topK, maxTokens, repeatPenalty, currentCancellation.Token);
        }
        catch (OperationCanceledException)
        {
            rtbOutput.AppendText("\n[Response cancelled]\n\n");
        }
        catch (Exception ex)
        {
            rtbOutput.AppendText($"\n[Error: {ex.Message}]\n\n");
        }
    }

    private void BtnStop_Click(object? sender, EventArgs e)
    {
        currentCancellation?.Cancel();
    }

    private void BtnNewChat_Click(object? sender, EventArgs e)
    {
        CreateNewChat();
    }

    private void BtnDeleteChat_Click(object? sender, EventArgs e)
    {
        if (currentChatIndex >= 0 && currentChatIndex < chatSessions.Count)
        {
            var result = MessageBox.Show("Are you sure you want to delete this chat?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                chatter?.ClearMemory();
                chatSessions.RemoveAt(currentChatIndex);

                if (chatSessions.Count == 0)
                {
                    CreateNewChat();
                }
                else
                {
                    currentChatIndex = Math.Min(currentChatIndex, chatSessions.Count - 1);
                    RefreshChatHistory();
                    lstChatHistory.SelectedIndex = currentChatIndex;
                    LoadChatSession(currentChatIndex);
                }

                UpdateChatButtons();
            }
        }
    }

    private void BtnClearHistory_Click(object? sender, EventArgs e)
    {
        if (chatSessions.Count > 0)
        {
            var result = MessageBox.Show("Are you sure you want to clear all chat history?",
                "Confirm Clear All", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                chatSessions.Clear();
                currentChatIndex = -1;
                RefreshChatHistory();
                rtbOutput.Clear();
                UpdateChatButtons();
                CreateNewChat();
            }
        }
    }

    private void BtnToggleSettings_Click(object? sender, EventArgs e)
    {
        panelSettings.Visible = !panelSettings.Visible;
        UpdateSettingsToggleUI();
    }

    private void BtnClearMemory_Click(object? sender, EventArgs e)
    {
        var result = MessageBox.Show("Are you sure you want to clear the model's memory?",
            "Confirm Clear Memory", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (result == DialogResult.Yes)
        {
            // Implementation depends on your memory system
            // You might need to reinitialize the ChatBot or clear its context
            MessageBox.Show("Memory cleared successfully!", "Memory Cleared",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    private void LstChatHistory_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (lstChatHistory.SelectedIndex >= 0 && lstChatHistory.SelectedIndex < chatSessions.Count)
        {
            LoadChatSession(lstChatHistory.SelectedIndex);
        }
    }

    #endregion

    #region ChatBot Event Handlers

    private void Chatter_TextGenerated(object? sender, string text)
    {
        if (InvokeRequired)
        {
            Invoke(new Action(() => Chatter_TextGenerated(sender, text)));
            return;
        }

        rtbOutput.AppendText(text);
        rtbOutput.ScrollToCaret();
        Application.DoEvents();

        // Add to current session
        if (currentChatIndex >= 0 && currentChatIndex < chatSessions.Count)
        {
            var currentSession = chatSessions[currentChatIndex];
            if (currentSession.Messages.Count > 0)
            {
                var lastMessage = currentSession.Messages.Last();
                if (!lastMessage.IsUser)
                {
                    lastMessage.Content += text;
                }
            }
        }
    }

    private void Chatter_ResponseStarted(object? sender, EventArgs e)
    {
        if (InvokeRequired)
        {
            Invoke(new Action(() => Chatter_ResponseStarted(sender, e)));
            return;
        }

        EnableInputs(false);
        lblTyping.Visible = true;
        btnStop.Visible = true;
        btnSend.Visible = false;
    }

    private void Chatter_ResponseEnded(object? sender, EventArgs e)
    {
        if (InvokeRequired)
        {
            Invoke(new Action(() => Chatter_ResponseEnded(sender, e)));
            return;
        }

        EnableInputs(true);
        lblTyping.Visible = false;
        btnStop.Visible = false;
        btnSend.Visible = true;
        rtbOutput.AppendText("\n\n");
        tbInput.Focus();
    }

    #endregion

    #region UI Helper Methods

    private void UpdateSettingsToggleUI()
    {
        if (panelSettings.Visible)
        {
            btnToggleSettings.Text = "Hide Settings ✖";
            btnToggleSettings.BackColor = Color.FromArgb(70, 70, 70);
        }
        else
        {
            btnToggleSettings.Text = "Settings ⚙";
            btnToggleSettings.BackColor = Color.FromArgb(51, 51, 51);
        }
    }

    public void EnableInputs(bool enabled)
    {
        btnSend.Enabled = enabled;
        tbInput.Enabled = enabled;

        // Enable/disable settings controls
        nudTemperature.Enabled = enabled;
        nudTopP.Enabled = enabled;
        nudTopK.Enabled = enabled;
        nudMaxTokens.Enabled = enabled;
        nudRepeatPenalty.Enabled = enabled;
        cmbModel.Enabled = enabled;

        // Chat management
        btnNewChat.Enabled = enabled;
        btnDeleteChat.Enabled = enabled && currentChatIndex >= 0;
        btnClearHistory.Enabled = enabled && chatSessions.Count > 0;
    }

    #endregion

    #region Static Methods

    public static string GetModelPath()
    {
        OpenFileDialog dialog = new()
        {
            Filter = "GGUF files (*.gguf)|*.gguf|All files (*.*)|*.*",
            Title = "Select a GGUF model",
        };

        DialogResult result = dialog.ShowDialog();
        return result == DialogResult.OK
            ? dialog.FileName
            : throw new FileNotFoundException("No model file selected");
    }

    #endregion


    private void cmbModel_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cmbModel.SelectedIndex == 1) // "Load Different Model..." option
        {
            try
            {
                string newModelPath = GetModelPath();
                if (!string.IsNullOrEmpty(newModelPath) && newModelPath != currentModelPath)
                {
                    LoadModel(newModelPath);
                }
                else
                {
                    // Revert selection if cancelled or same model
                    cmbModel.SelectedIndex = 0;
                }
            }
            catch (FileNotFoundException)
            {
                // User cancelled file dialog
                cmbModel.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error selecting model: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbModel.SelectedIndex = 0;
            }
        }
    }
}

// Supporting classes
public class ChatConversation
{
    public Guid Id { get; set; }
    public string Name { get; set; } = "";
    public List<ChatMessage> Messages { get; set; } = new();
    public DateTime CreatedAt { get; set; }
}

public class ChatMessage
{
    public string Content { get; set; } = "";
    public bool IsUser { get; set; }
    public DateTime Timestamp { get; set; }
}
