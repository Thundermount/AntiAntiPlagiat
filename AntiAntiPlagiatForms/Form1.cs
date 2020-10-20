using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AntiAntiPlagiatForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
                Random rnd = new Random();
                Random l = new Random();
            
            string txt = richTextBox2.Text;
            string repls;
            string schar;
            if (checkBox3.Checked)
            {
                schar = "/";
                repls = @"{\colortbl;\red255\green255\blue255;}{\fs1\cf1" + schar + "}";
            }
            else
            {
                repls = textBox1.Text;
                schar = textBox1.Text;
            }

                List<char> a = new List<char>();
                a.AddRange(txt.ToCharArray());
                Debug.Print("Загрузил текст");
                    for (int z = 0; z < a.Count; z++)
                    {
                    Debug.Print("Буква "+a[z]+" "+z);
                    if (a[z] != ' ' && a[z]!='\n')
                        {
                            if (checkBox1.Checked == true && a[z] != schar[0])
                            {
                                var n = rnd.Next(2);
                                if (n == 1)a.Insert(z+1, schar.ToCharArray()[0]);
                            }
                            if (checkBox2.Checked == true)
                            {
                                var y = a[z];
                                    
                                    var t = l.Next(3);
                                    if (y == 'а' && t == 2) y = 'a';
                                    if (y == 'с' && t == 2) y = 'c';
                                    if (y == 'у' && t == 2) y = 'y';
                                    if (y == 'Т' && t == 2) y = 'T';
                                    if (y == 'А' && t == 2) y = 'A';
                                    if (y == 'В' && t == 2) y = 'B';
                                    if (y == 'Р' && t == 2) y = 'P';
                                    if (y == 'р' && t == 2) y = 'p';
                                    if (y == 'е' && t == 2) y = 'e';
                                
                                a[z] = y;
                            }
                        }
                    }
                txt = new string(a.ToArray());
            richTextBox2.Text = txt;
            richTextBox2.Rtf = richTextBox2.Rtf.Replace(schar, repls);
                MessageBox.Show("Операция была успешно выполнена.");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
            {
                label1.Enabled = false;
                textBox1.Enabled = false;
            }
            else { textBox1.Enabled = true; label1.Enabled = true; }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process.Start("https://unicode-table.com/ru/");
        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new HelpForm().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Цикл стоит потому что не всегда копируется с первого раза почему то
            for (int i = 0; i < 41; i++){
                Clipboard.Clear();
                richTextBox2.Focus();
                richTextBox2.SelectAll();
                Clipboard.SetData(DataFormats.Rtf, richTextBox2.SelectedRtf);
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = !checkBox3.Checked;

        }
    }
}
