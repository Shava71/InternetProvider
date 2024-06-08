using System;

namespace InternetProvider.Models
{
    public class TariffSelectionViewModel
    {
        public int SelectedTariffId { get; set; }
        public List<Tarrif> Tariffs { get; set; } = new List<Tarrif>();
        public long TotalClients { get; set; }
    }
}

