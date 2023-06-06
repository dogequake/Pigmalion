using System;
using System.Collections.Generic;

namespace Pigmalion.Models;

public partial class Country
{
    public int IdCountry { get; set; }

    public string NameCountry { get; set; } = null!;

    public virtual ICollection<Client> Clients { get; } = new List<Client>();

    public virtual ICollection<Region> Regions { get; } = new List<Region>();
}
