using System.Collections.Generic;
using System.Data.SqlClient;
using Models;

namespace Databse
{
    internal class StavEntity : Entity<StavModel>
    {
        protected override string SQL_SELECT => "SELECT [Id], [Nazev] FROM [dbo].[Stav];";

        protected override string SQL_SELECT_ID => "SELECT [Id], [Nazev] FROM[dbo].[Stav] WHERE [Id] = @p_id;";

        protected override string SQL_INSERT => throw new System.NotSupportedException();

        protected override string SQL_UPDATE => throw new System.NotSupportedException();

        protected override string SQL_DELETE => throw new System.NotSupportedException();

        public override int Insert(StavModel t)
        {
            // DO NOT CHANGE
            throw new System.NotSupportedException();
        }

        public override int Update(StavModel t)
        {
            // DO NOT CHANGE
            throw new System.NotSupportedException();
        }

        protected override IEnumerable<StavModel> Read(SqlDataReader reader)
        {
            throw new System.NotImplementedException();
        }
    }
}
