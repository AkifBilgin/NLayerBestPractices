﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerBestPractices.Core.Dtos
{
    public class CustomErrorViewModel
    {
        public List<string> Error { get; set; }= new List<string>();
    }
}