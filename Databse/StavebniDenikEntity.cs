using System.Collections.Generic;
using System.Data.SqlClient;
using Models;

namespace Databse
{
    public class StavebniDenikEntity : Entity<StavebniDenikModel>
    {
        protected override string SQL_SELECT => "SELECT [Id], [Zakazka-Id], [Uzivatel-Id], [Datum], [Popis] FROM [dbo].[StavebniDenik];";

        protected override string SQL_SELECT_ID => "SELECT [Id], [Zakazka-Id], [Uzivatel-Id], [Datum], [Popis] FROM [dbo].[StavebniDenik] WHERE [Id] = @p_id;";

        protected override string SQL_INSERT => "INSERT INTO [dbo].[StavebniDenik]([Zakazka-Id], [Uzivatel-Id], [Datum], [Popis]) VALUES (@p_zakazkaId, @p_uzivatelId, @p_datum, @p_popis)";

        protected override string SQL_UPDATE => "UPDATE [dbo].[StavebniDenik] SET [Zakazka-Id] = @p_zakazkaId, [Uzivatel-Id] = @p_uzivatelId, [Datum] = @p_datum, [Popis] = @p_popis WHERE [Id] = @p_id;";

        protected override string SQL_DELETE => "DELETE FROM [dbo].[StavebniDenik] WHERE [Id] = @p_id;";

        public override StavebniDenikModel Insert(StavebniDenikModel t)
        {
            var db = new Database();
            db.Connect();

            var command = db.CreateCommand(SQL_INSERT);

            command.Parameters.Add(new SqlParameter("@p_zakazkaId", t.Zakazka.Id));
            command.Parameters.Add(new SqlParameter("@p_uzivatelId", t.Zamestnanec.Id));
            command.Parameters.Add(new SqlParameter("@p_datum", t.Datum.ToString()));
            command.Parameters.Add(new SqlParameter("@p_popis", t.Popis));

            var id = db.InsertAndReturnId(command);
            t.Id = id;
            return t;
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

            var id = db.InsertAndReturnId(command);
            t.Id = id;
            return t;
        }

        protected override IEnumerable<StavebniDenikModel> Read(SqlDataReader reader)
        {
            var mzdy = new List<StavebniDenikModel>();
            while (reader.Read())
            {
                var i = -1;
                var m = new StavebniDenikModel
                {
                    Id = reader.GetInt32(++i),
                };
                var z = new ZakazkaEntity().Select(reader.GetInt32(++i));
                m.Zakazka = z;


                var u = new UzivatelEntity().Select(reader.GetInt32(++i));
                m.Zamestnanec = u;

                m.Datum = reader.GetDateTime(++i).ToShortDateString();
                m.Popis = reader.GetString(++i);

                mzdy.Add(m);
            }

            return mzdy;
        }
    }
}
