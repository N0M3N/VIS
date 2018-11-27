using System;
using System.Collections.Generic;
using System.Linq;

namespace Models.API_Models
{
    public class KalkulaceGetModel
    {
        public ZakazkaModel Zakazka { get; set; }
        public MzdoveNakladyGetModel[] MzdoveNaklady { get; set; } = new MzdoveNakladyGetModel[0];
        public double CelkoveMzdy { get; set; }

        public KalkulaceGetModel(ZakazkaModel zakazka, IEnumerable<DochazkaModel> dochazka, IEnumerable<MzdaModel> mzdy)
        {
            Zakazka = zakazka;
            if (dochazka.Any() && mzdy.Any())
            {
                var firstDate = dochazka.Min(x => Convert.ToDateTime(x.Datum));
                var lastDate = dochazka.Max(x => Convert.ToDateTime(x.Datum));
                var dates = Enumerable.Range(0, 1 + lastDate.Subtract(firstDate).Days).Select(x => firstDate.AddDays(x));
                MzdoveNaklady = mzdy.Select(x => new MzdoveNakladyGetModel(dates, dochazka.Where(y => y.Zamestnanec == x.Zamestnanec), x)).ToArray();
                CelkoveMzdy = MzdoveNaklady.Sum(x => x.Mzda);
            }
        }
    }

    public class MzdoveNakladyGetModel
    {
        public UzivatelModel Zamestnanec { get; set; }
        public ZaznamDochazkyGetModel[] Dochazka { get; set; } = new ZaznamDochazkyGetModel[0];
        public int Sazba { get; set; }
        public double CelkemHodin { get; set; }
        public double Mzda { get; set; }

        public MzdoveNakladyGetModel(IEnumerable<DateTime> dates, IEnumerable<DochazkaModel> dochazka, MzdaModel mzda)
        {
            Zamestnanec = mzda.Zamestnanec;
            Dochazka = dates
                .Select(y => new ZaznamDochazkyGetModel(y.ToShortDateString(),
                (dochazka.FirstOrDefault(x => Convert.ToDateTime(x.Datum) == y).Odchod - dochazka.FirstOrDefault(x => Convert.ToDateTime(x.Datum) == y).Prichod).TotalHours)).ToArray();
            Sazba = mzda.Sazba;
            CelkemHodin = Dochazka.Sum(x => x.OdpracovanychHodin);
            Mzda = CelkemHodin * Sazba;
        }
    }

    public class ZaznamDochazkyGetModel
    {
        public double OdpracovanychHodin { get; set; }
        public string Datum { get; set; }

        public ZaznamDochazkyGetModel(string datum, double hodin)
        {
            Datum = datum;
            OdpracovanychHodin = hodin;
        }
    }
}
