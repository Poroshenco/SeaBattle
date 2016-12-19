namespace SeaBatlle
{
    partial class PvP_EnterNicknames
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
            this.FirstNickname = new System.Windows.Forms.TextBox();
            this.SecondNickname = new System.Windows.Forms.TextBox();
            this.Next = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "First player nickname: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(190, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Second player nickname: ";
            // 
            // FirstNickname
            // 
            this.FirstNickname.Location = new System.Drawing.Point(206, 11);
            this.FirstNickname.Name = "FirstNickname";
            this.FirstNickname.Size = new System.Drawing.Size(115, 20);
            this.FirstNickname.TabIndex = 2;
            // 
            // SecondNickname
            // 
            this.SecondNickname.Location = new System.Drawing.Point(206, 37);
            this.SecondNickname.Name = "SecondNickname";
            this.SecondNickname.Size = new System.Drawing.Size(115, 20);
            this.SecondNickname.TabIndex = 3;
            // 
            // Next
            // 
            this.Next.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Next.Location = new System.Drawing.Point(122, 72);
            this.Next.Name = "Next";
            this.Next.Size = new System.Drawing.Size(93, 27);
            this.Next.TabIndex = 4;
            this.Next.Text = "Next";
            this.Next.UseVisualStyleBackColor = true;
            this.Next.Click += new System.EventHandler(this.Next_Click);
            // 
            // PvP_EnterNicknames
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 109);
            this.Controls.Add(this.Next);
            this.Controls.Add(this.SecondNickname);
            this.Controls.Add(this.FirstNickname);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "PvP_EnterNicknames";
            this.Text = "PvP_EnterNicknames";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox FirstNickname;
        private System.Windows.Forms.TextBox SecondNickname;
        private System.Windows.Forms.Button Next;
    }
}