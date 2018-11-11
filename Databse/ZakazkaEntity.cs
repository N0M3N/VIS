using System.Collections.Generic;
using System.Data.SqlClient;
using Models;

namespace Databse
{
    public class ZakazkaEntity : Entity<ZakazkaModel>
    {
        protected override string SQL_SELECT => "SELECT [Id], [Zakaznik-Id], [Zamestnanec-Id], [Stav-Id], [Adresa], [Deadline] FROM [dbo].[Zakazka];";

        protected override string SQL_SELECT_ID => "SELECT [Id], [Zakaznik-Id], [Zamestnanec-Id], [Stav-Id], [Adresa], [Deadline] FROM [dbo].[Zakazka] WHERE [Id] = @p_id;";

        protected override string SQL_INSERT => "INSERT INTO [dbo].[Zakazka] ([Zakaznik-Id], [Zamestnanec-Id], [Stav-Id], [Adresa], [Deadline]) VALUES (@p_zakaznikId, @p_zamestnanecId, @p_stavId, @p_adresa, @p_deadline);";

        protected override string SQL_UPDATE => "UPDATE [dbo].[Zakazka] SET [Zakaznik-Id] = @p_zakaznikId, [UZamestnanec-Id] = @p_zamestnanecId, [Stav-Id] = @p_stavId, [Adresa] = @p_adresa, [Deadline] = @p_deadline WHERE [Id] = @p_Id;";

        protected override string SQL_DELETE => "DELETE FROM [dbo].[Zakazka] WHERE [Id] = @p_id;";

        public override int Insert(ZakazkaModel t)
        {
            var db = new Database();
            db.Connect();

            var command = db.CreateCommand(SQL_INSERT);
            command.Parameters.Add(new SqlParameter("@p_zakaznikId", t.Zakaznik.Id));
            command.Parameters.Add(new SqlParameter("@p_zamestnanecId", t.ZodpovednyZamestnanec.Id));
            command.Parameters.Add(new SqlParameter("@p_stavId", t.Stav.Id));
            command.Parameters.Add(new SqlParameter("@p_adresa", t.Adresa));
            command.Parameters.Add(new SqlParameter("@p_deadline", t.Deadline));

            return db.ExecuteNonQuery(command);
        }

        public override int Update(ZakazkaModel t)
        {
            var db = new Database();
            db.Connect();

            var command = db.CreateCommand(SQL_UPDATE);
            command.Parameters.Add(new SqlParameter("@p_zakaznikId", t.Zakaznik.Id));
            command.Parameters.Add(new SqlParameter("@p_zamestnanecId", t.ZodpovednyZamestnanec.Id));
            command.Parameters.Add(new SqlParameter("@p_stavId", t.Stav.Id));
            command.Parameters.Add(new SqlParameter("@p_adresa", t.Adresa));
            command.Parameters.Add(new SqlParameter("@p_deadline", t.Deadline));
            command.Parameters.Add(new SqlParameter("@p_Id", t.Id));
            return db.ExecuteNonQuery(command);
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
                };

                var zakaznik = new UzivatelEntity().Select(reader.GetInt32(++i));
                z.Zakaznik = zakaznik;

                var zamestnanec = new UzivatelEntity().Select(reader.GetInt32(++i));
                z.ZodpovednyZamestnanec = zamestnanec;

                var stav = new StavEntity().Select(reader.GetInt32(++i));
                z.Stav = stav;
                z.Adresa = reader.GetString(++i);
                z.Deadline = reader.GetDateTime(++i);

                zakazky.Add(z);
            }
            return zakazky;
        }
    }
}
