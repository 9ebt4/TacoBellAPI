﻿using System;
using System.Collections.Generic;

namespace Taco_Bell_API.Models;

public partial class Taco
{
    private decimal cost;

    

    public int Id { get; set; }

    public string? Name { get; set; }

    public float? Cost { get; set; }

    public bool? SoftShell { get; set; }

    public bool? Dorito { get; set; }
    
}