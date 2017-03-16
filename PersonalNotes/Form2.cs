using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml.Linq;

namespace PersonalNotes
{
    public partial class Form2 : Form
    {
        Form1 f1;

        public Form2(Form1 f1, string s1)
        {
            InitializeComponent();
            this.f1 = f1;
            label2.Text = s1;
            
        }

        private void label2_Click(object sender, EventArgs e)
        {
           
        }

        private void калькуляторToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
        }

        private void категориюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.Show();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void категориюToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.Show();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void темуЗаметкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.Show();
        }

        private void темуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.Show();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            f1.Close();
        }
    }
}
