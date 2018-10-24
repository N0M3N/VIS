using System.Collections.Generic;
using System.Data.SqlClient;
using Models;

namespace Databse
{
    internal class UzivatelEntity : Entity<UzivatelModel>
    {
        public override string SQL_SELECT => throw new System.NotImplementedException();

        public override string SQL_SELECT_ID => throw new System.NotImplementedException();

        public override string SQL_INSERT => throw new System.NotImplementedException();

        public override string SQL_UPDATE => throw new System.NotImplementedException();

        public override string SQL_DELETE => throw new System.NotImplementedException();

        public override int Insert(UzivatelModel t)
        {
            throw new System.NotImplementedException();
        }

        public override int Update(UzivatelModel t)
        {
            throw new System.NotImplementedException();
        }

        protected override IEnumerable<UzivatelModel> Read(SqlDataReader reader)
        {
            throw new System.NotImplementedException();
        }
    }
}
