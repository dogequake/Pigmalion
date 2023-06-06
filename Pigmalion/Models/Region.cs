using System;
using System.Collections.Generic;

namespace Pigmalion.Models;

public partial class Region
{
    public int IdRegion { get; set; }

    public string NameRegion { get; set; } = null!;

    public int Idcountry { get; set; }

    public virtual ICollection<City> Cities { get; } = new List<City>();

    public virtual ICollection<Client> Clients { get; } = new List<Client>();

    public virtual Country IdcountryNavigation { get; set; } = null!;
}
