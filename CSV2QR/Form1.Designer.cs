namespace CSV2QR
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SelectFileBtn = new System.Windows.Forms.Button();
            this.FileNameLbl = new System.Windows.Forms.Label();
            this.radioButtonJpeg = new System.Windows.Forms.RadioButton();
            this.radioButtonPng = new System.Windows.Forms.RadioButton();
            this.qrCodeImageFormatGroupBox = new System.Windows.Forms.GroupBox();
            this.qrCodeImageFormatGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // SelectFileBtn
            // 
            this.SelectFileBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.SelectFileBtn.Location = new System.Drawing.Point(38, 127);
            this.SelectFileBtn.Name = "SelectFileBtn";
            this.SelectFileBtn.Size = new System.Drawing.Size(200, 23);
            this.SelectFileBtn.TabIndex = 0;
            this.SelectFileBtn.Text = "Select File";
            this.SelectFileBtn.UseVisualStyleBackColor = true;
            this.SelectFileBtn.Click += new System.EventHandler(this.SelectFileBtn_Click);
            // 
            // FileNameLbl
            // 
            this.FileNameLbl.AutoSize = true;
            this.FileNameLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.FileNameLbl.Location = new System.Drawing.Point(35, 96);
            this.FileNameLbl.Name = "FileNameLbl";
            this.FileNameLbl.Size = new System.Drawing.Size(111, 17);
            this.FileNameLbl.TabIndex = 1;
            this.FileNameLbl.Text = "No File Selected";
            // 
            // radioButtonJpeg
            // 
            this.radioButtonJpeg.AutoSize = true;
            this.radioButtonJpeg.Checked = true;
            this.radioButtonJpeg.Location = new System.Drawing.Point(6, 19);
            this.radioButtonJpeg.Name = "radioButtonJpeg";
            this.radioButtonJpeg.Size = new System.Drawing.Size(52, 17);
            this.radioButtonJpeg.TabIndex = 2;
            this.radioButtonJpeg.TabStop = true;
            this.radioButtonJpeg.Text = "JPEG";
            this.radioButtonJpeg.UseVisualStyleBackColor = true;
            this.radioButtonJpeg.Click += new System.EventHandler(this.RadioButtonImageFormat_Click);
            // 
            // radioButtonPng
            // 
            this.radioButtonPng.AutoSize = true;
            this.radioButtonPng.Location = new System.Drawing.Point(6, 42);
            this.radioButtonPng.Name = "radioButtonPng";
            this.radioButtonPng.Size = new System.Drawing.Size(48, 17);
            this.radioButtonPng.TabIndex = 3;
            this.radioButtonPng.Text = "PNG";
            this.radioButtonPng.UseVisualStyleBackColor = true;
            this.radioButtonPng.Click += new System.EventHandler(this.RadioButtonImageFormat_Click);
            // 
            // qrCodeImageFormatGroupBox
            // 
            this.qrCodeImageFormatGroupBox.Controls.Add(this.radioButtonJpeg);
            this.qrCodeImageFormatGroupBox.Controls.Add(this.radioButtonPng);
            this.qrCodeImageFormatGroupBox.Location = new System.Drawing.Point(38, 22);
            this.qrCodeImageFormatGroupBox.Name = "qrCodeImageFormatGroupBox";
            this.qrCodeImageFormatGroupBox.Size = new System.Drawing.Size(200, 71);
            this.qrCodeImageFormatGroupBox.TabIndex = 4;
            this.qrCodeImageFormatGroupBox.TabStop = false;
            this.qrCodeImageFormatGroupBox.Text = "QR Code Image Format";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 192);
            this.Controls.Add(this.qrCodeImageFormatGroupBox);
            this.Controls.Add(this.FileNameLbl);
            this.Controls.Add(this.SelectFileBtn);
            this.Name = "Form1";
            this.Text = "Excel2QR";
            this.qrCodeImageFormatGroupBox.ResumeLayout(false);
            this.qrCodeImageFormatGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SelectFileBtn;
        private System.Windows.Forms.Label FileNameLbl;
        private System.Windows.Forms.RadioButton radioButtonJpeg;
        private System.Windows.Forms.RadioButton radioButtonPng;
        private System.Windows.Forms.GroupBox qrCodeImageFormatGroupBox;
    }
}

