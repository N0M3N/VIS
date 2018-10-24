using System.Collections.Generic;
using System.Data.SqlClient;
using Models;

namespace Databse
{
    internal class DochazkaEntity : Entity<DochazkaModel>
    {
        public override string SQL_SELECT => throw new System.NotImplementedException();

        public override string SQL_SELECT_ID => throw new System.NotImplementedException();

        public override string SQL_INSERT => throw new System.NotImplementedException();

        public override string SQL_UPDATE => throw new System.NotImplementedException();

        public override string SQL_DELETE => throw new System.NotImplementedException();

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
