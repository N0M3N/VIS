using System.Collections.Generic;
using System.Data.SqlClient;
using Models;

namespace Databse
{
    internal class UzivatelEntity : Entity<UzivatelModel>
    {
        protected override string SQL_SELECT => "SELECT [Id], [Jmeno], [Prijmeni], [Telefon], [Login], [Heslo], [JeZakaznik], [JeZamestnanec] FROM [dbo].[Uzivatel];";

        protected override string SQL_SELECT_ID => "SELECT [Id], [Jmeno], [Prijmeni], [Telefon], [Login], [Heslo], [JeZakaznik], [JeZamestnanec] FROM [dbo].[Uzivatel] WHERE [Id] = @p_id;";

        protected override string SQL_INSERT => "INSERT INTO [dbo].[Uzivatel] ([Jmeno], [Prijmeni], [Telefon], [Login], [Heslo], [JeZakaznik], [JeZamestnanec]) VALUES (@p_jmeno, @p_prijmeni, @p_telefon, @p_login, @p_heslo, @p_jeZakaznik, @p_jeZamestnanec);";

        protected override string SQL_UPDATE => "UPDATE [dbo].[Uzivatel] SET [Jmeno] = @p_jmeno, [Prijmeni] = @p_prijmeni, [Telefon] = @p_telefon, [Login] = @p_login, [Heslo] = @p_heslo, [JeZakaznik] = @p_jeZakaznik, [JeZamestnanec] = @p_jeZamestnanec WHERE [Id] = @p_id;";

        protected override string SQL_DELETE => "DELETE FROM[dbo].[Uzivatel] WHERE [Id] = @p_id;";

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
