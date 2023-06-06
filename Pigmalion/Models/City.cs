using System;
using System.Collections.Generic;

namespace Pigmalion.Models;

public partial class City
{
    public int IdCity { get; set; }

    public string NameCity { get; set; } = null!;

    public int Idregion { get; set; }

    public virtual ICollection<Client> Clients { get; } = new List<Client>();

    public virtual Region IdregionNavigation { get; set; } = null!;
}
