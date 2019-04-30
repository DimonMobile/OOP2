using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows;

namespace _13
{
    abstract class AbstractFactory
    {
        public abstract UIElement CreateRed();
        public abstract UIElement CreateBlue();
    }
}
