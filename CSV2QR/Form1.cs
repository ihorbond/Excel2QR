using OfficeOpenXml;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSV2QR
{
    public partial class Form1 : Form
    {
        private const string _noFileSelectedMsg = "No File Selected";
        private OpenFileDialog _openFileDialog;
        private readonly bool _isDotNetCoreApp;

        public Form1()
        {
            InitializeComponent();
            progressBar1.Minimum = progressBar1.Value = 0;
            ListOfExcelColumns.SelectedIndex = 0;
            _isDotNetCoreApp = CheckTargetFramework();
        }

        #region Event Handlers

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
                SelectFileBtn.Enabled = false;
                ListOfExcelColumns.Enabled = false;

                //columns in excel file are not 0 index based
                int colNum = ListOfExcelColumns.SelectedIndex + 1;
                await Task.Factory.StartNew(() => CreateQrCodes(colNum));

                ProgressLbl.Text = "Progress";
                SelectFileBtn.Enabled = true;
                ListOfExcelColumns.Enabled = true;
            }

            FileNameLbl.Text = _noFileSelectedMsg;
        }

        private void RadioButtonImageFormat_Click(object sender, EventArgs e)
        {
            qrCodeImageFormatGroupBox.Controls
                .Cast<RadioButton>()
                .ToList()
                .ForEach(c => c.Checked = c == sender as RadioButton);
        }

        private void codeSpaceHypeLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenBrowser("https://codespaceinc.co/");
        }

        #endregion

        /// <summary>
        /// Excel sheet and col index start at 0 for .Net Core
        /// and at 1 for .Net Framework
        /// </summary>
        /// <returns>is .net core app</returns>
        private bool CheckTargetFramework()
        {
            return AppDomain.CurrentDomain.SetupInformation.TargetFrameworkName.ToUpper().Contains("CORE");
        }

        /// <summary>
        /// Parse file and create qr code images
        /// </summary>
        /// <param name="colNum"></param>
        private void CreateQrCodes(int colNum)
        {
            try
            {
                ExcelPackage package = new ExcelPackage(_openFileDialog.OpenFile());
                ExcelWorksheet firstSheet = package.Workbook.Worksheets[_isDotNetCoreApp ? 0:1];

                if(firstSheet != null && firstSheet.Cells != null)
                {
                    string excelFileDirPath = Path.GetDirectoryName(_openFileDialog.FileName);
                    string qrDirPath = Path.Combine(excelFileDirPath, "QR Codes");
                    if (Directory.Exists(qrDirPath))
                        Directory.Delete(qrDirPath, true);
                        
                    Directory.CreateDirectory(qrDirPath);
                    ImageFormat format = GetImageFormat();

                    int i = 1;
                    var data = new List<string>();
                    while(firstSheet.Cells[i, colNum].Text.ToString().Trim() != "")
                    {
                        data.Add(firstSheet.Cells[i, colNum].Text);
                        i++;
                    }

                    progressBar1.Invoke(new Action(() => progressBar1.Maximum = data.Count));

                    for(int index = 0; index < data.Count; index++)
                    {
                        string textToEncode = data[index];
                        Bitmap img = GenerateQRCode(textToEncode);
                        string fileName = $"Row {index + 1}.{format.ToString().ToUpper()}";
                        string fullFileName = Path.Combine(qrDirPath, fileName);
                        SaveImage(img, format, fullFileName);
                        progressBar1.Invoke(new Action(() => progressBar1.PerformStep()));
                        ProgressLbl.Invoke(new Action(() => ProgressLbl.Text = $"Processing: {index + 1}/{data.Count}"));
                    }

                    MessageBox.Show("QR codes created successfully in the same folder as the selected Excel file", "Success");
                }

                firstSheet.Dispose();
                package.Workbook.Dispose();
                package.Dispose();
            }
            catch (SecurityException ex)
            {
                MessageBox.Show($"Security error.\nError message: {ex.Message}\n", "Error");
            }
            catch (IOException ex)
            {
                MessageBox.Show($"Can't open/save files.\nError message: {ex.Message}\n", "Error");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unknown error.\nError message: {ex.Message}\n", "Error");
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
        /// Get QR image format
        /// </summary>
        /// <returns></returns>
        private ImageFormat GetImageFormat()
        {
            IEnumerable<RadioButton> controls = qrCodeImageFormatGroupBox.Controls.Cast<RadioButton>();
            RadioButton checkedControl = controls.First(c => c.Checked);
            ImageFormat format = checkedControl.Text switch
            {
                "JPEG" => ImageFormat.Jpeg,
                "PNG" => ImageFormat.Png,
                _ => ImageFormat.Jpeg,
            };
            return format;
        }

        /// <summary>
        /// Save image to specified location
        /// </summary>
        /// <param name="img"></param>
        /// <param name="fullFileName"></param>
        private void SaveImage(Bitmap img, ImageFormat format, string fullFileName)
        {
            img.Save(fullFileName, format);
            img.Dispose();
        }

        /// <summary>
        /// Hack because of this: https://github.com/dotnet/corefx/issues/10361
        /// </summary>
        /// <param name="url"></param>
        private void OpenBrowser(string url)
        {
            try
            {
                Process.Start(url);
            }
            catch
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    url = url.Replace("&", "^&");
                    Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    Process.Start("xdg-open", url);
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    Process.Start("open", url);
                }
                else
                {
                    MessageBox.Show($"Please visit us at {url}", "Developer");
                }
            }
        }

    }
}
