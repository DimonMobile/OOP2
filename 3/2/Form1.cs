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
using System.ComponentModel.DataAnnotations;

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

            var results = new List<ValidationResult>();
            var context = new ValidationContext(currentStudent);
            if (!Validator.TryValidateObject(currentStudent, context, results, true))
            {
                string errorString = "";
                foreach(var error in results)
                    errorString += error + "\n";
                MessageBox.Show(errorString);
            }

            univercity.Students.Add(currentStudent);
            listBox1.Items.Add(currentStudent.Fio);

            toolStripStatusLabel1.Text = $"Элементов {listBox1.Items.Count}";
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
            listBox1.Items.Clear();
            XmlSerializer serializer = new XmlSerializer(typeof(Univercity));
            using (FileStream stream = new FileStream("University.xml", FileMode.Open))
            {
                univercity = serializer.Deserialize(stream) as Univercity;
            }
            foreach(Student student in univercity.Students)
                listBox1.Items.Add(student.Fio);
            toolStripStatusLabel1.Text = $"Элементов {listBox1.Items.Count}";
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void файлToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void поискToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Search search = new Search();
            search.ShowDialog(this);
        }

        private void годToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            XmlSerializer serializer = new XmlSerializer(typeof(Univercity));
            using (FileStream stream = new FileStream("University.xml", FileMode.Open))
                univercity = serializer.Deserialize(stream) as Univercity;

            IEnumerable<Student> ordered = univercity.Students.OrderBy(p => p.Born);
            foreach (Student student in ordered)
                listBox1.Items.Add(student.Fio);

            toolStripStatusLabel1.Text = $"Элементов {listBox1.Items.Count}";
        }

        private void фамилияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            XmlSerializer serializer = new XmlSerializer(typeof(Univercity));
            using (FileStream stream = new FileStream("University.xml", FileMode.Open))
                univercity = serializer.Deserialize(stream) as Univercity;

            IEnumerable<Student> ordered = univercity.Students.OrderBy(p => p.Fio);
            foreach (Student student in ordered)
                listBox1.Items.Add(student.Fio);
        }

        private void специальностьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            XmlSerializer serializer = new XmlSerializer(typeof(Univercity));
            using (FileStream stream = new FileStream("University.xml", FileMode.Open))
                univercity = serializer.Deserialize(stream) as Univercity;

            IEnumerable<Student> ordered = univercity.Students.OrderBy(p => p.Specialization);
            foreach (Student student in ordered)
                listBox1.Items.Add(student.Fio);


            toolStripStatusLabel1.Text = $"Элементов {listBox1.Items.Count}";
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Плотников Дмитрий Андреевич 2-5");
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            button3_Click(null, null);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            button2_Click(null, null);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
