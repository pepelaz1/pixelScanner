using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace PixelScanner
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (ofd1.ShowDialog() == DialogResult.OK && ofd1.FileName != "")
            {
                //tbAssembly.Text = dlgAssembly.FileName;
                pbImage.Load(ofd1.FileName);
                Bitmap bmp = new Bitmap(pbImage.Image);

                uint [][]scan = new uint[bmp.Width][];
                for (int i = 0; i < bmp.Width; i++)
                {
                    scan[i] = new uint[bmp.Height];
                    for (int j = 0; j < bmp.Height; j++)
                    {
                        scan[i][j] = (uint)bmp.GetPixel(i, j).ToArgb();
                    }                    
                }

                using (StreamWriter outfile = new StreamWriter("output.txt"))
                {
                    //for (
                    for (int i = 0; i < bmp.Width; i++)
                    {
                        for (int j = 0; j < bmp.Height; j++)
                        {
                            outfile.Write(i);
                            outfile.Write(" ");
                            outfile.Write(j);
                            outfile.Write(" ");
                            outfile.WriteLine(scan[i][j]);
                            }
                    }
                }
                MessageBox.Show("Completed. Check output.txt file");
            }
        }
    }
}
