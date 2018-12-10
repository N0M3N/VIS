using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Databse
{
    public class StavebniDenikEntity : Entity<StavebniDenikModel>
    {
        protected override string SQL_SELECT => @"
            SELECT 
            SD.[Id], SD.[Datum], SD.[Popis],
                Z.[Id], Z.[Nazev], Z.[Adresa], Z.[Deadline],
                    S.[Nazev],
		            Zak.[Id], Zak.[Jmeno], Zak.[Prijmeni], Zak.[Telefon], Zak.[Login], Zak.[JeZakaznik], Zak.[JeZamestnanec],
		            Zam.[Id], Zam.[Jmeno], Zam.[Prijmeni], Zam.[Telefon], Zam.[Login], Zam.[JeZakaznik], Zam.[JeZamestnanec],
                U.[Id], U.[Jmeno], U.[Prijmeni], U.[Telefon], U.[Login], U.[JeZakaznik], U.[JeZamestnanec]
            FROM [dbo].[StavebniDenik] SD

            JOIN[dbo].[Zakazka] Z ON SD.[Zakazka-Id] = Z.[Id]
            JOIN [dbo].[Stav] S ON Z.[Stav-Id] = S.[Id]
            JOIN[dbo].[Uzivatel] Zam ON Z.[Zamestnanec-Id] = Zam.[Id]
            JOIN[dbo].[Uzivatel] Zak ON Z.[Zakaznik-Id] = Zak.[Id]
            JOIN[dbo].[Uzivatel] U ON SD.[Uzivatel-Id] = U.[Id];";

        protected override string SQL_SELECT_ID => @"
            SELECT 
            SD.[Id], SD.[Datum], SD.[Popis],
                Z.[Id], Z.[Nazev], Z.[Adresa], Z.[Deadline],
                    S.[Nazev],
		            Zak.[Id], Zak.[Jmeno], Zak.[Prijmeni], Zak.[Telefon], Zak.[Login], Zak.[JeZakaznik], Zak.[JeZamestnanec],
		            Zam.[Id], Zam.[Jmeno], Zam.[Prijmeni], Zam.[Telefon], Zam.[Login], Zam.[JeZakaznik], Zam.[JeZamestnanec],
                U.[Id], U.[Jmeno], U.[Prijmeni], U.[Telefon], U.[Login], U.[JeZakaznik], U.[JeZamestnanec]
            FROM [dbo].[StavebniDenik] SD

            JOIN[dbo].[Zakazka] Z ON SD.[Zakazka-Id] = Z.[Id]
            JOIN [dbo].[Stav] S ON Z.[Stav-Id] = S.[Id]
            JOIN[dbo].[Uzivatel] Zam ON Z.[Zamestnanec-Id] = Zam.[Id]
            JOIN[dbo].[Uzivatel] Zak ON Z.[Zakaznik-Id] = Zak.[Id]
            JOIN[dbo].[Uzivatel] U ON SD.[Uzivatel-Id] = U.[Id]

            WHERE SD.[Id] = @p_id;";

        protected override string SQL_INSERT => @"INSERT INTO [dbo].[StavebniDenik]([Zakazka-Id], [Uzivatel-Id], [Datum], [Popis]) VALUES (@p_zakazkaId, @p_uzivatelId, @p_datum, @p_popis);
            SELECT TOP 1
            SD.[Id], SD.[Datum], SD.[Popis],
                Z.[Id], Z.[Nazev], Z.[Adresa], Z.[Deadline],
                    S.[Nazev],
		            Zak.[Id], Zak.[Jmeno], Zak.[Prijmeni], Zak.[Telefon], Zak.[Login], Zak.[JeZakaznik], Zak.[JeZamestnanec],
		            Zam.[Id], Zam.[Jmeno], Zam.[Prijmeni], Zam.[Telefon], Zam.[Login], Zam.[JeZakaznik], Zam.[JeZamestnanec],
                U.[Id], U.[Jmeno], U.[Prijmeni], U.[Telefon], U.[Login], U.[JeZakaznik], U.[JeZamestnanec]
            FROM [dbo].[StavebniDenik] SD

            JOIN[dbo].[Zakazka] Z ON SD.[Zakazka-Id] = Z.[Id]
            JOIN [dbo].[Stav] S ON Z.[Stav-Id] = S.[Id]
            JOIN[dbo].[Uzivatel] Zam ON Z.[Zamestnanec-Id] = Zam.[Id]
            JOIN[dbo].[Uzivatel] Zak ON Z.[Zakaznik-Id] = Zak.[Id]
            JOIN[dbo].[Uzivatel] U ON SD.[Uzivatel-Id] = U.[Id]

            ORDER BY SD.[Id] DESC";

        protected override string SQL_UPDATE => @"UPDATE [dbo].[StavebniDenik] SET [Zakazka-Id] = @p_zakazkaId, [Uzivatel-Id] = @p_uzivatelId, [Datum] = @p_datum, [Popis] = @p_popis WHERE [Id] = @p_id;
            SELECT TOP 1
            SD.[Id], SD.[Datum], SD.[Popis],
                Z.[Id], Z.[Nazev], Z.[Adresa], Z.[Deadline],
                    S.[Nazev],
		            Zak.[Id], Zak.[Jmeno], Zak.[Prijmeni], Zak.[Telefon], Zak.[Login], Zak.[JeZakaznik], Zak.[JeZamestnanec],
		            Zam.[Id], Zam.[Jmeno], Zam.[Prijmeni], Zam.[Telefon], Zam.[Login], Zam.[JeZakaznik], Zam.[JeZamestnanec],
                U.[Id], U.[Jmeno], U.[Prijmeni], U.[Telefon], U.[Login], U.[JeZakaznik], U.[JeZamestnanec]
            FROM[dbo].[StavebniDenik] SD

            JOIN[dbo].[Zakazka] Z ON SD.[Zakazka - Id] = Z.[Id]
            JOIN[dbo].[Stav] S ON Z.[Stav - Id] = S.[Id]
            JOIN[dbo].[Uzivatel] Zam ON Z.[Zamestnanec - Id] = Zam.[Id]
            JOIN[dbo].[Uzivatel] Zak ON Z.[Zakaznik - Id] = Zak.[Id]
            JOIN[dbo].[Uzivatel] U ON SD.[Uzivatel - Id] = U.[Id]

            ORDER BY SD.[Id] DESC;";

        protected override string SQL_DELETE => "DELETE FROM [dbo].[StavebniDenik] WHERE [Id] = @p_id;";

        public override StavebniDenikModel Insert(StavebniDenikModel t)
        {
            var db = new Database();
            db.Connect();

            var command = db.CreateCommand(SQL_INSERT);

            command.Parameters.Add(new SqlParameter("@p_zakazkaId", t.Zakazka.Id));
            command.Parameters.Add(new SqlParameter("@p_uzivatelId", t.Zamestnanec.Id));
            command.Parameters.Add(new SqlParameter("@p_datum", Convert.ToDateTime(t.Datum).Ticks));
            command.Parameters.Add(new SqlParameter("@p_popis", t.Popis));

            var result = db.Select(command);
            return Read(result).FirstOrDefault();
        }

        public override StavebniDenikModel Update(StavebniDenikModel t)
        {
            var db = new Database();
            db.Connect();

            var command = db.CreateCommand(SQL_UPDATE);

            command.Parameters.Add(new SqlParameter("@p_id", t.Id));
            command.Parameters.Add(new SqlParameter("@p_zakazkaId", t.Zakazka.Id));
            command.Parameters.Add(new SqlParameter("@p_uzivatelId", t.Zamestnanec.Id));
            command.Parameters.Add(new SqlParameter("@p_datum", t.Datum.ToString()));
            command.Parameters.Add(new SqlParameter("@p_popis", t.Popis));

            var result = db.Select(command);
            return Read(result).FirstOrDefault();
        }

        protected override IEnumerable<StavebniDenikModel> Read(SqlDataReader reader)
        {
            var denik = new List<StavebniDenikModel>();

            while (reader.Read())
            {
                var i = -1;
                var m = new StavebniDenikModel
                {
                    Id = reader.GetInt32(++i),
                    Datum = new DateTime(reader.GetInt64(++i)).ToShortDateString(),
                    Popis = reader.GetString(++i),
                    Zakazka = new ZakazkaModel
                    {
                        Id = reader.GetInt32(++i),
                        Nazev = reader.GetString(++i),
                        Adresa = reader.GetString(++i),
                        Deadline = new DateTime(reader.GetInt64(++i)).ToShortDateString(),
                        Stav = reader.GetString(++i),
                        Zakaznik = new UzivatelModel
                        {
                            Id = reader.GetInt32(++i),
                            Jmeno = reader.GetString(++i),
                            Prijmeni = reader.GetString(++i),
                            Telefon = reader.GetString(++i),
                            Login = reader.GetString(++i),
                            JeZakaznik = reader.GetBoolean(++i),
                            JeZamestnanec = reader.GetBoolean(++i)
                        },
                        ZodpovednyZamestnanec = new UzivatelModel
                        {
                            Id = reader.GetInt32(++i),
                            Jmeno = reader.GetString(++i),
                            Prijmeni = reader.GetString(++i),
                            Telefon = reader.GetString(++i),
                            Login = reader.GetString(++i),
                            JeZakaznik = reader.GetBoolean(++i),
                            JeZamestnanec = reader.GetBoolean(++i)
                        }
                    },
                    Zamestnanec = new UzivatelModel
                    {
                        Id = reader.GetInt32(++i),
                        Jmeno = reader.GetString(++i),
                        Prijmeni = reader.GetString(++i),
                        Telefon = reader.GetString(++i),
                        Login = reader.GetString(++i),
                        JeZakaznik = reader.GetBoolean(++i),
                        JeZamestnanec = reader.GetBoolean(++i)
                    }
                };
                denik.Add(m);
            }

            return denik;
        }
    }
}
