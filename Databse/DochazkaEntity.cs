using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Models;

namespace Databse
{
    public class DochazkaEntity : Entity<DochazkaModel>
    {
        protected override string SQL_SELECT => "SELECT [Id], [Zakazka-Id], [Zamestnanec-Id], [Datum], [Prichod], [Odchod] FROM[dbo].[Dochazka];";

        protected override string SQL_SELECT_ID => "SELECT [Id], [Zakazka-Id], [Zamestnanec-Id], [Datum], [Prichod], [Odchod] FROM[dbo].[Dochazka] WHERE [Id] = @p_id;";

        protected override string SQL_INSERT => "INSERT INTO [dbo].[Dochazka]([Zakazka-Id], [Zamestnanec-Id], [Datum], [Prichod], [Odchod]) VALUES (@p_zakazkaId, @p_zamestnanecId, @p_datum, @p_prichod, @p_odchod); " +
            "SELECT TOP 1 [Id], [Zakazka-Id], [Zamestnanec-Id], [Datum], [Prichod], [Odchod] FROM [dbo].[Dochazka] ORDER BY [Id] DESC;";

        protected override string SQL_UPDATE => "UPDATE [dbo].[Dochazka] SET [Zakazka-Id] = @p_zakazkaId, [Zamestnanec-Id] = @p_zamestnanecId, [Datum] = @p_datum, [Prichod] = @p_prichod, [Odchod] = @p_odchod) WHERE [Id] = @p_id; " +
            "SELECT TOP 1 [Id], [Zakazka-Id], [Zamestnanec-Id], [Datum], [Prichod], [Odchod] FROM [dbo].[Dochazka] ORDER BY [Id] DESC;";

        protected override string SQL_DELETE => "DELETE FROM [dbo].[Dochazka] WHERE [Id] = @p_id;";

        public override DochazkaModel Insert(DochazkaModel t)
        {
            var db = new Database();
            db.Connect();

            var command = db.CreateCommand(SQL_INSERT);

            command.Parameters.Add(new SqlParameter("@p_zakazkaId", t.Zakazka.Id));
            command.Parameters.Add(new SqlParameter("@p_zamestnanecId", t.Zamestnanec.Id));
            command.Parameters.Add(new SqlParameter("@p_datum", Convert.ToDateTime(t.Datum).Ticks));
            command.Parameters.Add(new SqlParameter("@p_prichod", t.Prichod));
            command.Parameters.Add(new SqlParameter("@p_odchod", t.Odchod));

            var result = db.Select(command);
            return Read(result).FirstOrDefault();
        }

        public override DochazkaModel Update(DochazkaModel t)
        {
            var db = new Database();
            db.Connect();

            var command = db.CreateCommand(SQL_UPDATE);

            command.Parameters.Add(new SqlParameter("@p_zakazkaId", t.Zakazka.Id));
            command.Parameters.Add(new SqlParameter("@p_zamestnanecId", t.Zamestnanec.Id));
            command.Parameters.Add(new SqlParameter("@p_datum", Convert.ToDateTime(t.Datum).Ticks));
            command.Parameters.Add(new SqlParameter("@p_prichod", t.Prichod));
            command.Parameters.Add(new SqlParameter("@p_odchod", t.Odchod));
            command.Parameters.Add(new SqlParameter("@p_id", t.Id));

            var result = db.Select(command);
            return Read(result).FirstOrDefault();
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

                var z = new ZakazkaEntity().Select(reader.GetInt32(++i));
                d.Zakazka = z;

                var u = new UzivatelEntity().Select(reader.GetInt32(++i));
                d.Zamestnanec = u;
                d.Datum = new DateTime(reader.GetInt64(++i)).ToShortDateString();
                d.Prichod = new DateTime(reader.GetInt64(++i)).TimeOfDay;
                d.Odchod = new DateTime(reader.GetInt64(++i)).TimeOfDay;

                dochazka.Add(d);
            }
            return dochazka;
        }
    }
}
