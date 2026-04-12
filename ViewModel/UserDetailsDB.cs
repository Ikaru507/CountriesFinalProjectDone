using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ViewModel
{
    public class UserDetailsDB : BaseDB
    {
        public override BaseEntity NewEntity() => new UserDetails();

        public UserDetailsList SelectAll()
        {
            command.CommandText = "SELECT * FROM UserDetails";
            return new UserDetailsList(Select());
        }

        public UserDetails SelectById(int id)
        {
            var list = new UserDetailsList(Select("SELECT * FROM UserDetails WHERE id=?", new OleDbParameter("@id", id)));
            return list.Count > 0 ? list[0] : null;
        }

        public void Insert(UserDetails u)
        {
            inserted.Add(new EntityState(u, (e, cmd) =>
            {
                var x = (UserDetails)e;
                cmd.CommandText = "INSERT INTO UserDetails ([UserName], [Email], [Password], LastLogin) VALUES (?,?,?,@lDate)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@UserName", x.UserName ?? "");
                cmd.Parameters.AddWithValue("@Email", x.Email ?? "");
                cmd.Parameters.AddWithValue("@Password", x.Password ?? "");
                OleDbParameter newoledb = new OleDbParameter("@lDate", OleDbType.DBDate);
                newoledb.Value = x.LastLogin;
                command.Parameters.Add(newoledb);
         //       cmd.Parameters.AddWithValue("@LastLogin", x.LastLogin == DateTime.MinValue ? (object)DBNull.Value : x.LastLogin);
            }));
        }

        public void Update(UserDetails u)
        {
            updated.Add(new EntityState(u, (e, cmd) =>
            {
                var x = (UserDetails)e;
                cmd.CommandText = "UPDATE UserDetails SET [UserName]=?, [Email]=?, [Password]=?, LastLogin=? WHERE id=?";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@UserName", x.UserName ?? "");
                cmd.Parameters.AddWithValue("@Email", x.Email ?? "");
                cmd.Parameters.AddWithValue("@Password", x.Password ?? "");
                cmd.Parameters.AddWithValue("@LastLogin", x.LastLogin == DateTime.MinValue ? (object)DBNull.Value : x.LastLogin);
                cmd.Parameters.AddWithValue("@id", x.Id);
            }));
        }

        public void Delete(UserDetails u)
        {
            deleted.Add(new EntityState(u, (e, cmd) =>
            {
                cmd.CommandText = "DELETE FROM UserDetails WHERE id=?";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", e.Id);
            }));
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            var u = (UserDetails)entity;

            if (HasColumn("id") && !reader.IsDBNull(reader.GetOrdinal("id")))
                u.Id = Convert.ToInt32(reader["id"]);

            if (HasColumn("UserName") && !reader.IsDBNull(reader.GetOrdinal("UserName")))
                u.UserName = reader["UserName"].ToString();

            if (HasColumn("Email") && !reader.IsDBNull(reader.GetOrdinal("Email")))
                u.Email = reader["Email"].ToString();

            if (HasColumn("Password") && !reader.IsDBNull(reader.GetOrdinal("Password")))
                u.Password = reader["Password"].ToString();

            if (HasColumn("LastLogin") && !reader.IsDBNull(reader.GetOrdinal("LastLogin")))
                u.LastLogin = Convert.ToDateTime(reader["LastLogin"]);

            return u;
        }
    }
}

