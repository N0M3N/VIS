using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Databse
{
    public class KalkulaceEntity
    {            
        private readonly string SQL_SELECT_ZAKAZKAID = @"SELECT
            Doch.[Id], Doch.[Datum], Doch.[Prichod], Doch.[Odchod],
                Uziv.[Id], Uziv.[Jmeno], Uziv.[Prijmeni], Uziv.[Login], Uziv.[Telefon], Uziv.[JeZakaznik], Uziv.[JeZamestnanec],
            M.[Sazba]
        FROM [dbo].[Dochazka] Doch

        JOIN [dbo].[Uzivatel] Uziv ON Doch.[Zamestnanec-Id] = Uziv.[Id]
        JOIN[dbo].[Zakazka] Zakaz ON Doch.[Zakazka-Id] = Zakaz.[Id]
        JOIN[dbo].[Stav] S ON Zakaz.[Stav-Id] = S.Id
        JOIN[dbo].[Uzivatel] Zak ON Zakaz.[Zakaznik-Id] = Zak.[Id]
        JOIN[dbo].[Uzivatel] Zodp ON Zakaz.[Zamestnanec-Id] = Zodp.[Id]
        JOIN[dbo].[Mzdy] M ON Uziv.[Id] = M.[Uzivatel-Id] and Zakaz.[Id] = M.[Zakazka-Id]

        WHERE Zakaz.[Id] = @p_id";

        public IEnumerable<DochazkaModel> Kalkulace(int zakazkaId)
        {
            var db = new Database();
            db.Connect();

            var cmd = db.CreateCommand(SQL_SELECT_ZAKAZKAID);
            cmd.Parameters.Add(new SqlParameter("@p_id", zakazkaId));

            var result = db.Select(cmd);
            return Read(result);
        }

        private IEnumerable<DochazkaModel> Read(SqlDataReader reader)
        {
            var list = new List<DochazkaModel>();

            while (reader.Read())
            {
                var i = -1;
                var m = new DochazkaModel
                {
                    Id = reader.GetInt32(++i),
                    Datum = new DateTime(reader.GetInt64(++i)).ToShortDateString(),
                    Prichod = new TimeSpan(reader.GetInt64(++i)),
                    Odchod = new TimeSpan(reader.GetInt64(++i)),
                    Zamestnanec = new UzivatelModel
                    {
                        Id = reader.GetInt32(++i),
                        Jmeno = reader.GetString(++i),
                        Prijmeni = reader.GetString(++i),
                        Telefon = reader.GetString(++i),
                        Login = reader.GetString(++i),
                        JeZakaznik = reader.GetBoolean(++i),
                        JeZamestnanec = reader.GetBoolean(++i)
                    },
                    Sazba = reader.GetInt32(++i)
                };

                list.Add(m);
            }

            return list;
        }
    }
}
