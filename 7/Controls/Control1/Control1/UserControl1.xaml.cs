using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace Control1
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public event EventHandler<EventArgs> FileNameChanged;

        public string FileName
        {
            get { return theTextBox.Text; }
            set { theTextBox.Text = value; }
        }

        public UserControl1()
        {
            InitializeComponent();
            theTextBox.TextChanged += OnTextChanged;
        }

        private void theButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog d = new OpenFileDialog();
            if (d.ShowDialog() == true)
            {
                this.FileName = d.FileName;
            }
        }

        void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            e.Handled = true;
            if (FileNameChanged != null)
                FileNameChanged(this, EventArgs.Empty);
        }
    }
}
