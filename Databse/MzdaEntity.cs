using System.Collections.Generic;
using System.Data.SqlClient;
using Models;

namespace Databse
{
    public class MzdaEntity : Entity<MzdaModel>
    {
        protected override string SQL_SELECT => "SELECT [Id], [Uzivatel-Id], [Zakazka-Id], [Sazba] FROM [dbo].[Mzdy];";

        protected override string SQL_SELECT_ID => "SELECT [Id], [Uzivatel-Id], [Zakazka-Id], [Sazba] FROM [dbo].[Mzdy] WHERE [Id] = @p_id;";

        protected override string SQL_INSERT => "INSERT INTO[dbo].[Mzdy]([Uzivatel-Id], [Zakazka-Id], [Sazba]) VALUES(@p_uzivatelId, @p_zakazkaId, @p_sazba);";

        protected override string SQL_UPDATE => "UPDATE [dbo].[Mzdy] SET [Uzivatel-Id] = @p_uzivatelId, [Zakazka-Id] = @p_zakazkaId, [Sazba] = @p_sazba WHERE [Id] = @p_id;";

        protected override string SQL_DELETE => "DELETE FROM [dbo].[Mzdy] WHERE [Id] = @p_id;";

        public override int Insert(MzdaModel t)
        {
            var db = new Database();
            db.Connect();

            var command = db.CreateCommand(SQL_INSERT);
            command.Parameters.Add(new SqlParameter("@p_uzivatelId", t.Zamestnanec.Id));
            command.Parameters.Add(new SqlParameter("@p_zakazkaId", t.Zakazka.Id));
            command.Parameters.Add(new SqlParameter("@p_sazba", t.Sazba));

            return db.ExecuteNonQuery(command);
        }

        public override int Update(MzdaModel t)
        {
            var db = new Database();
            db.Connect();

            var command = db.CreateCommand(SQL_UPDATE);
            command.Parameters.Add(new SqlParameter("@p_uzivatelId", t.Zamestnanec.Id));
            command.Parameters.Add(new SqlParameter("@p_zakazkaId", t.Zakazka.Id));
            command.Parameters.Add(new SqlParameter("@p_sazba", t.Sazba));
            command.Parameters.Add(new SqlParameter("@p_id", t.Id));
            return db.ExecuteNonQuery(command);
        }

        protected override IEnumerable<MzdaModel> Read(SqlDataReader reader)
        {
            var mzdy = new List<MzdaModel>();
            while (reader.Read())
            {
                var i = -1;
                var m = new MzdaModel
                {
                    Id = reader.GetInt32(++i),
                };


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
                m.Zamestnanec = u;


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

                m.Zakazka = z;
                m.Sazba = reader.GetInt32(++i);

                mzdy.Add(m);
            }

            return mzdy;
        }
    }
}
