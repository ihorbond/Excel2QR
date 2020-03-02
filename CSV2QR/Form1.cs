﻿using OfficeOpenXml;
using QRCoder;
using System;
using System.Drawing;
using System.IO;
using System.Security;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSV2QR
{
    public partial class Form1 : Form
    {
        private const string _noFileSelectedMsg = "No File Selected";
        private OpenFileDialog _openFileDialog;
        public Form1()
        {
            InitializeComponent();
            FileNameLbl.Text = _noFileSelectedMsg;
        }

        private async void SelectFileBtn_Click(object sender, EventArgs e)
        {
            _openFileDialog = new OpenFileDialog()
            {
                Multiselect = false,
                Filter = "Excel files |*.xlsx",
                Title = "Select File"
            };

            DialogResult result = _openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                FileNameLbl.Text = _openFileDialog.SafeFileName;
                await Task.Factory.StartNew(() => ParseFile());
            }

            if(result == DialogResult.Cancel)
            {
                FileNameLbl.Text = _noFileSelectedMsg;
            }
        }

        private void ParseFile()
        {
            try
            {
                using (var package = new ExcelPackage(_openFileDialog.OpenFile()))
                {
                    //0 for .Net Core, 1 for .Net
                    var firstSheet = package.Workbook.Worksheets[1];
                    if(firstSheet.Cells != null)
                    {
                        string excelFileDirPath = Path.GetDirectoryName(_openFileDialog.FileName);
                        string qrDirPath = Path.Combine(excelFileDirPath, "QR Codes");
                        if (Directory.Exists(qrDirPath))
                            Directory.Delete(qrDirPath, true);
                        
                        Directory.CreateDirectory(qrDirPath);

                        int i = 1;
                        while (firstSheet.Cells[i, 1].Text.ToString().Trim() != "")
                        {
                            string textToEncode = firstSheet.Cells[i, 1].Text;
                            Bitmap img = GenerateQRCode(textToEncode);
                            string fileName = "Row " + i + ".jpeg";
                            string fullFileName = Path.Combine(qrDirPath, fileName);
                            SaveImage(img, fullFileName);
                            i++;
                        }
                        MessageBox.Show("Success");
                    }
                }
            }
            catch (SecurityException ex)
            {
                MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n");
            }
            catch (IOException ex)
            {
                MessageBox.Show($"Can't open file.\n\nError message: {ex.Message}\n\n");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Generate QR code
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private Bitmap GenerateQRCode(string data)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(data, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            return qrCode.GetGraphic(10);
        }

        /// <summary>
        /// Save image to specified location
        /// </summary>
        /// <param name="img"></param>
        /// <param name="fullFileName"></param>
        private void SaveImage(Bitmap img, string fullFileName)
        {
            img.Save(fullFileName, System.Drawing.Imaging.ImageFormat.Jpeg);
            img.Dispose();
        }

    }
}