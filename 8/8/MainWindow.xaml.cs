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
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True");
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT Distinct TABLE_NAME FROM information_schema.TABLES";
            SqlDataReader reader = command.ExecuteReader();

            bool facExists = false;
            bool studExists = false;

            while (reader.Read())
            {
                string currentTableName = (string)reader.GetValue(0);
                if (currentTableName == "Faculty")
                    facExists = true;
                else if (currentTableName == "Student")
                    studExists = true;
            }
            reader.Close();

            if (!facExists)
            {
                MessageBox.Show("Faculty table crated");
                command = connection.CreateCommand();
                command.CommandText = "CREATE TABLE [dbo].[Faculty] ([ShortName] VARCHAR(10) NOT NULL,[LongName]  VARCHAR(50) NOT NULL, PRIMARY KEY CLUSTERED([ShortName] ASC))";
                command.ExecuteNonQuery();
            }

            if (!studExists)
            {
                MessageBox.Show("Student table crated");
                command = connection.CreateCommand();
                command.CommandText = "CREATE TABLE [dbo].[Student] ([Id]      INT IDENTITY(1, 1) NOT NULL,[Faculty] VARCHAR(10)     NOT NULL,[Name]    VARCHAR(50)     NOT NULL,[Picture] VARBINARY(8000) NULL, CONSTRAINT[FK_Faculty] FOREIGN KEY([Faculty]) REFERENCES[dbo].[Faculty]([ShortName]))";
                command.ExecuteNonQuery();
            }

            connection.Close();
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
            FillTablesData();
        }

        private void addStudent_onClick(object sender, RoutedEventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True");
            try
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO Student (Faculty, Name, Picture) VALUES (@Faculty, @Name, @Picture)";

                command.Parameters.AddWithValue("@Faculty", facultyTextBox.Text);
                command.Parameters.AddWithValue("@Name", nameTextBox.Text);
                command.Parameters.AddWithValue("@Picture", pictureData);

                command.ExecuteNonQuery();
                FillTablesData();
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
        
        private void FillTablesData()
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True"))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Student", connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable("Student");
                adapter.Fill(dt);
                dataGrid1.ItemsSource = dt.DefaultView;
            }

            using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True"))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Faculty", connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable("Faculty");
                adapter.Fill(dt);
                dataGrid2.ItemsSource = dt.DefaultView;
            }
        }

        private void dg_onSelected(object sender, RoutedEventArgs e)
        {
            if (dataGrid1.SelectedIndex != -1)
            {
                int id = Int32.Parse((dataGrid1.SelectedItems[0] as DataRowView).Row["Id"].ToString());
                using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True"))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand($"SELECT Picture FROM Student WHERE Id={id}", connection);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        byte[] buf = new byte[8000];
                        if (!reader.IsDBNull(0) || true)
                        {
                            long readed = reader.GetBytes(0, 0, buf, 0, 8000);
                            using (var ms = new MemoryStream(buf, 0, (int)readed))
                            {
                                BitmapImage bi = new BitmapImage();
                                bi.BeginInit();
                                bi.CreateOptions = BitmapCreateOptions.None;
                                bi.CacheOption = BitmapCacheOption.Default;
                                bi.StreamSource = ms;
                                bi.EndInit();
                                bi.Freeze();
                                BitmapSource source = BitmapSource.Create(2, 2, bi.DpiX, bi.DpiY, PixelFormats.Indexed8, BitmapPalettes.Gray256, buf, 2);

                                imageView.Source = source;
                            }
                        }
                    }
                }
            }
        }

        private void remove_onClick(object sender, RoutedEventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True");
            try
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = $"DELETE FROM Student WHERE Id={studentIdTextBox.Text}";
                command.ExecuteNonQuery();
                FillTablesData();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
