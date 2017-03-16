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
    public partial class Form4 : Form
    {
        string path2;
        XDocument doc2 = new XDocument();

        public Form4()
        {
            InitializeComponent();
            path2 = @"..\..\notes.xml";
            doc2 = XDocument.Load(path2);
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            foreach (XElement c in doc2.Element("root").Elements("note"))
                comboBox1.Items.Add(c.Attribute("category").Value);

            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e) // add category
        {
            string catName = textBox1.Text;
            if (catName == "")
            {
                MessageBox.Show("You don`t input category.", "Input error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                comboBox1.Items.Add(catName);
                doc2.Element("root").Add(
                    new XElement("note",
                    new XAttribute("name", catName),
                    new XAttribute("category", catName)));
                doc2.Save(path2);

                textBox1.Clear();

                MessageBox.Show("Category has been saved", "Yes!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e) // delete category
        {
            string catName = comboBox1.SelectedItem.ToString();
            string msg = String.Format("Вы собираетесь удалить категорию {0}! Согласны?",
                catName);
            DialogResult res = MessageBox.Show(msg, "Подтверждаю",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (res == DialogResult.Yes)
            {
                comboBox1.Items.Remove(comboBox1.SelectedItem);
                var c = from x in doc2.Element("root").Elements("note")
                        where x.Attribute("category").Value == catName
                        select x;
                c.First().Remove();
                doc2.Save(path2);
                MessageBox.Show("Category delete.", "Warning!",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string catName = comboBox1.SelectedItem.ToString();
            var f = from x in doc2.Element("root").Elements("note")
                    where x.Attribute("category").Value == catName
                    select x.Attribute("name").Value;
        }

        private void button2_Click(object sender, EventArgs e) // select category
        {
            this.Hide();
        }
    }
}
