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
            throw new System.NotImplementedException();
        }

        public override int Update(DochazkaModel t)
        {
            throw new System.NotImplementedException();
        }

        protected override IEnumerable<DochazkaModel> Read(SqlDataReader reader)
        {
            throw new System.NotImplementedException();
        }
    }
}
