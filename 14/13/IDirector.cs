using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _13
{
    interface IDirector
    {
        void CreateComplexItem(double x, double y);
        List<UIElement> GetResult();
    }
}
