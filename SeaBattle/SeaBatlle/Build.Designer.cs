namespace SeaBatlle
{
    partial class Build
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
            this.Picture = new System.Windows.Forms.PictureBox();
            this.Next = new System.Windows.Forms.Button();
            this.AutoBuild = new System.Windows.Forms.Button();
            this.Clean = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).BeginInit();
            this.SuspendLayout();
            // 
            // Picture
            // 
            this.Picture.Location = new System.Drawing.Point(13, 13);
            this.Picture.Name = "Picture";
            this.Picture.Size = new System.Drawing.Size(559, 360);
            this.Picture.TabIndex = 0;
            this.Picture.TabStop = false;
            this.Picture.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Picture_MouseDown);
            this.Picture.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Picture_MouseMove);
            this.Picture.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Picture_MouseUp);
            // 
            // Next
            // 
            this.Next.Enabled = false;
            this.Next.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Next.Location = new System.Drawing.Point(496, 330);
            this.Next.Name = "Next";
            this.Next.Size = new System.Drawing.Size(75, 42);
            this.Next.TabIndex = 1;
            this.Next.Text = "Next";
            this.Next.UseVisualStyleBackColor = true;
            this.Next.Click += new System.EventHandler(this.Next_Click);
            // 
            // AutoBuild
            // 
            this.AutoBuild.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.AutoBuild.Location = new System.Drawing.Point(415, 330);
            this.AutoBuild.Name = "AutoBuild";
            this.AutoBuild.Size = new System.Drawing.Size(75, 42);
            this.AutoBuild.TabIndex = 2;
            this.AutoBuild.Text = "Auto\r\nBuild";
            this.AutoBuild.UseVisualStyleBackColor = true;
            this.AutoBuild.Click += new System.EventHandler(this.AutoBuild_Click);
            // 
            // Clean
            // 
            this.Clean.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Clean.Location = new System.Drawing.Point(367, 330);
            this.Clean.Name = "Clean";
            this.Clean.Size = new System.Drawing.Size(42, 42);
            this.Clean.TabIndex = 3;
            this.Clean.Text = "CE";
            this.Clean.UseVisualStyleBackColor = true;
            this.Clean.Click += new System.EventHandler(this.Clean_Click);
            // 
            // Build
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 385);
            this.Controls.Add(this.Clean);
            this.Controls.Add(this.AutoBuild);
            this.Controls.Add(this.Next);
            this.Controls.Add(this.Picture);
            this.Name = "Build";
            this.Text = "Build";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Build_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Picture;
        private System.Windows.Forms.Button Next;
        private System.Windows.Forms.Button AutoBuild;
        private System.Windows.Forms.Button Clean;
    }
}