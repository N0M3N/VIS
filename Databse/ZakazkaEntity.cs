using System.Collections.Generic;
using System.Data.SqlClient;
using Models;

namespace Databse
{
    public class ZakazkaEntity : Entity<ZakazkaModel>
    {
        protected override string SQL_SELECT => "SELECT [Id], [Zakaznik-Id], [Zamestnanec-Id], [Stav-Id], [Adresa], [Deadline] FROM [dbo].[Zakazka];";

        protected override string SQL_SELECT_ID => "SELECT [Id], [Zakaznik-Id], [Zamestnanec-Id], [Stav-Id], [Adresa], [Deadline] FROM [dbo].[Zakazka] WHERE [Id] = @p_id;";

        protected override string SQL_INSERT => "INSERT INTO [dbo].[Zakazka] ([Zakaznik-Id], [Zamestnanec-Id], [Stav-Id], [Adresa], [Deadline]) VALUES (@p_zakaznikId, @p_zamestnanecId, @p_stavId, @p_adresa, @p_deadline);";

        protected override string SQL_UPDATE => "UPDATE [dbo].[Zakazka] SET [Zakaznik-Id] = @p_zakaznikId, [UZamestnanec-Id] = @p_zamestnanecId, [Stav-Id] = @p_stavId, [Adresa] = @p_adresa, [Deadline] = @p_deadline WHERE [Id] = @p_Id;";

        protected override string SQL_DELETE => "DELETE FROM [dbo].[Zakazka] WHERE [Id] = @p_id;";

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
