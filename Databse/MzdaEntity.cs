using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Models;

namespace Databse
{
    public class MzdaEntity : Entity<MzdaModel>
    {
        protected override string SQL_SELECT => "SELECT [Id], [Uzivatel-Id], [Zakazka-Id], [Sazba] FROM [dbo].[Mzdy];";

        protected override string SQL_SELECT_ID => "SELECT [Id], [Uzivatel-Id], [Zakazka-Id], [Sazba] FROM [dbo].[Mzdy] WHERE [Id] = @p_id;";

        protected override string SQL_INSERT => "INSERT INTO[dbo].[Mzdy]([Uzivatel-Id], [Zakazka-Id], [Sazba]) VALUES(@p_uzivatelId, @p_zakazkaId, @p_sazba); " +
            "SELECT TOP 1 * [Id], [Uzivatel-Id], [Zakazka-Id], [Sazba] FROM [dbo].[Mzdy];";

        protected override string SQL_UPDATE => "UPDATE [dbo].[Mzdy] SET [Uzivatel-Id] = @p_uzivatelId, [Zakazka-Id] = @p_zakazkaId, [Sazba] = @p_sazba WHERE [Id] = @p_id; " +
            "SELECT TOP 1 * [Id], [Uzivatel-Id], [Zakazka-Id], [Sazba] FROM [dbo].[Mzdy];";

        protected override string SQL_DELETE => "DELETE FROM [dbo].[Mzdy] WHERE [Id] = @p_id;";

        public override MzdaModel Insert(MzdaModel t)
        {
            var db = new Database();
            db.Connect();

            var command = db.CreateCommand(SQL_INSERT);
            command.Parameters.Add(new SqlParameter("@p_uzivatelId", t.Zamestnanec.Id));
            command.Parameters.Add(new SqlParameter("@p_zakazkaId", t.Zakazka.Id));
            command.Parameters.Add(new SqlParameter("@p_sazba", t.Sazba));

            var result = db.Select(command);
            return Read(result).FirstOrDefault();
        }

        public override MzdaModel Update(MzdaModel t)
        {
            var db = new Database();
            db.Connect();

            var command = db.CreateCommand(SQL_UPDATE);
            command.Parameters.Add(new SqlParameter("@p_uzivatelId", t.Zamestnanec.Id));
            command.Parameters.Add(new SqlParameter("@p_zakazkaId", t.Zakazka.Id));
            command.Parameters.Add(new SqlParameter("@p_sazba", t.Sazba));
            command.Parameters.Add(new SqlParameter("@p_id", t.Id));

            var result = db.Select(command);
            return Read(result).FirstOrDefault();
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
                var u = new UzivatelEntity().Select(reader.GetInt32(++i));
                m.Zamestnanec = u;
                var z = new ZakazkaEntity().Select(reader.GetInt32(++i));
                m.Zakazka = z;
                m.Sazba = reader.GetInt32(++i);

                mzdy.Add(m);
            }

            return mzdy;
        }
    }
}
