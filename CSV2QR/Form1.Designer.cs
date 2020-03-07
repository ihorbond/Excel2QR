using System.Drawing;

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
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.ProgressLbl = new System.Windows.Forms.Label();
            this.codeSpaceHypeLink = new System.Windows.Forms.LinkLabel();
            this.ListOfExcelColumns = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.qrCodeImageFormatGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // SelectFileBtn
            // 
            this.SelectFileBtn.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectFileBtn.Location = new System.Drawing.Point(12, 142);
            this.SelectFileBtn.Name = "SelectFileBtn";
            this.SelectFileBtn.Size = new System.Drawing.Size(200, 26);
            this.SelectFileBtn.TabIndex = 0;
            this.SelectFileBtn.Text = "Select File";
            this.SelectFileBtn.UseVisualStyleBackColor = true;
            this.SelectFileBtn.Click += new System.EventHandler(this.SelectFileBtn_Click);
            // 
            // FileNameLbl
            // 
            this.FileNameLbl.AutoSize = true;
            this.FileNameLbl.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileNameLbl.Location = new System.Drawing.Point(8, 120);
            this.FileNameLbl.Name = "FileNameLbl";
            this.FileNameLbl.Size = new System.Drawing.Size(113, 19);
            this.FileNameLbl.TabIndex = 1;
            this.FileNameLbl.Text = "No File Selected";
            // 
            // radioButtonJpeg
            // 
            this.radioButtonJpeg.AutoSize = true;
            this.radioButtonJpeg.Checked = true;
            this.radioButtonJpeg.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonJpeg.Location = new System.Drawing.Point(12, 19);
            this.radioButtonJpeg.Name = "radioButtonJpeg";
            this.radioButtonJpeg.Size = new System.Drawing.Size(55, 22);
            this.radioButtonJpeg.TabIndex = 2;
            this.radioButtonJpeg.TabStop = true;
            this.radioButtonJpeg.Text = "JPEG";
            this.radioButtonJpeg.UseVisualStyleBackColor = true;
            this.radioButtonJpeg.Click += new System.EventHandler(this.RadioButtonImageFormat_Click);
            // 
            // radioButtonPng
            // 
            this.radioButtonPng.AutoSize = true;
            this.radioButtonPng.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonPng.Location = new System.Drawing.Point(76, 19);
            this.radioButtonPng.Name = "radioButtonPng";
            this.radioButtonPng.Size = new System.Drawing.Size(53, 22);
            this.radioButtonPng.TabIndex = 3;
            this.radioButtonPng.Text = "PNG";
            this.radioButtonPng.UseVisualStyleBackColor = true;
            this.radioButtonPng.Click += new System.EventHandler(this.RadioButtonImageFormat_Click);
            // 
            // qrCodeImageFormatGroupBox
            // 
            this.qrCodeImageFormatGroupBox.BackColor = System.Drawing.SystemColors.Control;
            this.qrCodeImageFormatGroupBox.Controls.Add(this.radioButtonJpeg);
            this.qrCodeImageFormatGroupBox.Controls.Add(this.radioButtonPng);
            this.qrCodeImageFormatGroupBox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qrCodeImageFormatGroupBox.Location = new System.Drawing.Point(12, 11);
            this.qrCodeImageFormatGroupBox.Name = "qrCodeImageFormatGroupBox";
            this.qrCodeImageFormatGroupBox.Size = new System.Drawing.Size(200, 46);
            this.qrCodeImageFormatGroupBox.TabIndex = 4;
            this.qrCodeImageFormatGroupBox.TabStop = false;
            this.qrCodeImageFormatGroupBox.Text = "QR code image format";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 192);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(200, 23);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 5;
            // 
            // ProgressLbl
            // 
            this.ProgressLbl.AutoSize = true;
            this.ProgressLbl.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ProgressLbl.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProgressLbl.Location = new System.Drawing.Point(11, 171);
            this.ProgressLbl.Name = "ProgressLbl";
            this.ProgressLbl.Size = new System.Drawing.Size(65, 19);
            this.ProgressLbl.TabIndex = 6;
            this.ProgressLbl.Text = "Progress";
            // 
            // codeSpaceHypeLink
            // 
            this.codeSpaceHypeLink.AutoSize = true;
            this.codeSpaceHypeLink.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codeSpaceHypeLink.LinkColor = System.Drawing.Color.Silver;
            this.codeSpaceHypeLink.Location = new System.Drawing.Point(27, 218);
            this.codeSpaceHypeLink.Name = "codeSpaceHypeLink";
            this.codeSpaceHypeLink.Size = new System.Drawing.Size(165, 14);
            this.codeSpaceHypeLink.TabIndex = 7;
            this.codeSpaceHypeLink.TabStop = true;
            this.codeSpaceHypeLink.Text = "Developed by Code Space Inc";
            this.codeSpaceHypeLink.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.codeSpaceHypeLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.codeSpaceHypeLink_LinkClicked);
            // 
            // ListOfExcelColumns
            // 
            this.ListOfExcelColumns.BackColor = System.Drawing.SystemColors.Window;
            this.ListOfExcelColumns.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ListOfExcelColumns.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListOfExcelColumns.FormattingEnabled = true;
            this.ListOfExcelColumns.Items.AddRange(new object[] {
            "A",
            "B",
            "C\t",
            "D",
            "E\t",
            "F\t",
            "G\t",
            "H\t",
            "I\t",
            "J\t",
            "K\t",
            "L\t",
            "M\t",
            "N\t",
            "O\t",
            "P\t",
            "Q\t",
            "R\t",
            "S\t",
            "T\t",
            "U\t",
            "V\t",
            "W\t",
            "X\t",
            "Y\t",
            "Z"});
            this.ListOfExcelColumns.Location = new System.Drawing.Point(12, 82);
            this.ListOfExcelColumns.Name = "ListOfExcelColumns";
            this.ListOfExcelColumns.Size = new System.Drawing.Size(200, 27);
            this.ListOfExcelColumns.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 19);
            this.label1.TabIndex = 6;
            this.label1.Text = "Spreadsheet Column Letter";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(227, 241);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.codeSpaceHypeLink);
            this.Controls.Add(this.ListOfExcelColumns);
            this.Controls.Add(this.ProgressLbl);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.qrCodeImageFormatGroupBox);
            this.Controls.Add(this.FileNameLbl);
            this.Controls.Add(this.SelectFileBtn);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = global::Excel2QR.Properties.Resources.icon;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(243, 280);
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
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label ProgressLbl;
        private System.Windows.Forms.LinkLabel codeSpaceHypeLink;
        private System.Windows.Forms.ComboBox ListOfExcelColumns;
        private System.Windows.Forms.Label label1;
    }
}

