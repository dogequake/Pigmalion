using System;
using System.Collections.Generic;

namespace Pigmalion.Models;

public partial class Direction
{
    public int IdDirection { get; set; }

    public string NameDirection { get; set; } = null!;

    public virtual ICollection<Client> Clients { get; } = new List<Client>();
}
