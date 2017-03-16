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
        public string f1 { get; set; }
        public string f4 { get; set; }
        public string f5 { get; set; }

        string pathX;

        public Form2(Form1 f1, string s1, Form4 f4, string s4, Form5 f5, string s5)
        {
            InitializeComponent();
            this.f1 = s1;
            this.f4 = s4;
            this.f5 = s5;
            label2.Text = s1;
            textBox1.Text = s4;
            textBox2.Text = s5;

            pathX = "";
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

        private void назадToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.CanUndo == true)
            {
                richTextBox1.Undo();
                richTextBox1.ClearUndo();
            }
        }

        private void вырезатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionLength > 0)
            {
                richTextBox1.Cut();
            }
        }

        private void копироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionLength > 0)
            {
                richTextBox1.Copy();
            }
        }

        private void вставитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                richTextBox1.Paste();
            }
        }

        private void найтиToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void заменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void выбратьВсёToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pathX != "")
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Apache Open Office (*.rtf)|*.rtf|Notepad (*.txt)|*.txt";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    pathX = sfd.FileName;
                    richTextBox1.SaveFile(pathX);
                }
                else
                {
                    richTextBox1.SaveFile(pathX);
                    MessageBox.Show("Saved.");
                }
            }
        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Apache Open Office (*.rtf)|*.rtf|Notepad (*.txt)|*.txt";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                pathX = sfd.FileName;
                richTextBox1.SaveFile(pathX);
            }
        }

        private void закрытьПриложениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
