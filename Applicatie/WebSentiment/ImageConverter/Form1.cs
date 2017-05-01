using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageConverter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        //private void btn_restoreImage_Click(object sender, EventArgs e)
        //{
        //    SQLConectionHelper sqcH = new SQLConectionHelper();
        //    pbox_previewImage.Image = byteArrayToImage(sqcH.GetImage());
        //}
        void functionBox()
        {
            //tbx_productName.Text = "";
            //tbx_material.Text = "";
            //tbx_stackable.Text = "";
            //tbx_adjustable.Text = "";
            //tbx_price.Text = "";
            //tbx_description.Text = "";
            //tbx_summray.Text = "";
            //tbx_catergory.Text = "";
            //tbx_brand.Text = "";
            //pbox_previewImage.Image = null;
        }
        //imageToByteArray(pbox_previewImage.Image)
        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            var sb = new StringBuilder("new byte[] { ");
            tbOutput.Text = sb.ToString();
            //tbOutput.Text = Encoding.ASCII.GetString(ms.ToArray());

            foreach (var b in ms.ToArray())
            {
                tbOutput.Text += b + ", ";
            }

           // tbOutput.Text.Remove(tbOutput.TextLength);
            tbOutput.Text = tbOutput.Text.Substring(0, tbOutput.TextLength - 2);

            tbOutput.Text += " };";
            tbOutput.SelectAll();
            tbOutput.Focus();
            //GetBytes(Encoding.ASCII.GetString(ms.ToArray()));



            return ms.ToArray();
        }

        public byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            tbOutput.Text += bytes;
            return bytes;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "JPG Files(*.jpg)|*.jpg|PNG Files(*.png)|*.png";
            DialogResult result = openFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                this.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                if (openFileDialog1.FileName.Contains(".png") || openFileDialog1.FileName.Contains(".jpg"))
                {
                    pictureBox1.Image = new Bitmap(openFileDialog1.FileName);
                    imageToByteArray(pictureBox1.Image);

                }
                else
                {
                    pictureBox1.Image = null;
                    MessageBox.Show("The image you have selected does not meet the requirements Extensions supported: JPG, PNG",
                     "Image selector",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Exclamation,
                     MessageBoxDefaultButton.Button1);
                }
            }

        }
    }
}
