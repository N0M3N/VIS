using System.Collections.Generic;
using System.Data.SqlClient;
using Models;

namespace Databse
{
    internal class DochazkaEntity : Entity<DochazkaModel>
    {
        protected override string SQL_SELECT => "SELECT [Id], [Zakazka-Id], [Zamestnanec-Id], [Datum], [Prichod], [Odchod] FROM[dbo].[Dochazka];";

        protected override string SQL_SELECT_ID => "SELECT [Id], [Zakazka-Id], [Zamestnanec-Id], [Datum], [Prichod], [Odchod] FROM[dbo].[Dochazka] WHERE [Id] = @p_id;";

        protected override string SQL_INSERT => "INSERT INTO [dbo].[Dochazka]([Zakazka-Id], [Zamestnanec-Id], [Datum], [Prichod], [Odchod]) VALUES (@p_zakazkaId, @p_zamestnanecId, @p_datum, @p_prichod, @p_odchod);";

        protected override string SQL_UPDATE => "UPDATE [dbo].[Dochazka] SET [Zakazka-Id] = @p_zakazkaId, [Zamestnanec-Id] = @p_zamestnanecId, [Datum] = @p_datum, [Prichod] = @p_prichod, [Odchod] = @p_odchod) WHERE [Id] = @p_id;";

        protected override string SQL_DELETE => "DELETE FROM [dbo].[Dochazka] WHERE [Id] = @p_id;";

        public override int Insert(DochazkaModel t)
        {
            var db = new Database();
            db.Connect();

            var command = db.CreateCommand(SQL_INSERT);

            command.Parameters.Add(new SqlParameter("@p_zakazkaId", t.Zakazka.Id));
            command.Parameters.Add(new SqlParameter("@p_zamestnanecId", t.Zamestnanec.Id));
            command.Parameters.Add(new SqlParameter("@p_datum", t.Datum));
            command.Parameters.Add(new SqlParameter("@p_prichod", t.Prichod));
            command.Parameters.Add(new SqlParameter("@p_odchod", t.Odchod));

            return db.ExecuteNonQuery(command);
        }

        public override int Update(DochazkaModel t)
        {
            var db = new Database();
            db.Connect();

            var command = db.CreateCommand(SQL_UPDATE);

            command.Parameters.Add(new SqlParameter("@p_zakazkaId", t.Zakazka.Id));
            command.Parameters.Add(new SqlParameter("@p_zamestnanecId", t.Zamestnanec.Id));
            command.Parameters.Add(new SqlParameter("@p_datum", t.Datum));
            command.Parameters.Add(new SqlParameter("@p_prichod", t.Prichod));
            command.Parameters.Add(new SqlParameter("@p_odchod", t.Odchod));
            command.Parameters.Add(new SqlParameter("@p_id", t.Id));

            return db.ExecuteNonQuery(command);
        }

        protected override IEnumerable<DochazkaModel> Read(SqlDataReader reader)
        {
            // TO DO 
            var dochazka = new List<DochazkaModel>();
            while (reader.Read())
            {
                var i = -1;
                var d = new DochazkaModel
                {
                    Id = reader.GetInt32(++i),
                };

                var z = new ZakazkaModel
                {
                    Id = reader.GetInt32(++i),
                };

                var zakaznik = new UzivatelModel
                {
                    Id = reader.GetInt32(++i),
                    Jmeno = reader.GetString(++i),
                    Prijmeni = reader.GetString(++i),
                    Telefon = reader.GetString(++i),
                    Login = reader.GetString(++i),
                    //Heslo = reader.GetString(++i),
                    JeZakaznik = reader.GetBoolean(++i),
                    JeZamestananec = reader.GetBoolean(++i),
                };
                z.Zakaznik = zakaznik;

                var zamestnanec = new UzivatelModel
                {
                    Id = reader.GetInt32(++i),
                    Jmeno = reader.GetString(++i),
                    Prijmeni = reader.GetString(++i),
                    Telefon = reader.GetString(++i),
                    Login = reader.GetString(++i),
                    //Heslo = reader.GetString(++i),
                    JeZakaznik = reader.GetBoolean(++i),
                    JeZamestananec = reader.GetBoolean(++i),
                };
                z.ZodpovednyZamestnanec = zamestnanec;

                var stav = new StavModel
                {
                    Id = reader.GetInt32(++i),
                    Nazev = reader.GetString(++i)
                };
                z.Stav = stav;
                z.Adresa = reader.GetString(++i);
                z.Deadline = reader.GetDateTime(++i);
                d.Zakazka = z;

                var u = new UzivatelModel
                {
                    Id = reader.GetInt32(++i),
                    Jmeno = reader.GetString(++i),
                    Prijmeni = reader.GetString(++i),
                    Telefon = reader.GetString(++i),
                    Login = reader.GetString(++i),
                    //Heslo = reader.GetString(++i),
                    JeZakaznik = reader.GetBoolean(++i),
                    JeZamestananec = reader.GetBoolean(++i),
                };

                d.Zamestnanec = u;
                d.Datum = reader.GetDateTime(++i);
                d.Prichod = reader.GetTimeSpan(++i);
                d.Odchod = reader.GetTimeSpan(++i);


                dochazka.Add(d);
            }
            return dochazka;
        }
    }
}
