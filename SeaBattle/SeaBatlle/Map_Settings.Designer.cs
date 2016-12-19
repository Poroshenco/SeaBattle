namespace SeaBatlle
{
    partial class Map_Settings
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
            this._MapSize = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this._Linkors = new System.Windows.Forms.TextBox();
            this._AirCrafters = new System.Windows.Forms.TextBox();
            this._Cruisers = new System.Windows.Forms.TextBox();
            this._Esmineces = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Map size:";
            // 
            // _MapSize
            // 
            this._MapSize.Location = new System.Drawing.Point(90, 11);
            this._MapSize.Name = "_MapSize";
            this._MapSize.Size = new System.Drawing.Size(47, 20);
            this._MapSize.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label2.Location = new System.Drawing.Point(93, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 22);
            this.label2.TabIndex = 2;
            this.label2.Text = "Destroyers:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label3.Location = new System.Drawing.Point(93, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 22);
            this.label3.TabIndex = 3;
            this.label3.Text = "Aircrafters:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label5.Location = new System.Drawing.Point(12, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(159, 22);
            this.label5.TabIndex = 5;
            this.label5.Text = "Amount of Linkors:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label6.Location = new System.Drawing.Point(93, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 22);
            this.label6.TabIndex = 6;
            this.label6.Text = "Cruisers:";
            // 
            // _Linkors
            // 
            this._Linkors.Location = new System.Drawing.Point(186, 51);
            this._Linkors.Name = "_Linkors";
            this._Linkors.Size = new System.Drawing.Size(34, 20);
            this._Linkors.TabIndex = 7;
            // 
            // _AirCrafters
            // 
            this._AirCrafters.Location = new System.Drawing.Point(186, 77);
            this._AirCrafters.Name = "_AirCrafters";
            this._AirCrafters.Size = new System.Drawing.Size(34, 20);
            this._AirCrafters.TabIndex = 8;
            // 
            // _Cruisers
            // 
            this._Cruisers.Location = new System.Drawing.Point(186, 103);
            this._Cruisers.Name = "_Cruisers";
            this._Cruisers.Size = new System.Drawing.Size(34, 20);
            this._Cruisers.TabIndex = 9;
            // 
            // _Esmineces
            // 
            this._Esmineces.Location = new System.Drawing.Point(186, 129);
            this._Esmineces.Name = "_Esmineces";
            this._Esmineces.Size = new System.Drawing.Size(34, 20);
            this._Esmineces.TabIndex = 10;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(79, 157);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Map_Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(232, 184);
            this.Controls.Add(this.button1);
            this.Controls.Add(this._Esmineces);
            this.Controls.Add(this._Cruisers);
            this.Controls.Add(this._AirCrafters);
            this.Controls.Add(this._Linkors);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._MapSize);
            this.Controls.Add(this.label1);
            this.Name = "Map_Settings";
            this.Text = "Map";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _MapSize;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox _Linkors;
        private System.Windows.Forms.TextBox _AirCrafters;
        private System.Windows.Forms.TextBox _Cruisers;
        private System.Windows.Forms.TextBox _Esmineces;
        private System.Windows.Forms.Button button1;
    }
}