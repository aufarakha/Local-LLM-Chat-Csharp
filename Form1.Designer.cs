namespace Local_LLM_Chat
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }


        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            panelSidebar = new Panel();
            btnClearHistory = new Button();
            btnDeleteChat = new Button();
            lstChatHistory = new ListBox();
            btnNewChat = new Button();
            lblChatHistory = new Label();
            panelMain = new Panel();
            rtbOutput = new RichTextBox();
            panelInput = new Panel();
            tbInput = new TextBox();
            lblTyping = new Label();
            btnSend = new Button();
            btnStop = new Button();
            btnToggleSettings = new Button();
            grpModelSettings = new GroupBox();
            lblModel = new Label();
            cmbModel = new ComboBox();
            lblTemperature = new Label();
            nudTemperature = new NumericUpDown();
            lblTopP = new Label();
            nudTopP = new NumericUpDown();
            lblTopK = new Label();
            nudTopK = new NumericUpDown();
            lblMaxTokens = new Label();
            nudMaxTokens = new NumericUpDown();
            lblRepeatPenalty = new Label();
            nudRepeatPenalty = new NumericUpDown();
            panelSettings = new Panel();
            panelSidebar.SuspendLayout();
            panelMain.SuspendLayout();
            panelInput.SuspendLayout();
            grpModelSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudTemperature).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudTopP).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudTopK).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudMaxTokens).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudRepeatPenalty).BeginInit();
            panelSettings.SuspendLayout();
            SuspendLayout();
            // 
            // panelSidebar
            // 
            panelSidebar.BackColor = Color.FromArgb(45, 45, 48);
            panelSidebar.Controls.Add(btnClearHistory);
            panelSidebar.Controls.Add(btnDeleteChat);
            panelSidebar.Controls.Add(lstChatHistory);
            panelSidebar.Controls.Add(btnNewChat);
            panelSidebar.Controls.Add(lblChatHistory);
            panelSidebar.Dock = DockStyle.Left;
            panelSidebar.Location = new Point(0, 0);
            panelSidebar.Name = "panelSidebar";
            panelSidebar.Size = new Size(240, 640);
            panelSidebar.TabIndex = 3;
            // 
            // btnClearHistory
            // 
            btnClearHistory.BackColor = Color.FromArgb(108, 117, 125);
            btnClearHistory.FlatStyle = FlatStyle.Flat;
            btnClearHistory.ForeColor = Color.White;
            btnClearHistory.Location = new Point(128, 478);
            btnClearHistory.Name = "btnClearHistory";
            btnClearHistory.Size = new Size(100, 30);
            btnClearHistory.TabIndex = 0;
            btnClearHistory.Text = "Clear All";
            btnClearHistory.UseVisualStyleBackColor = false;
            // 
            // btnDeleteChat
            // 
            btnDeleteChat.BackColor = Color.FromArgb(220, 53, 69);
            btnDeleteChat.FlatStyle = FlatStyle.Flat;
            btnDeleteChat.ForeColor = Color.White;
            btnDeleteChat.Location = new Point(12, 478);
            btnDeleteChat.Name = "btnDeleteChat";
            btnDeleteChat.Size = new Size(100, 30);
            btnDeleteChat.TabIndex = 1;
            btnDeleteChat.Text = "Delete";
            btnDeleteChat.UseVisualStyleBackColor = false;
            // 
            // lstChatHistory
            // 
            lstChatHistory.BackColor = Color.FromArgb(37, 37, 38);
            lstChatHistory.BorderStyle = BorderStyle.None;
            lstChatHistory.ForeColor = Color.White;
            lstChatHistory.Location = new Point(12, 88);
            lstChatHistory.Name = "lstChatHistory";
            lstChatHistory.Size = new Size(216, 380);
            lstChatHistory.TabIndex = 2;
            // 
            // btnNewChat (ts ez)
            // 
            btnNewChat.BackColor = Color.FromArgb(0, 122, 255); //background color
            btnNewChat.FlatStyle = FlatStyle.Flat; //flatstyle so the outline get thin ;)
            btnNewChat.ForeColor = Color.White;
            btnNewChat.Location = new Point(12, 44);
            btnNewChat.Name = "btnNewChat";
            btnNewChat.Size = new Size(216, 34);
            btnNewChat.TabIndex = 3;
            btnNewChat.Text = "New Chat";
            btnNewChat.UseVisualStyleBackColor = false;
            // 
            // lblChatHistory
            // 
            lblChatHistory.AutoSize = true;
            lblChatHistory.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblChatHistory.ForeColor = Color.White;
            lblChatHistory.Location = new Point(12, 12);
            lblChatHistory.Name = "lblChatHistory";
            lblChatHistory.Size = new Size(64, 28);
            lblChatHistory.TabIndex = 4;
            lblChatHistory.Text = "Chats";
            // 
            // panelMain
            // 
            panelMain.BackColor = SystemColors.Control;
            panelMain.Controls.Add(rtbOutput);
            panelMain.Controls.Add(panelInput);
            panelMain.Controls.Add(btnToggleSettings);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(240, 0);
            panelMain.Name = "panelMain";
            panelMain.Padding = new Padding(12);
            panelMain.Size = new Size(400, 640);
            panelMain.TabIndex = 1;
            // 
            // rtbOutput
            // 
            rtbOutput.BackColor = Color.White;
            rtbOutput.BorderStyle = BorderStyle.None;
            rtbOutput.Dock = DockStyle.Fill;
            rtbOutput.Font = new Font("Consolas", 11.25F);
            rtbOutput.Location = new Point(12, 48);
            rtbOutput.Name = "rtbOutput";
            rtbOutput.ReadOnly = true;
            rtbOutput.Size = new Size(376, 484);
            rtbOutput.TabIndex = 0;
            rtbOutput.Text = "";
            // 
            // panelInput
            // 
            panelInput.BackColor = Color.FromArgb(245, 245, 245);
            panelInput.Controls.Add(tbInput);
            panelInput.Controls.Add(lblTyping);
            panelInput.Controls.Add(btnSend);
            panelInput.Controls.Add(btnStop);
            panelInput.Dock = DockStyle.Bottom;
            panelInput.Location = new Point(12, 532);
            panelInput.Name = "panelInput";
            panelInput.Padding = new Padding(12, 8, 12, 8);
            panelInput.Size = new Size(376, 96);
            panelInput.TabIndex = 1;
            // 
            // tbInput
            // 
            tbInput.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbInput.Location = new Point(12, 12);
            tbInput.Margin = new Padding(4);
            tbInput.Name = "tbInput";
            tbInput.Size = new Size(352, 27);
            tbInput.TabIndex = 0;
            tbInput.Text = "What are the names of the planets?";
            // 
            // lblTyping
            // 
            lblTyping.AutoSize = true;
            lblTyping.ForeColor = Color.Gray;
            lblTyping.Location = new Point(12, 46);
            lblTyping.Name = "lblTyping";
            lblTyping.Size = new Size(92, 20);
            lblTyping.TabIndex = 3;
            lblTyping.Text = "AI is typing...";
            lblTyping.Visible = false;
            // 
            // btnSend
            // 
            btnSend.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSend.BackColor = Color.FromArgb(0, 122, 255);
            btnSend.FlatStyle = FlatStyle.Flat;
            btnSend.ForeColor = Color.White;
            btnSend.Location = new Point(268, 52);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(96, 32);
            btnSend.TabIndex = 1;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = false;
            // 
            // btnStop
            // 
            btnStop.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnStop.BackColor = Color.FromArgb(220, 53, 69);
            btnStop.FlatStyle = FlatStyle.Flat;
            btnStop.ForeColor = Color.White;
            btnStop.Location = new Point(268, 52);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(96, 32);
            btnStop.TabIndex = 2;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = false;
            btnStop.Visible = false;
            // 
            // btnToggleSettings
            // 
            btnToggleSettings.BackColor = Color.FromArgb(51, 51, 51);
            btnToggleSettings.Dock = DockStyle.Top;
            btnToggleSettings.FlatStyle = FlatStyle.Flat;
            btnToggleSettings.ForeColor = Color.White;
            btnToggleSettings.Location = new Point(12, 12);
            btnToggleSettings.Name = "btnToggleSettings";
            btnToggleSettings.Size = new Size(376, 36);
            btnToggleSettings.TabIndex = 2;
            btnToggleSettings.Text = "Settings ⚙";
            btnToggleSettings.UseVisualStyleBackColor = false;
            // 
            // grpModelSettings
            // 
            grpModelSettings.Controls.Add(lblModel);
            grpModelSettings.Controls.Add(cmbModel);
            grpModelSettings.Controls.Add(lblTemperature);
            grpModelSettings.Controls.Add(nudTemperature);
            grpModelSettings.Controls.Add(lblTopP);
            grpModelSettings.Controls.Add(nudTopP);
            grpModelSettings.Controls.Add(lblTopK);
            grpModelSettings.Controls.Add(nudTopK);
            grpModelSettings.Controls.Add(lblMaxTokens);
            grpModelSettings.Controls.Add(nudMaxTokens);
            grpModelSettings.Controls.Add(lblRepeatPenalty);
            grpModelSettings.Controls.Add(nudRepeatPenalty);
            grpModelSettings.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            grpModelSettings.ForeColor = Color.White;
            grpModelSettings.Location = new Point(12, 12);
            grpModelSettings.Name = "grpModelSettings";
            grpModelSettings.Size = new Size(336, 254);
            grpModelSettings.TabIndex = 1;
            grpModelSettings.TabStop = false;
            grpModelSettings.Text = "Model & Sampling";
            // 
            // lblModel
            // 
            lblModel.AutoSize = true;
            lblModel.ForeColor = Color.LightGray;
            lblModel.Location = new Point(10, 26);
            lblModel.Name = "lblModel";
            lblModel.Size = new Size(57, 20);
            lblModel.TabIndex = 0;
            lblModel.Text = "Model:";
            // 
            // cmbModel
            // 
            cmbModel.BackColor = Color.FromArgb(51, 51, 51);
            cmbModel.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbModel.ForeColor = Color.White;
            cmbModel.Location = new Point(120, 22);
            cmbModel.Name = "cmbModel";
            cmbModel.Size = new Size(200, 28);
            cmbModel.TabIndex = 1;
            // 
            // lblTemperature
            // 
            lblTemperature.AutoSize = true;
            lblTemperature.ForeColor = Color.LightGray;
            lblTemperature.Location = new Point(10, 60);
            lblTemperature.Name = "lblTemperature";
            lblTemperature.Size = new Size(103, 20);
            lblTemperature.TabIndex = 2;
            lblTemperature.Text = "Temperature:";
            // 
            // nudTemperature
            // 
            nudTemperature.BackColor = Color.FromArgb(51, 51, 51);
            nudTemperature.DecimalPlaces = 2;
            nudTemperature.ForeColor = Color.White;
            nudTemperature.Increment = new decimal(new int[] { 5, 0, 0, 131072 });
            nudTemperature.Location = new Point(120, 58);
            nudTemperature.Maximum = new decimal(new int[] { 2, 0, 0, 0 });
            nudTemperature.Name = "nudTemperature";
            nudTemperature.Size = new Size(80, 27);
            nudTemperature.TabIndex = 3;
            nudTemperature.Value = new decimal(new int[] { 7, 0, 0, 65536 });
            // 
            // lblTopP
            // 
            lblTopP.AutoSize = true;
            lblTopP.ForeColor = Color.LightGray;
            lblTopP.Location = new Point(10, 94);
            lblTopP.Name = "lblTopP";
            lblTopP.Size = new Size(52, 20);
            lblTopP.TabIndex = 4;
            lblTopP.Text = "Top P:";
            // 
            // nudTopP
            // 
            nudTopP.BackColor = Color.FromArgb(51, 51, 51);
            nudTopP.DecimalPlaces = 2;
            nudTopP.ForeColor = Color.White;
            nudTopP.Increment = new decimal(new int[] { 5, 0, 0, 131072 });
            nudTopP.Location = new Point(120, 92);
            nudTopP.Maximum = new decimal(new int[] { 1, 0, 0, 0 });
            nudTopP.Name = "nudTopP";
            nudTopP.Size = new Size(80, 27);
            nudTopP.TabIndex = 5;
            nudTopP.Value = new decimal(new int[] { 9, 0, 0, 65536 });
            // 
            // lblTopK
            // 
            lblTopK.AutoSize = true;
            lblTopK.ForeColor = Color.LightGray;
            lblTopK.Location = new Point(10, 128);
            lblTopK.Name = "lblTopK";
            lblTopK.Size = new Size(53, 20);
            lblTopK.TabIndex = 6;
            lblTopK.Text = "Top K:";
            // 
            // nudTopK
            // 
            nudTopK.BackColor = Color.FromArgb(51, 51, 51);
            nudTopK.ForeColor = Color.White;
            nudTopK.Location = new Point(120, 126);
            nudTopK.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            nudTopK.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudTopK.Name = "nudTopK";
            nudTopK.Size = new Size(80, 27);
            nudTopK.TabIndex = 7;
            nudTopK.Value = new decimal(new int[] { 40, 0, 0, 0 });
            // 
            // lblMaxTokens
            // 
            lblMaxTokens.AutoSize = true;
            lblMaxTokens.ForeColor = Color.LightGray;
            lblMaxTokens.Location = new Point(10, 162);
            lblMaxTokens.Name = "lblMaxTokens";
            lblMaxTokens.Size = new Size(96, 20);
            lblMaxTokens.TabIndex = 8;
            lblMaxTokens.Text = "Max Tokens:";
            // 
            // nudMaxTokens
            // 
            nudMaxTokens.BackColor = Color.FromArgb(51, 51, 51);
            nudMaxTokens.ForeColor = Color.White;
            nudMaxTokens.Location = new Point(120, 160);
            nudMaxTokens.Maximum = new decimal(new int[] { 16384, 0, 0, 0 });
            nudMaxTokens.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudMaxTokens.Name = "nudMaxTokens";
            nudMaxTokens.Size = new Size(100, 27);
            nudMaxTokens.TabIndex = 9;
            nudMaxTokens.Value = new decimal(new int[] { 512, 0, 0, 0 });
            // 
            // lblRepeatPenalty
            // 
            lblRepeatPenalty.AutoSize = true;
            lblRepeatPenalty.ForeColor = Color.LightGray;
            lblRepeatPenalty.Location = new Point(10, 196);
            lblRepeatPenalty.Name = "lblRepeatPenalty";
            lblRepeatPenalty.Size = new Size(118, 20);
            lblRepeatPenalty.TabIndex = 10;
            lblRepeatPenalty.Text = "Repeat Penalty:";
            // 
            // nudRepeatPenalty
            // 
            nudRepeatPenalty.BackColor = Color.FromArgb(51, 51, 51);
            nudRepeatPenalty.DecimalPlaces = 2;
            nudRepeatPenalty.ForeColor = Color.White;
            nudRepeatPenalty.Increment = new decimal(new int[] { 5, 0, 0, 131072 });
            nudRepeatPenalty.Location = new Point(140, 194);
            nudRepeatPenalty.Maximum = new decimal(new int[] { 2, 0, 0, 0 });
            nudRepeatPenalty.Minimum = new decimal(new int[] { 5, 0, 0, 65536 });
            nudRepeatPenalty.Name = "nudRepeatPenalty";
            nudRepeatPenalty.Size = new Size(80, 27);
            nudRepeatPenalty.TabIndex = 11;
            nudRepeatPenalty.Value = new decimal(new int[] { 11, 0, 0, 65536 });
            // 
            // panelSettings
            // 
            panelSettings.AutoScroll = true;
            panelSettings.BackColor = Color.FromArgb(45, 45, 48);
            panelSettings.Controls.Add(grpModelSettings);
            panelSettings.Dock = DockStyle.Right;
            panelSettings.Location = new Point(640, 0);
            panelSettings.Name = "panelSettings";
            panelSettings.Padding = new Padding(12);
            panelSettings.Size = new Size(360, 640);
            panelSettings.TabIndex = 2;
            panelSettings.Visible = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 640);
            Controls.Add(panelMain);
            Controls.Add(panelSettings);
            Controls.Add(panelSidebar);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Local LLM Chat - LlamaSharp";
            panelSidebar.ResumeLayout(false);
            panelSidebar.PerformLayout();
            panelMain.ResumeLayout(false);
            panelInput.ResumeLayout(false);
            panelInput.PerformLayout();
            grpModelSettings.ResumeLayout(false);
            grpModelSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudTemperature).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudTopP).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudTopK).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudMaxTokens).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudRepeatPenalty).EndInit();
            panelSettings.ResumeLayout(false);
            ResumeLayout(false);
        }


        private Panel panelSidebar;
        private Panel panelMain;
        private Panel panelInput;

        private Label lblChatHistory;
        private Button btnNewChat;
        private ListBox lstChatHistory;
        private Button btnDeleteChat;
        private Button btnClearHistory;

        private RichTextBox rtbOutput;
        private TextBox tbInput;
        private Button btnSend;
        private Button btnStop;
        private Label lblTyping;
        private Button btnToggleSettings;


        private GroupBox grpModelSettings;
        private Label lblModel;
        private ComboBox cmbModel;
        private Label lblTemperature;
        private NumericUpDown nudTemperature;
        private Label lblTopP;
        private NumericUpDown nudTopP;
        private Label lblTopK;
        private NumericUpDown nudTopK;
        private Label lblMaxTokens;
        private NumericUpDown nudMaxTokens;
        private Label lblRepeatPenalty;
        private NumericUpDown nudRepeatPenalty;
        private Panel panelSettings;
    }

}
