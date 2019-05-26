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

namespace Control1
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        static public readonly RoutedEvent ColorChangedEvent;
        static public DependencyProperty ColorProperty;
        static public DependencyProperty RedProperty;
        static public DependencyProperty GreenProperty;
        static public DependencyProperty BlueProperty;
        
        public event RoutedPropertyChangedEventHandler<Color> ColorChanged
        {
            add { AddHandler(ColorChangedEvent, value); }
            remove { RemoveHandler(ColorChangedEvent, value); }
        }

        static UserControl1()
        {
            CommandManager.RegisterClassCommandBinding(typeof(UserControl1), new CommandBinding(ApplicationCommands.Undo, UndoCommand_Execute, UndoCommand_CanExecute));
            ColorProperty = DependencyProperty.Register("Color", typeof(Color), typeof(UserControl1), new FrameworkPropertyMetadata(Colors.Black, new PropertyChangedCallback(OnColorChanged)));
            RedProperty = DependencyProperty.Register("Red", typeof(byte), typeof(UserControl1), new FrameworkPropertyMetadata(new PropertyChangedCallback(OnColorRGBChanged)));
            GreenProperty = DependencyProperty.Register("Green", typeof(byte), typeof(UserControl1), new FrameworkPropertyMetadata(new PropertyChangedCallback(OnColorRGBChanged)));
            BlueProperty = DependencyProperty.Register("Blue", typeof(byte), typeof(UserControl1), new FrameworkPropertyMetadata(new PropertyChangedCallback(OnColorRGBChanged)));
            ColorChangedEvent = EventManager.RegisterRoutedEvent("ColorChanged", RoutingStrategy.Bubble, typeof(RoutedPropertyChangedEventHandler<Color>), typeof(UserControl1));
        }

        public UserControl1()
        {
            InitializeComponent();
        }

        private Color? previousColor;

        public Color Color
        {
            get => (Color)GetValue(ColorProperty);
            set => SetValue(ColorProperty, value);
        }

        public byte Red
        {
            get => (byte)GetValue(RedProperty);
            set => SetValue(RedProperty, value);
        }

        public byte Green
        {
            get => (byte)GetValue(GreenProperty);
            set => SetValue(GreenProperty, value);
        }

        public byte Blue
        {
            get => (byte)GetValue(BlueProperty);
            set => SetValue(BlueProperty, value);
        }


        static private void OnColorRGBChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            UserControl1 userControl = (UserControl1)sender;
            Color color = userControl.Color;
            if (e.Property == RedProperty)
                color.R = (byte)e.NewValue;
            else if (e.Property == GreenProperty)
                color.G = (byte)e.NewValue;
            else if (e.Property == BlueProperty)
                color.B = (byte)e.NewValue;

            userControl.Color = color;
        }

        static private void OnColorChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            UserControl1 userControl = (UserControl1)sender;
            userControl.previousColor = (Color)e.OldValue;
            Color newColor = (Color)e.NewValue;
            userControl.Red = newColor.R;
            userControl.Green = newColor.G;
            userControl.Blue = newColor.B;
        }

        static private void UndoCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            UserControl1 userControl = (UserControl1)sender;
            e.CanExecute = userControl.previousColor.HasValue;
        }

        static private void UndoCommand_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            UserControl1 userControl = (UserControl1)sender;
            userControl.Color = (Color)userControl.previousColor;
        }
    }
}
