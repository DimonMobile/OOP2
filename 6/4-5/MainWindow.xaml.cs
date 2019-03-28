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
using System.IO;
using System.Windows.Forms;
using System.Drawing.Text;
using System.Drawing;
using Microsoft.Win32;

namespace _4_5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            if (File.Exists("lang"))
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("ru-RU");
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("ru-RU");
            }
            InitializeComponent();
            Mouse.OverrideCursor = ((FrameworkElement)this.Resources["KinectCursor"]).Cursor;
        }

        private void openFile(string fileName, bool append = true)
        {
            TextRange range = new TextRange(textBox.Document.ContentStart, textBox.Document.ContentEnd);
            FileStream stream = new FileStream(fileName, FileMode.Open);
            range.Load(stream, System.Windows.DataFormats.Rtf);
            stream.Close();
            fileNameTextBlock.Text = fileName;

            if (append)
            {
                System.Windows.Controls.MenuItem newMenuItem = new System.Windows.Controls.MenuItem();
                newMenuItem.Header = fileName;
                newMenuItem.Click += (sender, args) => { openFile(fileName, false); };
                fileMenuItem.Items.Add(newMenuItem);
            }
        }

        private void OpenFile_click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                openFile(openFileDialog.FileName);
            }
        }

        private void SaveFile_click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
            {
                TextRange range = new TextRange(textBox.Document.ContentStart, textBox.Document.ContentEnd);
                FileStream stream = new FileStream(saveFileDialog.FileName, FileMode.Create);
                range.Save(stream, System.Windows.DataFormats.Rtf);
                stream.Close();
                fileNameTextBlock.Text = saveFileDialog.FileName;
            }
        }

        private void NewFile_click(object sender, RoutedEventArgs e)
        {
            textBox.Document.Blocks.Clear();
        }

        private void FontEdit_click(object sender, RoutedEventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            if (fontDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                TextSelection selection = textBox.Selection;
                if (selection != null && !selection.IsEmpty)
                {
                    selection.ApplyPropertyValue(TextElement.FontFamilyProperty, fontDialog.Font.FontFamily.Name);
                    selection.ApplyPropertyValue(TextElement.FontSizeProperty, fontDialog.Font.SizeInPoints.ToString());
                }
            }
        }

        private void ColorEdit_click(object sender, RoutedEventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                TextSelection selection = textBox.Selection;
                if (selection != null && !selection.IsEmpty)
                {
                    selection.ApplyPropertyValue(TextElement.ForegroundProperty, colorDialog.Color.Name.ToString());
                }
            }
        }

        private void CutEdit_click(object sender, RoutedEventArgs e)
        {
            textBox.Cut();
        }

        private void CopyEdit_click(object sender, RoutedEventArgs e)
        {
            textBox.Copy();
        }

        private void PasteEdit_click(object sender, RoutedEventArgs e)
        {
            textBox.Paste();
        }

        private void TextBox_textChanged(object sender, TextChangedEventArgs e)
        {
            TextRange range = new TextRange(textBox.Document.ContentStart, textBox.Document.ContentEnd);
            CharactersCountTextBlock.Text = range.Text.Length.ToString();
        }

        private void OpenExit_click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void comboBox_click(object sender, RoutedEventArgs e)
        {
            TextSelection selection = textBox.Selection;
            if (selection != null && !selection.IsEmpty)
            {
                selection.ApplyPropertyValue(TextElement.FontFamilyProperty, comboBox.Text);
            }
        }

        private void slider_changed(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (textBox == null)
                return;
            TextSelection selection = textBox.Selection;
            if (selection != null && !selection.IsEmpty)
            {
                selection.ApplyPropertyValue(TextElement.FontSizeProperty, slider.Value.ToString());
            }
        }

        private void bold_click(object sender, RoutedEventArgs e)
        {
            TextSelection selection = textBox.Selection;
            if (selection != null && !selection.IsEmpty)
            {
                selection.ApplyPropertyValue(TextElement.FontWeightProperty, FontWeights.Bold);
            }
        }

        private void italic_click(object sender, RoutedEventArgs e)
        {
            TextSelection selection = textBox.Selection;
            if (selection != null && !selection.IsEmpty)
            {
                selection.ApplyPropertyValue(TextElement.FontStyleProperty, FontStyles.Italic);
            }
        }

        private void underline_click(object sender, RoutedEventArgs e)
        {
            TextSelection selection = textBox.Selection;
            if (selection != null && !selection.IsEmpty)
            {
                selection.ApplyPropertyValue(Inline.TextDecorationsProperty, TextDecorations.Underline);
            }
        }

        private void localize_click(object sender, RoutedEventArgs e)
        {
            if (File.Exists("lang"))
            {
                File.Delete("lang");
            }
            else
            {
                File.Create("lang");
            }
        }
    }
}
