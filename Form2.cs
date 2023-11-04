using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Steganography
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private static byte[] ImageToByte(Bitmap img)
        {
            byte[] result = new byte[img.Width * img.Height * 3];
            int i = 0;
            for (int y = 0; y < img.Height; y++)
            {
                for (int x = 0; x < img.Width; x++)
                {
                    Color clr = img.GetPixel(x, y);
                    result[i] = (byte)(clr.R & 0x03);
                    result[++i] = (byte)(clr.G & 0x03);
                    result[++i] = (byte)(clr.B & 0x03);
                    i += 1;
                }
            }
            return result;
        }
        private static byte[] Decode(byte[] temp)
        {
            byte[] result = new byte[temp.Length / 4];
            for (int i = 0, j = 0; i < temp.Length; i += 4, j += 1)
            {
                result[j] = (byte)((temp[i] << 6) | (temp[i + 1] << 4) | (temp[i + 2] << 2) | temp[i + 3]);
            }

            return result;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void Form2_Load(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap("E:\\Informatic\\Sem 3\\HomeWork\\Steganography\\Steganography\\1006.png");
            //label1.Text = bmp.PixelFormat.ToString();//
            byte[] arr = ImageToByte(bmp);
            richTextBox1.Text = Encoding.ASCII.GetString(Decode(arr)).Replace("\\n", "|||||");
        }
    }
}
