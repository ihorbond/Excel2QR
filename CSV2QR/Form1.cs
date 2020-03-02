using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSV2QR
{
    public partial class Form1 : Form
    {
        private const string _noFileSelectedMsg = "No File Selected";
        public Form1()
        {
            InitializeComponent();
            FileNameLbl.Text = _noFileSelectedMsg;
        }

        private void SelectFileBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog()
            {
                Multiselect = false,
                Filter = "Excel files |*.xlsx;*.xls"
            };
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK)
            {
                try
                {
                    FileNameLbl.Text = openFileDialog1.SafeFileName;
                    var fileStream = openFileDialog1.OpenFile();
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
            if(result == DialogResult.Cancel)
            {
                FileNameLbl.Text = _noFileSelectedMsg;
            }
        }
    }
}
