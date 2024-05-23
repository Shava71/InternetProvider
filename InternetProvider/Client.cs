using System;
using System.Collections.Generic;

namespace InternetProvider;

public partial class Client
{
    public int НомерКлиента { get; set; }

    public string Фамилия { get; set; } = null!;

    public string Имя { get; set; } = null!;

    public string Отчество { get; set; } = null!;

    public string Адрес { get; set; } = null!;

    public string НомерТелефона { get; set; } = null!;

    public string ЭлектроннаяПочта { get; set; } = null!;

    public DateOnly ДатаРождения { get; set; }

    public int НомерДоговора { get; set; }

    public virtual ICollection<Traffic> Traffics { get; set; } = new List<Traffic>();

    public virtual Deal НомерДоговораNavigation { get; set; } = null!;
}
