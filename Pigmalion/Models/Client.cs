using System;
using System.Collections.Generic;

namespace Pigmalion.Models;

public partial class Client
{
    public int IdClient { get; set; }

    public string Phonenum { get; set; } = null!;

    public DateTime DateCreation { get; set; }

    public string Appeal { get; set; } = null!;

    public int Idcountryclient { get; set; }

    public int Idregionclient { get; set; }

    public int Idcityclient { get; set; }

    public int Iddirectionclient { get; set; }

    public virtual City IdcityclientNavigation { get; set; } = null!;

    public virtual Country IdcountryclientNavigation { get; set; } = null!;

    public virtual Direction IddirectionclientNavigation { get; set; } = null!;

    public virtual Region IdregionclientNavigation { get; set; } = null!;
}
