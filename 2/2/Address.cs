﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2
{
    [Serializable]
    public class Address
    {
        public string City { get; set; }
        public int Index { get; set; }
        public string Street { get; set; }
        public int Home { get; set; }
        public int Apartment { get; set; }
    }
}
