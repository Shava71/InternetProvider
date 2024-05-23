using System;
using System.Collections.Generic;

namespace InternetProvider;

public partial class Traffic
{
    public int Запись { get; set; }

    public int НомерКлиента { get; set; }

    public DateOnly Дата { get; set; }

    public int ОбъёмМбайт { get; set; }

    public virtual Client НомерКлиентаNavigation { get; set; } = null!;
}
