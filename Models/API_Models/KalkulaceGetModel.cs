using System.Collections.Generic;
using System.Linq;

namespace Models.API_Models
{
    public class KalkulaceGetModel
    {
        public MzdoveNakladyGetModel[] MzdoveNaklady { get; set; } = new MzdoveNakladyGetModel[0];
        public double CelkoveMzdy { get; set; }

        public KalkulaceGetModel(IEnumerable<MzdoveNakladyGetModel> naklady)
        {
            MzdoveNaklady = naklady.ToArray();

            CelkoveMzdy = MzdoveNaklady.Sum(x => x.Mzda);
        }
    }

    public class MzdoveNakladyGetModel
    {
        public UzivatelModel Zamestnanec { get; set; }
        public ZaznamDochazkyGetModel[] Dochazka { get; set; } = new ZaznamDochazkyGetModel[0];
        public int Sazba { get; set; }
        public double CelkemHodin { get; set; }
        public double Mzda { get; set; }

        public MzdoveNakladyGetModel(UzivatelModel zamestnanec, IEnumerable<ZaznamDochazkyGetModel> zaznamyDochazky, int sazba)
        {
            Zamestnanec = zamestnanec;
            Dochazka = zaznamyDochazky.ToArray();
            Sazba = sazba;

            CelkemHodin = Dochazka.Sum(x => x.OdpracovanychHodin);
            Mzda = CelkemHodin * Sazba;
        }
    }

    public class ZaznamDochazkyGetModel
    {
        public double OdpracovanychHodin { get; set; }
        public string Datum { get; set; }

        public ZaznamDochazkyGetModel(string datum, double odpracovanychHodin)
        {
            Datum = datum;
            OdpracovanychHodin = odpracovanychHodin;
        }
    }
}
