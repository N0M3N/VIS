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

        public override int Insert(StavebniDenikModel t)
        {
            // DO NOT CHANGE
            throw new System.NotSupportedException();
        }

        public override int Update(StavebniDenikModel t)
        {
            // DO NOT CHANGE
            throw new System.NotSupportedException();
        }

        protected override IEnumerable<StavebniDenikModel> Read(SqlDataReader reader)
        {
            // DO NOT CHANGE
            throw new System.NotSupportedException();
        }
    }
}
