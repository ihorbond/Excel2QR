using OfficeOpenXml;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Security;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSV2QR
{
    public partial class Form1 : Form
    {
        private const string _noFileSelectedMsg = "No File Selected";
        private OpenFileDialog _openFileDialog;
        private readonly Dictionary<int, string> excelCols = new Dictionary<int, string>
        {
            {0, "A" },
            {1, "B" },
            {2, "C" },
            {3, "D" },
            {4, "E" },
            {5, "F" },
            {6, "G" },
            {7, "H" },
            {8, "I" },
            {9, "J" },
            {10, "K" },
            {11, "L" },
            {12, "M" },
            {13, "N" },
            {14, "O" },
            {15, "P" },
            {16, "Q" },
            {17, "R" },
            {18, "S" },
            {19, "T" },
            {20, "U" },
            {21, "V" },
            {22, "W" },
            {23, "X" },
            {24, "Y" },
            {25, "Z" }
        };

        public Form1()
        {
            InitializeComponent();
            progressBar1.Minimum = progressBar1.Value = 0;
            ListOfExcelColumns.SelectedIndex = 0;
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
                SelectFileBtn.Enabled = false;
                ListOfExcelColumns.Enabled = false;

                //indexes are zero based but columns are not so add 1
                int colNum = ListOfExcelColumns.SelectedIndex + 1;
                await Task.Factory.StartNew(() => ParseFile(colNum));

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

        private void ParseFile(int colNum)
        {
            try
            {
                ExcelPackage package = new ExcelPackage(_openFileDialog.OpenFile());

                int sheetIndex = 1; //0 for .Net Core, 1 for .Net
                ExcelWorksheet firstSheet = package.Workbook.Worksheets[sheetIndex];
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
                        data.Add(firstSheet.Cells[i, 1].Text);
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
            ImageFormat format;
            IEnumerable<RadioButton> controls = qrCodeImageFormatGroupBox.Controls.Cast<RadioButton>();
            RadioButton checkedControl = controls.First(c => c.Checked);
            switch (checkedControl.Text)
            {
                case "JPEG":
                    format = ImageFormat.Jpeg;
                    break;
                case "PNG":
                    format = ImageFormat.Png;
                    break;
                default:
                    format = ImageFormat.Jpeg;
                    break;
            }
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

        private void codeSpaceHypeLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://codespaceinc.co/");
        }

    }
}
