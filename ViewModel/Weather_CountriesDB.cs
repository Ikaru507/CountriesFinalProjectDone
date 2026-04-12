using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class WeatherCountriesDB : BaseDB
    {
        public override BaseEntity NewEntity() => new Weather_Countries();

        public Weather_CountriesList SelectAll()
        {
            command.CommandText = "SELECT * FROM Weather_Countries";
            return new Weather_CountriesList(Select());
        }

        public Weather_Countries SelectById(int id)
        {
            var list = new Weather_CountriesList(
                Select("SELECT * FROM Weather_Countries WHERE id=?",
                new OleDbParameter("@id", id)));

            return list.Count > 0 ? list[0] : null;
        }

        public void Insert(Weather_Countries wc)
        {
            inserted.Add(new EntityState(wc, (e, cmd) =>
            {
                var x = (Weather_Countries)e;
                cmd.CommandText =
                    "INSERT INTO Weather_Countries (CountryId, WeatherId) VALUES (?,?)";

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@CountryId", x.CountryId);
                cmd.Parameters.AddWithValue("@WeatherId", x.WeatherId);
            }));
        }

        public void Delete(Weather_Countries wc)
        {
            deleted.Add(new EntityState(wc, (e, cmd) =>
            {
                cmd.CommandText = "DELETE FROM Weather_Countries WHERE id=?";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", e.Id);
            }));
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            var wc = (Weather_Countries)entity;

            if (HasColumn("id") && !reader.IsDBNull(reader.GetOrdinal("id")))
                wc.Id = Convert.ToInt32(reader["id"]);

            if (HasColumn("CountryId") && !reader.IsDBNull(reader.GetOrdinal("CountryId")))
                wc.CountryId = Convert.ToInt32(reader["CountryId"]);

            if (HasColumn("WeatherId") && !reader.IsDBNull(reader.GetOrdinal("WeatherId")))
                wc.WeatherId = Convert.ToInt32(reader["WeatherId"]);

            return wc;
        }
    }
}