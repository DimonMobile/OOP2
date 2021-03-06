﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            var user = new Users()
            {
                Email = emailTextBox.Text,
                Password = passwordTextBox.Password,
                Username = usernameTextBox.Text
            };

            using (DBController controller = new DBController())
            {
                controller.UserRepository.Add(user);
            }
            emailTextBox.Clear();
            passwordTextBox.Clear();
            usernameTextBox.Clear();
        }

        private void enter_clicked(object sender, RoutedEventArgs e)
        {
            using (DBController controller = new DBController())
            {
                var users = controller.UserRepository.Get(p => p.Email.Equals(useUserNameTextBox.Text) && p.Password.Equals(usePasswordPasswordBox.Password));
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
            }
            useUserNameTextBox.Clear();
            usePasswordPasswordBox.Clear();
            LoadPosts();
        }

        private void LoadPosts()
        {

            postList.Items.Clear();

            if (!(userActiveID.Content is String))
            {
                Users currentUser = null;

                using (DBController controller = new DBController())
                {
                    var pontUser = controller.UserRepository.Get(p => p.Id == (int)userActiveID.Content);
                    foreach (var iterUser in pontUser)
                    {
                        currentUser = iterUser;
                        break;
                    }

                    var posts = controller.PostRepository.Get(p => p.User.Id == currentUser.Id);
                    foreach (var currentPost in posts)
                    {
                        postList.Items.Add(currentPost.Id.ToString() + " " + currentPost.Title);
                    }
                }
            }
        }

        private void addPost_clicked(object sender, RoutedEventArgs e)
        {
            if (userActiveID.Content is String)
            {
                MessageBox.Show("No current user");
            }
            else
            {
                Users currentUser = null;

                using (DBController controller = new DBController())
                {
                    var pontUser = controller.UserRepository.Get(p => p.Id == (int)userActiveID.Content);
                    foreach (var iterUser in pontUser)
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
                    controller.PostRepository.Add(post);
                }
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

        private void onClick(object sender, RoutedEventArgs e)
        {
            if (postList.SelectedItem != null)
            {
                int selectedIndex = Int32.Parse(postList.SelectedValue.ToString().Split()[0]);
                var context = new Model1Container();
                Posts post = context.Posts.Find(selectedIndex);
                
                TextRange range = new TextRange(textContent.Document.ContentStart, textContent.Document.ContentEnd);
                post.Body = range.Text;
                context.SaveChanges();
            }
        }

        private void deleteClicked(object sender, RoutedEventArgs e)
        {
            if (postList.SelectedItem != null)
            {
                int selectedIndex = Int32.Parse(postList.SelectedValue.ToString().Split()[0]);
                var context = new Model1Container();
                Posts post = context.Posts.Find(selectedIndex);
                context.Posts.Remove(post);
                context.SaveChanges();

                using (DBController controller = new DBController())
                {
                    Users currentUser = null;
                    var pontUser = controller.UserRepository.Get(p => p.Id == (int)userActiveID. Content);
                    foreach (var iterUser in pontUser)
                    {
                        currentUser = iterUser;
                        break;
                    }
                    postList.Items.Clear();
                    var posts = controller.PostRepository.Get(p => p.User.Id == currentUser.Id);
                    foreach (var currentPost in posts)
                    {
                        postList.Items.Add(currentPost.Id.ToString() + " " + currentPost.Title);
                    }
                }
            }
        }

        private void transactionClick(object sender, RoutedEventArgs e)
        {
            using (var context = new Model1Container())
            {
                using (DbContextTransaction transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Users user1 = new Users()
                        {
                            Email = "user1",
                            Password = "test",
                            Username = "test"
                        };

                        Users user2 = new Users()
                        {
                            Email = "user2",
                            Password = "test",
                            Username = "test"
                        };

                        context.Users.Add(user1);
                        context.Users.Add(user2);
                        context.SaveChanges();
                        transaction.Commit();   

                    }
                    catch
                    {
                        transaction.Rollback();
                    }
                }
            }
        }
    }
}
