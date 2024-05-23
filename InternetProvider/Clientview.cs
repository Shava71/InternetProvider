using System;
using System.Collections.Generic;

namespace InternetProvider;

public partial class Clientview
{
    public int? НомерКлиента { get; set; }

    public string? Фамилия { get; set; }

    public string? Имя { get; set; }

    public string? Отчество { get; set; }

    public string? Адрес { get; set; }

    public string? НомерТелефона { get; set; }

    public string? ЭлектроннаяПочта { get; set; }

    public DateOnly? ДатаРождения { get; set; }

    public int? НомерДоговора { get; set; }
}
