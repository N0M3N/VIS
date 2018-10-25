using System.Collections.Generic;
using System.Data.SqlClient;
using Models;

namespace Databse
{
    internal class MzdaEntity : Entity<MzdaModel>
    {
        protected override string SQL_SELECT => "SELECT [Id], [Uzivatel-Id], [Zakazka-Id], [Hodinova-Sazba] FROM [dbo].[Mzdy];";

        protected override string SQL_SELECT_ID => "SELECT [Id], [Uzivatel-Id], [Zakazka-Id], [Hodinova-Sazba] FROM [dbo].[Mzdy] WHERE [Id] = @p_id;";

        protected override string SQL_INSERT => "INSERT INTO[dbo].[Mzdy]([Uzivatel-Id], [Zakazka-Id], [Hodinova-Sazba]) VALUES(@p_uzivatelId, @p_zakazkaId, @p_sazba);";

        protected override string SQL_UPDATE => "UPDATE [dbo].[Mzdy] SET [Uzivatel-Id] = @p_uzivatelId, [Zakazka-Id] = @p_zakazkaId, [Hodinova-Sazba] = @p_sazba WHERE [Id] = @p_id;";

        protected override string SQL_DELETE => "DELETE FROM [dbo].[Mzdy] WHERE [Id] = @p_id;";

        public override int Insert(MzdaModel t)
        {
            throw new System.NotImplementedException();
        }

        public override int Update(MzdaModel t)
        {
            throw new System.NotImplementedException();
        }

        protected override IEnumerable<MzdaModel> Read(SqlDataReader reader)
        {
            throw new System.NotImplementedException();
        }
    }
}
