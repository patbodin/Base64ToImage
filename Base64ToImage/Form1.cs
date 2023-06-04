using Base64ToImage.Model;
using Base64ToImage.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Base64ToImage
{
    public partial class Form1 : Form
    {
        ImageElement imgElement;
        public Form1()
        {
            InitializeComponent();

            imgElement = new ImageElement();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtInput.Clear();
        }

        private void txtInput_TextChanged(object sender, EventArgs e)
        {
            txtLength.Text = txtInput.Text.Trim().Count().ToString();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            saveFileDialog1.InitialDirectory = @"C:\";      
            saveFileDialog1.Title = "Please select destination to save file";
            //saveFileDialog1.CheckFileExists = true;
            saveFileDialog1.CheckPathExists = true;
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.DefaultExt = imgElement.ImgExtension.ToLower();
            saveFileDialog1.Filter = String.Format("{0} (*.{1})|*.{1}|All files (*.*)|*.*", imgElement.ImgExtension.ToUpper(), imgElement.ImgExtension.ToLower());

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtOutput.Text = saveFileDialog1.FileName;
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (txtInput.Text.Trim() != "")
            {
                imgElement.StrBase64Input = txtInput.Text.Trim();
                //MessageBox.Show(imgElement.StrBase64Input);

                if (!imgElement.IsBase64String())
                {
                    MessageBox.Show("Invalid Base64 Input!");

                    btnBrowse.Enabled = false;
                }
                else
                {
                    //MessageBox.Show("Base64 Input - Passed");

                    pictureBox1.Image = imgElement.Base64ToImage();
                    //MessageBox.Show(ImageService.ImageType(pictureBox1.Image));

                    btnBrowse.Enabled = true;

                    dataGridView1.ColumnCount = 3;
                    dataGridView1.Columns[0].DefaultCellStyle.ForeColor = Color.DarkBlue;
                    dataGridView1.Columns[0].DefaultCellStyle.Font = new Font(this.Font, FontStyle.Bold);
                    dataGridView1.Columns[1].DefaultCellStyle.ForeColor = Color.Blue;

                    dataGridView1.Rows.Clear();
                    dataGridView1.Rows.Add(new string[] { "Width", imgElement.Width.ToString(), "" });
                    dataGridView1.Rows.Add(new string[] { "Height", imgElement.Height.ToString(), "" });
                    dataGridView1.Rows.Add(new string[] { "Extension", imgElement.ImgExtension.ToUpper(), "" });
                    dataGridView1.Rows.Add(new string[] { "HResolution", imgElement.img.HorizontalResolution.ToString(), "Horizontal Resolution" });
                    dataGridView1.Rows.Add(new string[] { "VResolution", imgElement.img.HorizontalResolution.ToString(), "Vertical Resolution" });
                }
            }
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null && txtOutput.Text.Trim() != "")
            {
                try
                {
                    byte[] img = Convert.FromBase64String(imgElement.StrBase64Input);
                    MemoryStream ms = new MemoryStream(img);
                    Bitmap bmp = new Bitmap(ms);
                    System.Drawing.Image.FromStream(ms);
                    bmp.Save(txtOutput.Text.Trim(), ImageService.ImageType(imgElement.ImgExtension));

                    //imgElement.img.Save(txtOutput.Text.Trim());                    

                    MessageBox.Show("Saved successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }
        }

        private void txtOutput_TextChanged(object sender, EventArgs e)
        {
            if (txtOutput.Text.Trim() != "")
            {
                btnSave.Enabled = true;
            }
            else
            {
                btnSave.Enabled = false;
            }
        }
    }
}
