using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class UserProfileDB : BaseDB
    {
        public UserProfileList SelectAll()
        {
            command.CommandText = "SELECT * FROM UserProfile";
            return new UserProfileList(Select());
        }

        public int Insert(UserProfile u)
        {
            return ExecuteNonQuery(
                "INSERT INTO UserProfile (UserName, Email, Password, LastLogin, AvatarImage, Bio) VALUES (?,?,?,?,?,?)",
                new OleDbParameter("@UserName", u.UserName ?? ""),
                new OleDbParameter("@Email", u.Email ?? ""),
                new OleDbParameter("@Password", u.Password ?? ""),
                new OleDbParameter("@LastLogin", u.LastLogin),
                new OleDbParameter("@AvatarImage", (object)u.AvatarImage ?? DBNull.Value),
                new OleDbParameter("@Bio", (object)u.Bio ?? DBNull.Value)
            );
        }

        public int Update(UserProfile u)
        {
            return ExecuteNonQuery(
                "UPDATE UserProfile SET UserName = ?, Email = ?, Password = ?, LastLogin = ?, AvatarImage = ?, Bio = ? WHERE id = ?",
                new OleDbParameter("@UserName", u.UserName ?? ""),
                new OleDbParameter("@Email", u.Email ?? ""),
                new OleDbParameter("@Password", u.Password ?? ""),
                new OleDbParameter("@LastLogin", u.LastLogin),
                new OleDbParameter("@AvatarImage", (object)u.AvatarImage ?? DBNull.Value),
                new OleDbParameter("@Bio", (object)u.Bio ?? DBNull.Value),
                new OleDbParameter("@id", u.Id)
            );
        }
        public static UserProfile SelectById(int id)
        {
            var db = new UserProfileDB();
            var list = new UserProfileList(db.Select("SELECT * FROM UserProfile WHERE id = ?", new OleDbParameter("@id", id)));
            return list.Count > 0 ? list[0] : null;
        }
        public int Delete(int id)
        {
            return ExecuteNonQuery(
                "DELETE FROM UserProfile WHERE id = ?",
                new OleDbParameter("@id", id)
            );
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            UserProfile u = entity as UserProfile ?? new UserProfile();

            if (HasColumn("id") && !reader.IsDBNull(reader.GetOrdinal("id")))
                u.Id = (int)reader["id"];

            if (HasColumn("UserName") && !reader.IsDBNull(reader.GetOrdinal("UserName")))
                u.UserName = reader["UserName"].ToString();

            if (HasColumn("Email") && !reader.IsDBNull(reader.GetOrdinal("Email")))
                u.Email = reader["Email"].ToString();

            if (HasColumn("Password") && !reader.IsDBNull(reader.GetOrdinal("Password")))
                u.Password = reader["Password"].ToString();

            if (HasColumn("LastLogin") && !reader.IsDBNull(reader.GetOrdinal("LastLogin")))
                u.LastLogin = Convert.ToDateTime(reader["LastLogin"]);

            if (HasColumn("AvatarImage") && !reader.IsDBNull(reader.GetOrdinal("AvatarImage")))
                u.AvatarImage = reader["AvatarImage"].ToString();

            if (HasColumn("Bio") && !reader.IsDBNull(reader.GetOrdinal("Bio")))
                u.Bio = reader["Bio"].ToString();

            return u;
        }

        public override BaseEntity NewEntity() => new UserProfile();
    }
}
