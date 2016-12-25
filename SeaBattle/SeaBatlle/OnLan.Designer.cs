namespace SeaBatlle
{
    partial class OnLan
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
            this.MyFieldImage = new System.Windows.Forms.PictureBox();
            this.OponentFieldImage = new System.Windows.Forms.PictureBox();
            this.MyNickname = new System.Windows.Forms.Label();
            this.OponentNickname = new System.Windows.Forms.Label();
            this.Walketh = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.MyFieldImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OponentFieldImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Walketh)).BeginInit();
            this.SuspendLayout();
            // 
            // MyFieldImage
            // 
            this.MyFieldImage.Location = new System.Drawing.Point(12, 42);
            this.MyFieldImage.Name = "MyFieldImage";
            this.MyFieldImage.Size = new System.Drawing.Size(300, 300);
            this.MyFieldImage.TabIndex = 0;
            this.MyFieldImage.TabStop = false;
            // 
            // OponentFieldImage
            // 
            this.OponentFieldImage.Location = new System.Drawing.Point(410, 42);
            this.OponentFieldImage.Name = "OponentFieldImage";
            this.OponentFieldImage.Size = new System.Drawing.Size(300, 300);
            this.OponentFieldImage.TabIndex = 1;
            this.OponentFieldImage.TabStop = false;
            this.OponentFieldImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OponentFieldImage_MouseDown);
            // 
            // MyNickname
            // 
            this.MyNickname.AutoSize = true;
            this.MyNickname.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.MyNickname.Location = new System.Drawing.Point(13, 13);
            this.MyNickname.Name = "MyNickname";
            this.MyNickname.Size = new System.Drawing.Size(159, 26);
            this.MyNickname.TabIndex = 2;
            this.MyNickname.Text = "Your nickname";
            // 
            // OponentNickname
            // 
            this.OponentNickname.AutoSize = true;
            this.OponentNickname.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.OponentNickname.Location = new System.Drawing.Point(405, 13);
            this.OponentNickname.Name = "OponentNickname";
            this.OponentNickname.Size = new System.Drawing.Size(216, 26);
            this.OponentNickname.TabIndex = 3;
            this.OponentNickname.Text = "Wait for connection...";
            // 
            // Walketh
            // 
            this.Walketh.Location = new System.Drawing.Point(318, 166);
            this.Walketh.Name = "Walketh";
            this.Walketh.Size = new System.Drawing.Size(86, 50);
            this.Walketh.TabIndex = 4;
            this.Walketh.TabStop = false;
            // 
            // OnLan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 358);
            this.Controls.Add(this.Walketh);
            this.Controls.Add(this.OponentNickname);
            this.Controls.Add(this.MyNickname);
            this.Controls.Add(this.OponentFieldImage);
            this.Controls.Add(this.MyFieldImage);
            this.Name = "OnLan";
            this.Text = "OnLan";
            ((System.ComponentModel.ISupportInitialize)(this.MyFieldImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OponentFieldImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Walketh)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox MyFieldImage;
        private System.Windows.Forms.PictureBox OponentFieldImage;
        private System.Windows.Forms.Label MyNickname;
        private System.Windows.Forms.Label OponentNickname;
        private System.Windows.Forms.PictureBox Walketh;
    }
}