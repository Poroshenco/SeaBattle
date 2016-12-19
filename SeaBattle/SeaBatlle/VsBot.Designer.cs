namespace SeaBatlle
{
    partial class VsBot
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
            this.MyField = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Walketh = new System.Windows.Forms.PictureBox();
            this.BotField = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.MyField)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Walketh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BotField)).BeginInit();
            this.SuspendLayout();
            // 
            // MyField
            // 
            this.MyField.Location = new System.Drawing.Point(20, 40);
            this.MyField.Name = "MyField";
            this.MyField.Size = new System.Drawing.Size(300, 300);
            this.MyField.TabIndex = 0;
            this.MyField.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "Your field:";
            // 
            // Walketh
            // 
            this.Walketh.Location = new System.Drawing.Point(326, 165);
            this.Walketh.Name = "Walketh";
            this.Walketh.Size = new System.Drawing.Size(86, 50);
            this.Walketh.TabIndex = 5;
            this.Walketh.TabStop = false;
            // 
            // BotField
            // 
            this.BotField.Location = new System.Drawing.Point(418, 40);
            this.BotField.Name = "BotField";
            this.BotField.Size = new System.Drawing.Size(300, 300);
            this.BotField.TabIndex = 6;
            this.BotField.TabStop = false;
            this.BotField.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BotField_MouseDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label2.Location = new System.Drawing.Point(410, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 29);
            this.label2.TabIndex = 7;
            this.label2.Text = "Bot field:";
            // 
            // VsBot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 353);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BotField);
            this.Controls.Add(this.Walketh);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MyField);
            this.Name = "VsBot";
            this.Text = "VsBot";
            ((System.ComponentModel.ISupportInitialize)(this.MyField)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Walketh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BotField)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox MyField;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox Walketh;
        private System.Windows.Forms.PictureBox BotField;
        private System.Windows.Forms.Label label2;
    }
}