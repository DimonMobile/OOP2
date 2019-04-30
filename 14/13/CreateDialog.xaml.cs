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
using System.Windows.Shapes;

namespace _13
{
    /// <summary>
    /// Interaction logic for CreateDialog.xaml
    /// </summary>
    public partial class CreateDialog : Window
    {
        public List<UIElement> Elements { get; set; }

        public CreateDialog()
        {
            InitializeComponent();
            Elements = new List<UIElement>();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void createBtn_clicked(object sender, RoutedEventArgs e)
        {
            Elements.Clear();
            AbstractFactory factory;
            if (rectRadioButton.IsChecked == true)
                factory = new RectFactoryDecorator(new RectangleFactory());
            else
                factory = new SquareFactory();

            for(int i = 0; i < countSlider.Value; ++i)
            {
                UIElement element;
                if (redRadioButton.IsChecked == true)
                    element = factory.CreateRed();
                else
                    element = factory.CreateBlue();
                Elements.Add(element);
            }
            Close();
        }
    }
}
