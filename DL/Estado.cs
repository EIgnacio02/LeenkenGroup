﻿using System;
using System.Collections.Generic;

namespace DL;

public partial class Estado
{
    public int IdEstado { get; set; }

    public string? Estado1 { get; set; }

    public virtual ICollection<Empleado> Empleados { get; } = new List<Empleado>();
}
