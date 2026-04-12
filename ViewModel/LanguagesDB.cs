using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ViewModel
{
    public class LanguagesDB : BaseDB
    {
        public override BaseEntity NewEntity() => new Languages();

        public LanguagesList SelectAll()
        {
            command.CommandText = "SELECT * FROM Languages";
            return new LanguagesList(Select());
        }

        public Languages SelectById(int id)
        {
            var list = new LanguagesList(Select("SELECT * FROM Languages WHERE id=?", new OleDbParameter("@id", id)));
            return list.Count > 0 ? list[0] : null;
        }

        public void Insert(Languages c)
        {
            inserted.Add(new EntityState(c, (e, cmd) =>
            {
                var x = (Languages)e;
                cmd.CommandText = "INSERT INTO Languages (LanguageName) VALUES (?)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@LanguageName", x.LanguageName ?? "");
            }));
        }

        public void Update(Languages c)
        {
            updated.Add(new EntityState(c, (e, cmd) =>
            {
                var x = (Languages)e;
                cmd.CommandText = "UPDATE Languages SET LanguageName=? WHERE id=?";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@LanguageName", x.LanguageName ?? "");
                cmd.Parameters.AddWithValue("@id", x.Id);
            }));
        }

        public void Delete(Languages c)
        {
            deleted.Add(new EntityState(c, (e, cmd) =>
            {
                cmd.CommandText = "DELETE FROM Languages WHERE id=?";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", e.Id);
            }));
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            var c = (Languages)entity;

            if (HasColumn("id") && !reader.IsDBNull(reader.GetOrdinal("id")))
                c.Id = Convert.ToInt32(reader["id"]);

            if (HasColumn("LanguageName") && !reader.IsDBNull(reader.GetOrdinal("LanguageName")))
                c.LanguageName = reader["LanguageName"].ToString();

            return c;
        }
    }
}

