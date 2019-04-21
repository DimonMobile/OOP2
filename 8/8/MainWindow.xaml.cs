using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

using System.IO;

using Microsoft.Win32;
using System.Data;

namespace _8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Byte[] pictureData;

        public MainWindow()
        {
            InitializeComponent();            
        }

        private void test_onClick(object sender, RoutedEventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True");
            try
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT Name FROM Student";
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    MessageBox.Show((string)reader.GetValue(0));
                }
                reader.Close();
            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
            finally
            {
                connection.Close();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            _8.Database1DataSet database1DataSet = ((_8.Database1DataSet)(this.FindResource("database1DataSet")));
            // Load data into the table Student. You can modify this code as needed.
            _8.Database1DataSetTableAdapters.StudentTableAdapter database1DataSetStudentTableAdapter = new _8.Database1DataSetTableAdapters.StudentTableAdapter();
            database1DataSetStudentTableAdapter.Fill(database1DataSet.Student);
            System.Windows.Data.CollectionViewSource studentViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("studentViewSource")));
            studentViewSource.View.MoveCurrentToFirst();
            // Load data into the table Faculty. You can modify this code as needed.
            _8.Database1DataSetTableAdapters.FacultyTableAdapter database1DataSetFacultyTableAdapter = new _8.Database1DataSetTableAdapters.FacultyTableAdapter();
            database1DataSetFacultyTableAdapter.Fill(database1DataSet.Faculty);
            System.Windows.Data.CollectionViewSource facultyViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("facultyViewSource")));
            facultyViewSource.View.MoveCurrentToFirst();
        }

        private void addStudent_onClick(object sender, RoutedEventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True");
            try
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO Student (Faculty, Name) VALUES (@Faculty, @Name)";

                command.Parameters.AddWithValue("@Faculty", facultyTextBox.Text);
                command.Parameters.AddWithValue("@Name", nameTextBox.Text);
                //command.Parameters.AddWithValue("@picture", pictureData);

                command.ExecuteNonQuery();

                dataGrid1.UpdateLayout();
                UpdateLayout();
            }
            catch (SqlException ex)
            {
                string errorString = "";
                foreach(SqlError erro in ex.Errors )
                    errorString += erro.ToString() + "\n";
                MessageBox.Show(errorString);
            }
            finally
            {
                connection.Close();
            }
        }

        private void pictureSelect_click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == true)
            {
                string fName = dialog.FileName;
                FileStream stream = new FileStream(fName, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(stream);
                pictureData = br.ReadBytes((int)stream.Length);
            }
        }
    }
}
