using System;
using System.Collections.Generic;

namespace InternetProvider;

public partial class Tarrif
{
    public int НомерТарифа { get; set; }

    public string Название { get; set; } = null!;

    public int СкоростьМбитС { get; set; }

    public decimal Цена { get; set; }

    public virtual ICollection<Deal> Deals { get; set; } = new List<Deal>();
}
