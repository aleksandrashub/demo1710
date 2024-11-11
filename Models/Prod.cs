using Avalonia.Media;
using Avalonia.Media.Imaging;
using System;
using System.Collections.Generic;

namespace demo1710.Models;

public partial class Prod
{
    public long IdProd { get; set; }

    public string? NameProd { get; set; }

    public long? IdEdIzm { get; set; }

    public int? Cost { get; set; }

    public float? MaxDisc { get; set; }

    public long? IdManuf { get; set; }

    public long? IdCust { get; set; }

    public long? IdCateg { get; set; }

    public float? CurrDisc { get; set; }

    public long? QuanSkl { get; set; }

    public string? Descr { get; set; }

    public string? Articul { get; set; }

    public string? Image { get; set; }

    public virtual Category? IdCategNavigation { get; set; }

    public virtual Customer? IdCustNavigation { get; set; }

    public virtual EdIzm? IdEdIzmNavigation { get; set; }

    public virtual Manufacturer? IdManufNavigation { get; set; }

    public virtual ICollection<ZakazProd> ZakazProds { get; set; } = new List<ZakazProd>();
    public string defaultPic = "picture.png";
    public Bitmap? bitmap => Image != null ? new Bitmap($@"Assets\\{Image}") : new Bitmap($@"Assets\\{defaultPic}");
    public string? color => CurrDisc > 15
       ?  "#7fff00"
       : "White";
}
