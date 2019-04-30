using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _13
{
    interface IBuilder
    {
        UIElement CreateBackgroundItem();
        UIElement CreateForegroundItem();
    }
}
