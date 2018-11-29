using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Models;

namespace Databse
{
    public class ZakazkaEntity : Entity<ZakazkaModel>
    {
        protected override string SQL_SELECT => @"SELECT
            Z.[Id], Z.[Nazev], Z.[Adresa], Z.[Deadline],
	            S.[Nazev],
	            Zak.[Id], Zak.[Jmeno], Zak.[Prijmeni], Zak.[Telefon], Zak.[Login], Zak.[JeZakaznik], Zak.[JeZamestnanec],
	            Zam.[Id], Zam.[Jmeno], Zam.[Prijmeni], Zam.[Telefon], Zam.[Login], Zam.[JeZakaznik], Zam.[JeZamestnanec]
            FROM [dbo].[Zakazka] Z

            JOIN [dbo].[Stav] S ON Z.[Stav-Id] = S.[Id]
            JOIN [dbo].[Uzivatel] Zam ON Z.[Zamestnanec-Id] = Zam.[Id]
            JOIN [dbo].[Uzivatel] Zak ON Z.[Zakaznik-Id] = Zak.[Id];";

        protected override string SQL_SELECT_ID => @"SELECT
            Z.[Id], Z.[Nazev], Z.[Adresa], Z.[Deadline],
	            S.[Nazev],
	            Zak.[Id], Zak.[Jmeno], Zak.[Prijmeni], Zak.[Telefon], Zak.[Login], Zak.[JeZakaznik], Zak.[JeZamestnanec],
	            Zam.[Id], Zam.[Jmeno], Zam.[Prijmeni], Zam.[Telefon], Zam.[Login], Zam.[JeZakaznik], Zam.[JeZamestnanec]
            FROM[dbo].[Zakazka] Z

            JOIN[dbo].[Stav] S ON Z.[Stav-Id] = S.[Id]
            JOIN[dbo].[Uzivatel] Zam ON Z.[Zamestnanec-Id] = Zam.[Id]
            JOIN[dbo].[Uzivatel] Zak ON Z.[Zakaznik-Id] = Zak.[Id]

            WHER Z.[Id] = @p_id;";

        protected override string SQL_INSERT => "INSERT INTO [dbo].[Zakazka] ([Nazev], [Zakaznik-Id], [Zamestnanec-Id], [Stav-Id], [Adresa], [Deadline]) VALUES (@p_name, @p_zakaznikId, @p_zamestnanecId, @p_stavId, @p_adresa, @p_deadline); SELECT SCOPE_IDENTITY(); " +
            "SELECT TOP 1 [Id], [Nazev], [Zakaznik-Id], [Zamestnanec-Id], [Stav-Id], [Adresa], [Deadline] FROM [dbo].[Zakazka] ORDER BY [Id] DESC;";

        protected override string SQL_UPDATE => "UPDATE [dbo].[Zakazka] SET [Nazev] = @p_name, [Zakaznik-Id] = @p_zakaznikId, [UZamestnanec-Id] = @p_zamestnanecId, [Stav-Id] = @p_stavId, [Adresa] = @p_adresa, [Deadline] = @p_deadline WHERE [Id] = @p_Id; " +
            "SELECT TOP 1 [Id], [Nazev], [Zakaznik-Id], [Zamestnanec-Id], [Stav-Id], [Adresa], [Deadline] FROM [dbo].[Zakazka] ORDER BY [Id] DESC;";

        protected override string SQL_DELETE => "DELETE FROM [dbo].[Zakazka] WHERE [Id] = @p_id;";

        public override ZakazkaModel Insert(ZakazkaModel t)
        {
            var db = new Database();
            db.Connect();

            var command = db.CreateCommand(SQL_INSERT);

            command.Parameters.Add(new SqlParameter("@p_name", t.Nazev));
            command.Parameters.Add(new SqlParameter("@p_zakaznikId", t.Zakaznik.Id));
            command.Parameters.Add(new SqlParameter("@p_zamestnanecId", t.ZodpovednyZamestnanec.Id));
            command.Parameters.Add(new SqlParameter("@p_stavId", t.Stav));
            command.Parameters.Add(new SqlParameter("@p_adresa", t.Adresa));
            command.Parameters.Add(new SqlParameter("@p_deadline", Convert.ToDateTime(t.Deadline).Ticks));

            var result = db.Select(command);
            return Read(result).FirstOrDefault();
        }

        public override ZakazkaModel Update(ZakazkaModel t)
        {
            var db = new Database();
            db.Connect();

            var command = db.CreateCommand(SQL_UPDATE);
            command.Parameters.Add(new SqlParameter("@p_zakaznikId", t.Zakaznik.Id));
            command.Parameters.Add(new SqlParameter("@p_name", t.Nazev));
            command.Parameters.Add(new SqlParameter("@p_zamestnanecId", t.ZodpovednyZamestnanec.Id));
            command.Parameters.Add(new SqlParameter("@p_stavId", t.Stav));
            command.Parameters.Add(new SqlParameter("@p_adresa", t.Adresa));
            command.Parameters.Add(new SqlParameter("@p_deadline", Convert.ToDateTime(t.Deadline).Ticks));
            command.Parameters.Add(new SqlParameter("@p_Id", t.Id));

            var result = db.Select(command);
            return Read(result).FirstOrDefault();
        }

        protected override IEnumerable<ZakazkaModel> Read(SqlDataReader reader)
        {
            var zakazky = new List<ZakazkaModel>();

            while (reader.Read())
            {
                var i = -1;
                var z = new ZakazkaModel
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
                };
                zakazky.Add(z);
            }
            return zakazky;
        }
    }
}
