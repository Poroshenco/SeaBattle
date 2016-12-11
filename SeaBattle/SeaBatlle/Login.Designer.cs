namespace SeaBatlle
{
    partial class Login
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
            this.label1 = new System.Windows.Forms.Label();
            this.Nickname = new System.Windows.Forms.TextBox();
            this.Lan = new System.Windows.Forms.Button();
            this.PVP = new System.Windows.Forms.Button();
            this.VsBot = new System.Windows.Forms.Button();
            this.Next = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label1.Location = new System.Drawing.Point(111, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter your nickname:";
            // 
            // Nickname
            // 
            this.Nickname.Location = new System.Drawing.Point(86, 87);
            this.Nickname.Name = "Nickname";
            this.Nickname.Size = new System.Drawing.Size(240, 20);
            this.Nickname.TabIndex = 1;
            // 
            // Lan
            // 
            this.Lan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Lan.Location = new System.Drawing.Point(86, 113);
            this.Lan.Name = "Lan";
            this.Lan.Size = new System.Drawing.Size(76, 25);
            this.Lan.TabIndex = 2;
            this.Lan.Text = "On LAN";
            this.Lan.UseVisualStyleBackColor = true;
            this.Lan.Click += new System.EventHandler(this.Lan_Click);
            // 
            // PVP
            // 
            this.PVP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.PVP.Location = new System.Drawing.Point(168, 113);
            this.PVP.Name = "PVP";
            this.PVP.Size = new System.Drawing.Size(76, 25);
            this.PVP.TabIndex = 3;
            this.PVP.Text = "PvP";
            this.PVP.UseVisualStyleBackColor = true;
            // 
            // VsBot
            // 
            this.VsBot.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.VsBot.Location = new System.Drawing.Point(250, 113);
            this.VsBot.Name = "VsBot";
            this.VsBot.Size = new System.Drawing.Size(76, 25);
            this.VsBot.TabIndex = 4;
            this.VsBot.Text = "PvE";
            this.VsBot.UseVisualStyleBackColor = true;
            // 
            // Next
            // 
            this.Next.Enabled = false;
            this.Next.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Next.Location = new System.Drawing.Point(116, 144);
            this.Next.Name = "Next";
            this.Next.Size = new System.Drawing.Size(191, 25);
            this.Next.TabIndex = 5;
            this.Next.Text = "Next";
            this.Next.UseVisualStyleBackColor = true;
            this.Next.Click += new System.EventHandler(this.Next_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 248);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "version 1.4.8.8";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(332, 87);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(47, 20);
            this.button1.TabIndex = 7;
            this.button1.Text = "RAND";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.RAND_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 261);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Next);
            this.Controls.Add(this.VsBot);
            this.Controls.Add(this.PVP);
            this.Controls.Add(this.Lan);
            this.Controls.Add(this.Nickname);
            this.Controls.Add(this.label1);
            this.Name = "Login";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Nickname;
        private System.Windows.Forms.Button Lan;
        private System.Windows.Forms.Button PVP;
        private System.Windows.Forms.Button VsBot;
        private System.Windows.Forms.Button Next;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
    }
}

