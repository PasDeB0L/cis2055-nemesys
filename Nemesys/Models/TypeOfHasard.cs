﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nemesys.Models
{
    public class TypeOfHasard 
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //Collection navigation property
        public List<Report> Reports { get; set; }

        //Collection navigation property
        public List<Investigation> Investigations { get; set; }
    }
}
