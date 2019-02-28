using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using System.IO;

namespace _2
{
    public partial class Search : Form
    {
        public Search()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            groupBox1.Visible = checkBox1.Checked;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Regex r1 = new Regex(textBox1.Text);
            Univercity univercity = null;

            XmlSerializer serializer = new XmlSerializer(typeof(Univercity));
            using (FileStream stream = new FileStream("University.xml", FileMode.Open))
            {
                univercity = serializer.Deserialize(stream) as Univercity;
            }
            listBox1.Items.Clear();
            List<Student> searchResult = new List<Student>();
            foreach(Student student in univercity.Students)
            {
                if (r1.IsMatch(student.Fio))
                {
                    if (checkBox1.Checked)
                    {
                        if (comboBox1.Text.Length > 0 && comboBox1.Text != student.Specialization)
                            continue;
                        if (numericUpDown1.Value != student.Cource)
                            continue;
                        if ( Decimal.ToDouble(numericUpDown2.Value) > student.Average)
                            continue;
                    }
                    //listBox1.Items.Add(student.Fio);
                    searchResult.Add(student);
                }
            }
            IEnumerable<Student> ordered = null;
            if (domainUpDown1.Text == "По курсу")
                ordered = searchResult.OrderBy(p => p.Cource);
            else
                ordered = searchResult.OrderBy(p => p.Fio);

            foreach (Student item in ordered)
                listBox1.Items.Add(item.Fio);
        }
    }
}
