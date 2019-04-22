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

namespace _9
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void addUser_clicked(object sender, RoutedEventArgs e)
        {
            var context = new Model1Container();
            var user = new Users()
            {
                Email = emailTextBox.Text,
                Password = passwordTextBox.Password,
                Username = usernameTextBox.Text
            };
            context.Users.Add(user);
            context.SaveChanges();
            emailTextBox.Clear();
            passwordTextBox.Clear();
            usernameTextBox.Clear();
        }

        private void enter_clicked(object sender, RoutedEventArgs e)
        {
            var context = new Model1Container();
            var users = context.Users.Select(p => p).Where(p => p.Email.Equals(useUserNameTextBox.Text) && p.Password.Equals(usePasswordPasswordBox.Password));
            if (users.Count() == 0)
            {
                MessageBox.Show("Error");
            }
            else
            {
                foreach (var user in users)
                {
                    userActiveID.Content = user.Id;
                    userActiveName.Content = user.Username;
                    break;
                }
            }
            useUserNameTextBox.Clear();
            usePasswordPasswordBox.Clear();
            LoadPosts();
        }

        private void LoadPosts()
        {
            var context = new Model1Container();

            postList.Items.Clear();

            if (!(userActiveID.Content is String))
            {
                Users currentUser = null;

                var pontUser = context.Users.Select(p => p).Where(p => p.Id == (int)userActiveID.Content);
                foreach (var iterUser in pontUser)
                {
                    currentUser = iterUser;
                    break;
                }

                var posts = context.Posts.Select(p => p).Where(p => p.User.Id == currentUser.Id);

                foreach(var currentPost in posts)
                {
                    postList.Items.Add(currentPost.Id.ToString() + " " + currentPost.Title);
                }
            }
        }

        private void addPost_clicked(object sender, RoutedEventArgs e)
        {
            var context = new Model1Container();

            if (userActiveID.Content is String)
            {
                MessageBox.Show("No current user");
            }
            else
            {
                Users currentUser = null;

                var pontUser = context.Users.Select(p => p).Where(p => p.Id == (int)userActiveID.Content);
                foreach(var iterUser in pontUser)
                {
                    currentUser = iterUser;
                    break;
                }


                TextRange range = new TextRange(addPostBody.Document.ContentStart, addPostBody.Document.ContentEnd);
                string textContent = range.Text;
                var post = new Posts()
                {
                    Body = addPostTitle.Text,
                    Title = textContent,
                    User = currentUser
                };
                context.Posts.Add(post);
                context.SaveChanges();
                addPostBody.Document.Blocks.Clear();
                addPostTitle.Clear();
            }
            LoadPosts();
        }

        private void selectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (postList.SelectedItem != null)
            {
                int selectedIndex = Int32.Parse(postList.SelectedValue.ToString().Split()[0]);
                var context = new Model1Container();
                Posts post = context.Posts.Find(selectedIndex);
                textContent.Document.Blocks.Clear();
                textContent.AppendText(post.Body);
            }
        }
    }
}
