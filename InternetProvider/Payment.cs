using System;
using System.Collections.Generic;

namespace InternetProvider;

public partial class Payment
{
    public int НомерПлатежа { get; set; }

    public decimal Сумма { get; set; }

    public bool Статус { get; set; }

    public DateOnly Дата { get; set; }

    public int НомерДоговора { get; set; }

    public virtual Deal НомерДоговораNavigation { get; set; } = null!;
}
