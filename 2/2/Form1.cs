using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;

namespace _2
{
    public partial class Form1 : Form
    {
        public Univercity univercity;
        public Form1()
        {
            InitializeComponent();
            univercity = new Univercity();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Student currentStudent = new Student
            {
                Fio = textBox1.Text,
                Specialization = comboBox1.Text,
                Born = dateTimePicker1.Value,
                Cource = trackBar1.Value,
                Group = Decimal.ToInt32(numericUpDown1.Value),
                Average = Double.Parse(textBox2.Text),
                Sex = domainUpDown1.Text
            };
            univercity.Students.Add(currentStudent);
            listBox1.Items.Add(currentStudent.Fio);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Univercity));
            using (FileStream stream = new FileStream("University.xml", FileMode.OpenOrCreate))
            {
                serializer.Serialize(stream, univercity);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Univercity));
            using (FileStream stream = new FileStream("University.xml", FileMode.Open))
            {
                univercity = serializer.Deserialize(stream) as Univercity;
            }
            foreach(Student student in univercity.Students)
                listBox1.Items.Add(student.Fio);
        }
    }
}
