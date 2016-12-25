namespace SeaBatlle
{
    partial class OnLan_Login
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.PlayerNickname = new System.Windows.Forms.TextBox();
            this.ServerIp = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.RandomNickname = new System.Windows.Forms.Button();
            this.Next = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Your nickname:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(12, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Server IP:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(12, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Server port:";
            // 
            // PlayerNickname
            // 
            this.PlayerNickname.Location = new System.Drawing.Point(137, 12);
            this.PlayerNickname.Name = "PlayerNickname";
            this.PlayerNickname.Size = new System.Drawing.Size(79, 20);
            this.PlayerNickname.TabIndex = 3;
            // 
            // ServerIp
            // 
            this.ServerIp.Location = new System.Drawing.Point(137, 38);
            this.ServerIp.Name = "ServerIp";
            this.ServerIp.Size = new System.Drawing.Size(137, 20);
            this.ServerIp.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label4.Location = new System.Drawing.Point(134, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 18);
            this.label4.TabIndex = 6;
            this.label4.Text = "25565";
            // 
            // RandomNickname
            // 
            this.RandomNickname.Location = new System.Drawing.Point(223, 12);
            this.RandomNickname.Name = "RandomNickname";
            this.RandomNickname.Size = new System.Drawing.Size(51, 20);
            this.RandomNickname.TabIndex = 7;
            this.RandomNickname.Text = "random";
            this.RandomNickname.UseVisualStyleBackColor = true;
            this.RandomNickname.Click += new System.EventHandler(this.RandomNickname_Click);
            // 
            // Next
            // 
            this.Next.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Next.Location = new System.Drawing.Point(115, 90);
            this.Next.Name = "Next";
            this.Next.Size = new System.Drawing.Size(40, 24);
            this.Next.TabIndex = 8;
            this.Next.Text = "OK";
            this.Next.UseVisualStyleBackColor = true;
            this.Next.Click += new System.EventHandler(this.Next_Click);
            // 
            // OnLan_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 121);
            this.Controls.Add(this.Next);
            this.Controls.Add(this.RandomNickname);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ServerIp);
            this.Controls.Add(this.PlayerNickname);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "OnLan_Login";
            this.Text = "OnLan_Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox PlayerNickname;
        private System.Windows.Forms.TextBox ServerIp;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button RandomNickname;
        private System.Windows.Forms.Button Next;
    }
}