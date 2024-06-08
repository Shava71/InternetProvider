using System;

namespace InternetProvider.Models
{
    public class TariffSelectionViewModel //Для Task5
    {
        public int SelectedTariffId { get; set; }
        public List<Tarrif> Tariffs { get; set; } = new List<Tarrif>();
        public long TotalClients { get; set; }
    }

    //public class AveragePriceViewModel //Для Task6
    //{
    //    public decimal AveragePrice { get; set; }
    //}
    public class ClientViewTechno
    {
        public int НомерКлиента { get; set; }
        public string Фамилия { get; set; }
        public string Имя { get; set; }
        public string Отчество { get; set; }
        public string Адрес { get; set; }
        public string НомерТелефона { get; set; }
        public string ЭлектроннаяПочта { get; set; }
        public DateOnly ДатаРождения { get; set; }
        public int НомерДоговора { get; set; }
        public int НомерТарифа { get; set; }
    }

}

