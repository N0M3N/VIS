using Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Databse
{
    public abstract class Entity<T> : ICRUD<T> where T : BaseModel
    {
        protected abstract string SQL_SELECT { get; }
        protected abstract string SQL_SELECT_ID { get; }
        protected abstract string SQL_INSERT { get; }
        protected abstract string SQL_UPDATE { get; }
        protected abstract string SQL_DELETE { get; }

        public virtual IEnumerable<T> Select()
        {
            var db = new Database();
            db.Connect();

            var cmd = db.CreateCommand(SQL_SELECT);

            var reader = db.Select(cmd);
            return Read(reader);
        }

        public virtual T Select(int id)
        {
            var db = new Database();
            db.Connect();

            var cmd = db.CreateCommand(SQL_SELECT_ID);
            cmd.Parameters.Add(new SqlParameter("@p_id", id));

            var reader = db.Select(cmd);
            return Read(reader).FirstOrDefault();
        }

        public abstract T Insert(T t);

        public abstract T Update(T t);

        public virtual bool Delete(int id)
        {
            var db = new Database();
            db.Connect();

            var cmd = db.CreateCommand(SQL_DELETE);
            cmd.Parameters.Add(new SqlParameter("@p_id", id));

            return db.ExecuteNonQuery(cmd) == 1;
        }

        public abstract IEnumerable<T> Read(SqlDataReader reader);
    }
}
