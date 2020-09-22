namespace Pong
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gameUpdateLoop = new System.Windows.Forms.Timer(this.components);
            this.startLabel = new System.Windows.Forms.Label();
            this.singlePlayerButton = new System.Windows.Forms.Button();
            this.multiplayerButton = new System.Windows.Forms.Button();
            this.megaplayerButton = new System.Windows.Forms.Button();
            this.inputBox = new System.Windows.Forms.TextBox();
            this.coverLabel = new System.Windows.Forms.Label();
            this.backingLabel = new System.Windows.Forms.Label();
            this.quitButton = new System.Windows.Forms.Button();
            this.modButton = new System.Windows.Forms.Button();
            this.ghostButton = new System.Windows.Forms.Button();
            this.confirmButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // gameUpdateLoop
            // 
            this.gameUpdateLoop.Interval = 16;
            this.gameUpdateLoop.Tick += new System.EventHandler(this.gameUpdateLoop_Tick);
            // 
            // startLabel
            // 
            this.startLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.startLabel.Font = new System.Drawing.Font("Courier New", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startLabel.ForeColor = System.Drawing.Color.Teal;
            this.startLabel.Location = new System.Drawing.Point(230, 124);
            this.startLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.startLabel.Name = "startLabel";
            this.startLabel.Size = new System.Drawing.Size(374, 130);
            this.startLabel.TabIndex = 0;
            this.startLabel.Text = "Press Space To Start";
            this.startLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // singlePlayerButton
            // 
            this.singlePlayerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.singlePlayerButton.Font = new System.Drawing.Font("Lucida Console", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.singlePlayerButton.ForeColor = System.Drawing.Color.Teal;
            this.singlePlayerButton.Location = new System.Drawing.Point(312, 257);
            this.singlePlayerButton.Name = "singlePlayerButton";
            this.singlePlayerButton.Size = new System.Drawing.Size(199, 43);
            this.singlePlayerButton.TabIndex = 1;
            this.singlePlayerButton.Text = "1 Player";
            this.singlePlayerButton.UseVisualStyleBackColor = true;
            this.singlePlayerButton.Click += new System.EventHandler(this.singlePlayerButton_Click);
            // 
            // multiplayerButton
            // 
            this.multiplayerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.multiplayerButton.Font = new System.Drawing.Font("Lucida Console", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.multiplayerButton.ForeColor = System.Drawing.Color.Teal;
            this.multiplayerButton.Location = new System.Drawing.Point(312, 306);
            this.multiplayerButton.Name = "multiplayerButton";
            this.multiplayerButton.Size = new System.Drawing.Size(199, 43);
            this.multiplayerButton.TabIndex = 2;
            this.multiplayerButton.Text = "2 Player";
            this.multiplayerButton.UseVisualStyleBackColor = true;
            this.multiplayerButton.Click += new System.EventHandler(this.multiplayerButton_Click);
            // 
            // megaplayerButton
            // 
            this.megaplayerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.megaplayerButton.Font = new System.Drawing.Font("Lucida Console", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.megaplayerButton.ForeColor = System.Drawing.Color.Teal;
            this.megaplayerButton.Location = new System.Drawing.Point(312, 355);
            this.megaplayerButton.Name = "megaplayerButton";
            this.megaplayerButton.Size = new System.Drawing.Size(199, 43);
            this.megaplayerButton.TabIndex = 3;
            this.megaplayerButton.Text = "4 Player";
            this.megaplayerButton.UseVisualStyleBackColor = true;
            this.megaplayerButton.Click += new System.EventHandler(this.megaplayerButton_Click);
            // 
            // inputBox
            // 
            this.inputBox.Location = new System.Drawing.Point(2, 0);
            this.inputBox.Name = "inputBox";
            this.inputBox.ShortcutsEnabled = false;
            this.inputBox.Size = new System.Drawing.Size(10, 22);
            this.inputBox.TabIndex = 99;
            this.inputBox.TabStop = false;
            this.inputBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            this.inputBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.inputBox_KeyUp);
            // 
            // coverLabel
            // 
            this.coverLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.coverLabel.Location = new System.Drawing.Point(-1, -9);
            this.coverLabel.Name = "coverLabel";
            this.coverLabel.Size = new System.Drawing.Size(23, 41);
            this.coverLabel.TabIndex = 5;
            this.coverLabel.Text = "label1";
            // 
            // backingLabel
            // 
            this.backingLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backingLabel.Location = new System.Drawing.Point(227, 145);
            this.backingLabel.Name = "backingLabel";
            this.backingLabel.Size = new System.Drawing.Size(377, 318);
            this.backingLabel.TabIndex = 6;
            this.backingLabel.Text = "label1";
            // 
            // quitButton
            // 
            this.quitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.quitButton.Font = new System.Drawing.Font("Lucida Console", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quitButton.ForeColor = System.Drawing.Color.Teal;
            this.quitButton.Location = new System.Drawing.Point(312, 453);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(199, 43);
            this.quitButton.TabIndex = 4;
            this.quitButton.Text = "Quit";
            this.quitButton.UseVisualStyleBackColor = true;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // modButton
            // 
            this.modButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.modButton.Font = new System.Drawing.Font("Lucida Console", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modButton.ForeColor = System.Drawing.Color.Teal;
            this.modButton.Location = new System.Drawing.Point(312, 404);
            this.modButton.Name = "modButton";
            this.modButton.Size = new System.Drawing.Size(199, 43);
            this.modButton.TabIndex = 4;
            this.modButton.Text = "Modifiers";
            this.modButton.UseVisualStyleBackColor = true;
            this.modButton.Click += new System.EventHandler(this.modButton_Click);
            // 
            // ghostButton
            // 
            this.ghostButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ghostButton.Font = new System.Drawing.Font("Lucida Console", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ghostButton.ForeColor = System.Drawing.Color.Teal;
            this.ghostButton.Location = new System.Drawing.Point(312, 257);
            this.ghostButton.Name = "ghostButton";
            this.ghostButton.Size = new System.Drawing.Size(199, 43);
            this.ghostButton.TabIndex = 101;
            this.ghostButton.Text = "Ghost";
            this.ghostButton.UseVisualStyleBackColor = true;
            this.ghostButton.Visible = false;
            this.ghostButton.Click += new System.EventHandler(this.ghostButton_Click);
            // 
            // confirmButton
            // 
            this.confirmButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.confirmButton.Font = new System.Drawing.Font("Lucida Console", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirmButton.ForeColor = System.Drawing.Color.Teal;
            this.confirmButton.Location = new System.Drawing.Point(312, 453);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(199, 43);
            this.confirmButton.TabIndex = 5;
            this.confirmButton.Text = "Confirm";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Visible = false;
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(821, 554);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.ghostButton);
            this.Controls.Add(this.modButton);
            this.Controls.Add(this.quitButton);
            this.Controls.Add(this.coverLabel);
            this.Controls.Add(this.inputBox);
            this.Controls.Add(this.megaplayerButton);
            this.Controls.Add(this.multiplayerButton);
            this.Controls.Add(this.singlePlayerButton);
            this.Controls.Add(this.startLabel);
            this.Controls.Add(this.backingLabel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pong";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer gameUpdateLoop;
        private System.Windows.Forms.Label startLabel;
        private System.Windows.Forms.Button singlePlayerButton;
        private System.Windows.Forms.Button multiplayerButton;
        private System.Windows.Forms.Button megaplayerButton;
        private System.Windows.Forms.TextBox inputBox;
        private System.Windows.Forms.Label coverLabel;
        private System.Windows.Forms.Label backingLabel;
        private System.Windows.Forms.Button quitButton;
        private System.Windows.Forms.Button modButton;
        private System.Windows.Forms.Button ghostButton;
        private System.Windows.Forms.Button confirmButton;
    }
}

