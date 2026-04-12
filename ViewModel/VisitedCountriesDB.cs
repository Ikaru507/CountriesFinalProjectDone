using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class VisitedCountriesDB : BaseDB
    {
        public override BaseEntity NewEntity() => new VisitedCountries();

        public VisitedCountriesList SelectAll()
        {
            command.CommandText = "SELECT * FROM VisitedCountries";
            return new VisitedCountriesList(Select());
        }

        public VisitedCountries SelectById(int id)
        {
            var list = new VisitedCountriesList(
                Select("SELECT * FROM VisitedCountries WHERE id=?",
                new OleDbParameter("@id", id)));

            return list.Count > 0 ? list[0] : null;
        }

        public VisitedCountriesList SelectByUserId(int userId)
        {
            return new VisitedCountriesList(
                Select("SELECT * FROM VisitedCountries WHERE UserId=?",
                new OleDbParameter("@UserId", userId)));
        }

        public void Insert(VisitedCountries v)
        {
            inserted.Add(new EntityState(v, (e, cmd) =>
            {
                var x = (VisitedCountries)e;

                cmd.CommandText =
                    "INSERT INTO VisitedCountries (UserId, CountryId, DateVisited) VALUES (?,?,?)";

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@UserId", x.UserId);
                cmd.Parameters.AddWithValue("@CountryId", x.CountryId);
                cmd.Parameters.AddWithValue("@DateVisited", x.DateVisited);
            }));
        }

        public void Update(VisitedCountries v)
        {
            updated.Add(new EntityState(v, (e, cmd) =>
            {
                var x = (VisitedCountries)e;

                cmd.CommandText =
                    "UPDATE VisitedCountries SET UserId=?, CountryId=?, DateVisited=? WHERE id=?";

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@UserId", x.UserId);
                cmd.Parameters.AddWithValue("@CountryId", x.CountryId);
                cmd.Parameters.AddWithValue("@DateVisited", x.DateVisited);
                cmd.Parameters.AddWithValue("@id", x.Id);
            }));
        }

        public void Delete(VisitedCountries v)
        {
            deleted.Add(new EntityState(v, (e, cmd) =>
            {
                cmd.CommandText = "DELETE FROM VisitedCountries WHERE id=?";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", e.Id);
            }));
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            var v = (VisitedCountries)entity;

            if (HasColumn("id") && !reader.IsDBNull(reader.GetOrdinal("id")))
                v.Id = Convert.ToInt32(reader["id"]);

            if (HasColumn("UserId") && !reader.IsDBNull(reader.GetOrdinal("UserId")))
                v.UserId = Convert.ToInt32(reader["UserId"]);

            if (HasColumn("CountryId") && !reader.IsDBNull(reader.GetOrdinal("CountryId")))
                v.CountryId = Convert.ToInt32(reader["CountryId"]);

            if (HasColumn("DateVisited") && !reader.IsDBNull(reader.GetOrdinal("DateVisited")))
                v.DateVisited = Convert.ToDateTime(reader["DateVisited"]);

            return v;
        }
    }
}
