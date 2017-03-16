using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;
using System.Xml.Linq;

namespace PersonalNotes
{
    public partial class Form5 : Form
    {
        string path2;
        XDocument doc2 = new XDocument();

        public Form5()
        {
            InitializeComponent();
            path2 = @"..\..\notes.xml";
            doc2 = XDocument.Load(path2);
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            foreach (XElement c in doc2.Element("root").Elements("note"))
                comboBox1.Items.Add(c.Attribute("category").Value);

            comboBox1.SelectedIndex = 0;

            foreach (XElement v in doc2.Element("root").Elements("note"))
                comboBox2.Items.Add(v.Attribute("theme").Value);

            comboBox2.SelectedIndex = 0;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) // select category
        {
            string catName = comboBox2.SelectedItem.ToString();
            var f = from x in doc2.Element("root").Elements("note")
                    select x.Attribute("category").Value;
        }

        private void button3_Click(object sender, EventArgs e) // add note
        {
            string themeName = textBox1.Text;
            if (themeName == "")
            {
                MessageBox.Show("You don`t input theme name.", "Input error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                comboBox1.Items.Add(themeName);
                doc2.Element("root").Add(
                    new XElement("note",
                    new XAttribute("theme", themeName)));
                doc2.Save(path2);

                textBox1.Clear();

                MessageBox.Show("Theme has been saved", "Yes!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button4_Click(object sender, EventArgs e) // delete theme
        {
            string themeName = comboBox1.SelectedItem.ToString();
            string msg = String.Format("Вы собираетесь удалить тему {0}! Согласны?",
                themeName);
            DialogResult res = MessageBox.Show(msg, "Подтверждаю",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (res == DialogResult.Yes)
            {
                comboBox1.Items.Remove(comboBox1.SelectedItem);
                var c = from x in doc2.Element("root").Elements("note")
                        where x.Attribute("category").Value == themeName
                        select x;
                c.First().Remove();
                doc2.Save(path2);
                MessageBox.Show("Theme delete.", "Warning!",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string themeName = this.comboBox2.SelectedItem.ToString();
            var f = from x in doc2.Element("root").Elements("note")
                    select x.Attribute("theme").Value;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
