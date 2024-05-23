using System;
using System.Collections.Generic;

namespace InternetProvider;

public partial class Clientum
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
}
