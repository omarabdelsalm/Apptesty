﻿using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Apptesty
{
    public class Monkey
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string ImageUrl { get; set; }
        public string Url { get; set; }
        public override string ToString()
        {
            return Name;
        }
        
    }
}
