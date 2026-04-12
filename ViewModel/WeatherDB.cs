using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ViewModel
{
    public class WeatherDB : BaseDB
    {
        public override BaseEntity NewEntity() => new Weather();

        public WeatherList SelectAll()
        {
            command.CommandText = "SELECT * FROM Weather";
            return new WeatherList(Select());
        }

        public Weather SelectById(int id)
        {
            var list = new WeatherList(Select("SELECT * FROM Weather WHERE id=?", new OleDbParameter("@id", id)));
            return list.Count > 0 ? list[0] : null;
        }

        public void Insert(Weather c)
        {
            inserted.Add(new EntityState(c, (e, cmd) =>
            {
                var x = (Weather)e;
                cmd.CommandText = "INSERT INTO Weather (WeatherName) VALUES (?)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@WeatherName", x.WeatherName ?? "");
            }));
        }

        public void Update(Weather c)
        {
            updated.Add(new EntityState(c, (e, cmd) =>
            {
                var x = (Weather)e;
                cmd.CommandText = "UPDATE Weather SET WeatherName=? WHERE id=?";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@WeatherName", x.WeatherName ?? "");
                cmd.Parameters.AddWithValue("@id", x.Id);
            }));
        }

        public void Delete(Weather c)
        {
            deleted.Add(new EntityState(c, (e, cmd) =>
            {
                cmd.CommandText = "DELETE FROM Weather WHERE id=?";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", e.Id);
            }));
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            var c = (Weather)entity;

            if (HasColumn("id") && !reader.IsDBNull(reader.GetOrdinal("id")))
                c.Id = Convert.ToInt32(reader["id"]);

            if (HasColumn("WeatherName") && !reader.IsDBNull(reader.GetOrdinal("WeatherName")))
                c.WeatherName = reader["WeatherName"].ToString();
            return c;
        }
    }
}

