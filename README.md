# Local LLM Chat

A Windows Forms application for running **local large language models (LLMs)** using [LLamaSharp](https://github.com/SciSharp/LLamaSharp).
This tool allows you to load a **GGUF model file** and chat with it through a simple and interactive GUI.

## 📑 Table of Contents

* [Introduction](#-introduction)
* [Features](#-features)
* [Installation](#-installation)
* [Usage](#-usage)
* [Configuration](#-configuration)
* [Troubleshooting](#-troubleshooting)
* [Dependencies](#-dependencies)
* [Contributors](#-contributors)
* [License](#-license)

## 🚀 Introduction

**Local LLM Chat** provides a desktop interface to interact with LLMs locally, without relying on cloud APIs.
It wraps a `LLamaSharp.ChatSession` and streams model responses into the GUI in real-time.

The project is especially useful if you want:

* To run **offline AI assistants** on your own hardware.
* A **chat-style interface** with multiple sessions.
* Adjustable **sampling parameters** like temperature, top-k, top-p, max tokens, and repeat penalty.

## ✨ Features

* Load and run **GGUF models** locally via LLamaSharp.
* **Multiple chat sessions** with history management (create, delete, clear).
* **Real-time streaming output** as the AI generates responses.
* Adjustable **inference settings** directly from the GUI:

  * Temperature
  * Top-p (nucleus sampling)
  * Top-k (vocabulary filtering)
  * Max tokens (response length)
  * Repeat penalty
* **Dynamic model loading** (switch between different models).
* Simple **WinForms-based UI** with chat history and settings panel.

## ⚙️ Installation

### Prerequisites

* Windows (Visual Studio environment recommended).
* [.NET 8.0](https://dotnet.microsoft.com/download).
* A compatible **LLama GGUF model** file (e.g. LLaMA, Mistral, etc.).

### Steps

1. Clone this repository:

   ```bash
   git clone https://github.com/yourusername/Local-LLM-Chat.git
   cd Local-LLM-Chat
   ```
2. Open the solution in **Visual Studio** (`Local-LLM-Chat.sln`).
3. Restore NuGet dependencies (`LLamaSharp` etc.).
4. Build and run the project.


## 💡 Usage

1. Start the application.
2. Select a **GGUF model file** when prompted.
3. Type a message into the input box and press **Enter** or click **Send**.
4. Watch the AI response stream in real-time.
5. Manage chats via the **sidebar**:

   * Create new chat sessions.
   * Delete chats.
   * Clear all history.
6. Adjust **model parameters** in the settings panel to control creativity and response length.

## 🔧 Configuration

The following parameters can be tuned in the settings panel:

| Parameter          | Range     | Description                                                    |
| ------------------ | --------- | -------------------------------------------------------------- |
| **Temperature**    | 0.0 – 2.0 | Controls creativity/randomness (higher = more diverse).        |
| **Top P**          | 0.0 – 1.0 | Nucleus sampling; limits token pool by cumulative probability. |
| **Top K**          | 1 – 1000  | Restricts sampling to top-k most likely tokens.                |
| **Max Tokens**     | 1 – 16384 | Maximum length of generated response.                          |
| **Repeat Penalty** | 0.5 – 2.0 | Penalizes repeated phrases/tokens.                             |

## 🛠️ Troubleshooting

* **Model file not found**: Ensure you select a `.gguf` file when prompted.
* **App crashes on startup**: Check that your model file is valid and LLamaSharp supports it.
* **Performance issues**: Try a smaller model or adjust `Max Tokens`.
* **Memory errors**: Large models may exceed available VRAM/RAM. Switch to a quantized model.

---

## 📦 Dependencies

* [.NET 8.0+](https://dotnet.microsoft.com/)
* [LLamaSharp](https://github.com/SciSharp/LLamaSharp)
* Windows Forms (WinForms)

## Credits

* The `ChatBot.cs` class is adapted from [swharden/Local-LLM-csharp](https://github.com/swharden/Local-LLM-csharp/tree/main).

## 📜 License

This project is licensed under the **MIT License**.
See [LICENSE](LICENSE) for details.

---

Would you like me to also include **screenshots** (UI from `Form1.Designer.cs`) in the README, so users can see the chat interface before running it?
