using System.Collections.Generic;
using System.Data.SqlClient;
using Models;

namespace Databse
{
    internal class MzdaEntity : Entity<MzdaModel>
    {
        public override string SQL_SELECT => throw new System.NotImplementedException();

        public override string SQL_SELECT_ID => throw new System.NotImplementedException();

        public override string SQL_INSERT => throw new System.NotImplementedException();

        public override string SQL_UPDATE => throw new System.NotImplementedException();

        public override string SQL_DELETE => throw new System.NotImplementedException();

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
