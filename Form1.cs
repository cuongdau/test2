using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;

namespace assignment1
{
    public partial class Form1 : Form
    {
        int AX, BX, SR, a=0;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        private void openfile_Click(object sender, EventArgs e)
        {
           
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open text file";
            theDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*" ;
            //theDialog.InitialDirectory=@"C:\";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                string filename = theDialog.FileName;
                tfilename.Text = filename;
                string[] filelines = File.ReadAllLines(filename);
                // read file and store value
                lb1.Text = File.ReadAllText(filename);
                for (int a=0; a < filelines.Length; a++)
                {
                    string s = filelines[a].ToString();
                    
                    var colum_0 = s.Split(new string[] { " ", ", " }, StringSplitOptions.RemoveEmptyEntries)[0];
                    var colum_1 = s.Split(new string[] { " ", ", " }, StringSplitOptions.RemoveEmptyEntries)[1];
                    var colum_2 = s.Split(new string[] { " ", ", " }, StringSplitOptions.RemoveEmptyEntries)[2];
                   
                    if (colum_0 == "MOV")
                    {
                        if (colum_1 == "AX")
                        {
                            AX = int.Parse(colum_2.ToString());
                        }
                        else if (colum_1 == "BX" && colum_2 =="AX")
                        {
                            BX = AX ;
                           // lcolum.Text = BX.ToString();
                        }
                    }
                    else if (colum_0 == "ADD") 
                    {
                        AX = AX + int.Parse(colum_1.ToString());
                    }
                    else if (colum_0 == "CMP")
                    {
                        if (BX == int.Parse(colum_1.ToString()))
                        {
                            SR = 0;
                        }
                        else
                        {
                            SR = 1;
                        }
                    }
                    else if (colum_0 == "JNZ")
                    {
                        if (SR == 1)
                        {
                            a = 0; //int.Parse(colum_1.ToString());
                        }
                        else
                        {
                            a = 10;
                             lcolum.Text = BX.ToString();
                        }
                    }
                    else if (colum_0 == "PRT")
                    {
                        MessageBox.Show(AX.ToString());
                    }

                }
            }

        }

    }
}
