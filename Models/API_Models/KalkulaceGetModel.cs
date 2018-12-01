using System.Linq;

namespace Models.API_Models
{
    public class KalkulaceGetModel
    {
        public MzdoveNakladyGetModel[] MzdoveNaklady { get; set; } = new MzdoveNakladyGetModel[0];
        public double CelkoveMzdy { get; set; } = 0;

        public void Recalculate()
        {
            foreach (var naklady in MzdoveNaklady)
            {
                naklady.Recalculate();
                CelkoveMzdy += naklady.Mzda;
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

        public void Recalculate()
        {
            CelkemHodin = Dochazka.Sum(x => x.OdpracovanychHodin);
            Mzda = CelkemHodin * Sazba;
        }
    }

    public class ZaznamDochazkyGetModel
    {
        public double OdpracovanychHodin { get; set; }
        public string Datum { get; set; }
    }
}
