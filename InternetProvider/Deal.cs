using System;
using System.Collections.Generic;

namespace InternetProvider;

public partial class Deal
{
    public int НомерДоговора { get; set; }

    public DateOnly ДатаЗаключения { get; set; }

    public int НомерТарифа { get; set; }

    public DateOnly СрокДействия { get; set; }

    public bool ЦифровоеТв { get; set; }

    public bool АрендаРоутера { get; set; }

    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual Tarrif НомерТарифаNavigation { get; set; } = null!;
}
