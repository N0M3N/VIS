using System.Collections.Generic;
using System.Data.SqlClient;
using Models;

namespace Databse
{
    internal class ZakazkaEntity : Entity<ZakazkaModel>
    {
        public override string SQL_SELECT => throw new System.NotImplementedException();

        public override string SQL_SELECT_ID => throw new System.NotImplementedException();

        public override string SQL_INSERT => throw new System.NotImplementedException();

        public override string SQL_UPDATE => throw new System.NotImplementedException();

        public override string SQL_DELETE => throw new System.NotImplementedException();

        public override int Insert(ZakazkaModel t)
        {
            throw new System.NotImplementedException();
        }

        public override int Update(ZakazkaModel t)
        {
            throw new System.NotImplementedException();
        }

        protected override IEnumerable<ZakazkaModel> Read(SqlDataReader reader)
        {
            throw new System.NotImplementedException();
        }
    }
}
