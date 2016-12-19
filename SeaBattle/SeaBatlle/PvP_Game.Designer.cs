namespace SeaBatlle
{
    partial class PvP_Game
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
            this.FirstPlayerPicture = new System.Windows.Forms.PictureBox();
            this.SecondPlayerPicture = new System.Windows.Forms.PictureBox();
            this.FirstNickname = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.SecondNickname = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.FirstPlayerPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecondPlayerPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // FirstPlayerPicture
            // 
            this.FirstPlayerPicture.Location = new System.Drawing.Point(20, 40);
            this.FirstPlayerPicture.Name = "FirstPlayerPicture";
            this.FirstPlayerPicture.Size = new System.Drawing.Size(300, 300);
            this.FirstPlayerPicture.TabIndex = 1;
            this.FirstPlayerPicture.TabStop = false;
            this.FirstPlayerPicture.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FirstPlayerPicture_MouseDown);
            // 
            // SecondPlayerPicture
            // 
            this.SecondPlayerPicture.Location = new System.Drawing.Point(418, 40);
            this.SecondPlayerPicture.Name = "SecondPlayerPicture";
            this.SecondPlayerPicture.Size = new System.Drawing.Size(300, 300);
            this.SecondPlayerPicture.TabIndex = 2;
            this.SecondPlayerPicture.TabStop = false;
            this.SecondPlayerPicture.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SecondPlayerPicture_MouseDown);
            // 
            // FirstNickname
            // 
            this.FirstNickname.AutoSize = true;
            this.FirstNickname.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.FirstNickname.Location = new System.Drawing.Point(16, 9);
            this.FirstNickname.Name = "FirstNickname";
            this.FirstNickname.Size = new System.Drawing.Size(174, 26);
            this.FirstNickname.TabIndex = 3;
            this.FirstNickname.Text = "Nickname1 field:";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(326, 165);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(86, 50);
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // SecondNickname
            // 
            this.SecondNickname.AutoSize = true;
            this.SecondNickname.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.SecondNickname.Location = new System.Drawing.Point(414, 9);
            this.SecondNickname.Name = "SecondNickname";
            this.SecondNickname.Size = new System.Drawing.Size(174, 26);
            this.SecondNickname.TabIndex = 7;
            this.SecondNickname.Text = "Nickname2 field:";
            // 
            // PvP_Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 349);
            this.Controls.Add(this.SecondNickname);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.FirstNickname);
            this.Controls.Add(this.SecondPlayerPicture);
            this.Controls.Add(this.FirstPlayerPicture);
            this.Name = "PvP_Game";
            this.Text = "PvP_Game";
            ((System.ComponentModel.ISupportInitialize)(this.FirstPlayerPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecondPlayerPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox FirstPlayerPicture;
        private System.Windows.Forms.PictureBox SecondPlayerPicture;
        private System.Windows.Forms.Label FirstNickname;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label SecondNickname;
    }
}