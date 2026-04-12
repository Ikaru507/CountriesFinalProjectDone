using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class CountriesDB : BaseDB
    {
        public override BaseEntity NewEntity() => new Countries();

        public CountriesList SelectAll()
        {
            command.CommandText = "SELECT * FROM Countries";
            return new CountriesList(Select());
        }

        public Countries SelectById(int id)
        {
            var list = new CountriesList(Select("SELECT * FROM Countries WHERE id=?", new OleDbParameter("@id", id)));
            return list.Count > 0 ? list[0] : null;
        }

        public void Insert(Countries c)
        {
            inserted.Add(new EntityState(c, (e, cmd) =>
            {
                var x = (Countries)e;
                cmd.CommandText = "INSERT INTO Countries (CountryName, ContinentID) VALUES (?,?)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@CountryName", x.CountryName ?? "");
                cmd.Parameters.AddWithValue("@ContinentID", x.Continent?.Id ?? (object)DBNull.Value);
            }));
        }

        public void Update(Countries c)
        {
            updated.Add(new EntityState(c, (e, cmd) =>
            {
                var x = (Countries)e;
                cmd.CommandText = "UPDATE Countries SET CountryName=?, ContinentID=? WHERE id=?";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@CountryName", x.CountryName ?? "");
                cmd.Parameters.AddWithValue("@ContinentID", x.Continent?.Id ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@id", x.Id);
            }));
        }

        public void Delete(Countries c)
        {
            deleted.Add(new EntityState(c, (e, cmd) =>
            {
                cmd.CommandText = "DELETE FROM Countries WHERE id=?";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", e.Id);
            }));
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            var c = (Countries)entity;

            if (HasColumn("id") && !reader.IsDBNull(reader.GetOrdinal("id")))
                c.Id = Convert.ToInt32(reader["id"]);

            if (HasColumn("CountryName") && !reader.IsDBNull(reader.GetOrdinal("CountryName")))
                c.CountryName = reader["CountryName"].ToString();

            if (HasColumn("ContinentID") && !reader.IsDBNull(reader.GetOrdinal("ContinentID")))
                c.Continent = new Continents { Id = Convert.ToInt32(reader["ContinentID"]) };

            return c;
        }
    }
}
