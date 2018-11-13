using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Models;

namespace Databse
{
    public class UzivatelEntity : Entity<UzivatelModel>
    {
        protected override string SQL_SELECT => "SELECT [Id], [Jmeno], [Prijmeni], [Telefon], [Login], [JeZakaznik], [JeZamestnanec] FROM [dbo].[Uzivatel];";

        protected override string SQL_SELECT_ID => "SELECT [Id], [Jmeno], [Prijmeni], [Telefon], [Login], [JeZakaznik], [JeZamestnanec] FROM [dbo].[Uzivatel] WHERE [Id] = @p_id;";

        protected override string SQL_INSERT => "INSERT INTO [dbo].[Uzivatel] ([Jmeno], [Prijmeni], [Telefon], [Login], [Heslo], [JeZakaznik], [JeZamestnanec]) VALUES (@p_jmeno, @p_prijmeni, @p_telefon, @p_login, @p_heslo, @p_jeZakaznik, @p_jeZamestnanec);";

        protected override string SQL_UPDATE => "UPDATE [dbo].[Uzivatel] SET [Jmeno] = @p_jmeno, [Prijmeni] = @p_prijmeni, [Telefon] = @p_telefon, [Login] = @p_login, [Heslo] = @p_heslo, [JeZakaznik] = @p_jeZakaznik, [JeZamestnanec] = @p_jeZamestnanec WHERE [Id] = @p_id;";

        protected override string SQL_DELETE => "DELETE FROM[dbo].[Uzivatel] WHERE [Id] = @p_id;";

        protected string SQL_LOGIN => "SELECT [Id], [Jmeno], [Prijmeni], [Telefon], [Login], [JeZakaznik], [JeZamestnanec] FROM [dbo].[Uzivatel] WHERE [Heslo] = @p_heslo AND [Login] = @p_login;";

        public UzivatelModel Login(string login, string password)
        {
            var db = new Database();
            db.Connect();

            var command = db.CreateCommand(SQL_LOGIN);
            command.Parameters.Add(new SqlParameter("@p_login", login));
            command.Parameters.Add(new SqlParameter("@p_heslo", password));

            return Read(db.Select(command)).FirstOrDefault();
        }

        public override int Insert(UzivatelModel t)
        {
            var db = new Database();
            db.Connect();

            var command = db.CreateCommand(SQL_INSERT);
            command.Parameters.Add(new SqlParameter("@p_jmeno", t.Jmeno));
            command.Parameters.Add(new SqlParameter("@p_prijmeni", t.Prijmeni));
            command.Parameters.Add(new SqlParameter("@p_telefon", t.Telefon));
            command.Parameters.Add(new SqlParameter("@p_login", t.Login));
            //command.Parameters.Add(new SqlParameter("@p_heslo", t.Heslo));
            command.Parameters.Add(new SqlParameter("@p_jeZakaznik", t.JeZakaznik));
            command.Parameters.Add(new SqlParameter("@p_jeZamestnanec", t.JeZamestnanec));
            return db.ExecuteNonQuery(command);
        }

        public override int Update(UzivatelModel t)
        {
            var db = new Database();
            db.Connect();

            var command = db.CreateCommand(SQL_UPDATE);
            command.Parameters.Add(new SqlParameter("@p_jmeno", t.Jmeno));
            command.Parameters.Add(new SqlParameter("@p_prijmeni", t.Prijmeni));
            command.Parameters.Add(new SqlParameter("@p_telefon", t.Telefon));
            command.Parameters.Add(new SqlParameter("@p_login", t.Login));
            //command.Parameters.Add(new SqlParameter("@p_heslo", t.Heslo));
            command.Parameters.Add(new SqlParameter("@p_jeZakaznik", t.JeZakaznik));
            command.Parameters.Add(new SqlParameter("@p_jeZamestnanec", t.JeZamestnanec));
            command.Parameters.Add(new SqlParameter("@p_id", t.Id));
            return db.ExecuteNonQuery(command);
        }

        protected override IEnumerable<UzivatelModel> Read(SqlDataReader reader)
        {
            var uzivatele = new List<UzivatelModel>();
            while (reader.Read())
            {
                var i = -1;
                var u = new UzivatelModel
                {
                    Id = reader.GetInt32(++i),
                    Jmeno = reader.GetString(++i),
                    Prijmeni = reader.GetString(++i),
                    Telefon = reader.GetString(++i),
                    Login = reader.GetString(++i),
                    //Heslo = reader.GetString(++i),
                    JeZakaznik = reader.GetBoolean(++i),
                    JeZamestnanec = reader.GetBoolean(++i),
                };
                
                uzivatele.Add(u);
            }
            return uzivatele;
        }
    }
}
