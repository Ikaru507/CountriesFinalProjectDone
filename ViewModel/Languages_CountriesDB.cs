using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class LanguagesCountriesDB : BaseDB
    {
        public override BaseEntity NewEntity() => new Languages_Countries();

        public Languages_CountriesList SelectAll()
        {
            command.CommandText = "SELECT * FROM Languages_Countries";
            return new Languages_CountriesList(Select());
        }

        public Languages_Countries SelectById(int id)
        {
            var list = new Languages_CountriesList(
                Select("SELECT * FROM Languages_Countries WHERE id=?",
                new OleDbParameter("@id", id)));

            return list.Count > 0 ? list[0] : null;
        }

        public void Insert(Languages_Countries lc)
        {
            inserted.Add(new EntityState(lc, (e, cmd) =>
            {
                var x = (Languages_Countries)e;
                cmd.CommandText =
                    "INSERT INTO Languages_Countries (CountryId, LanguageId) VALUES (?,?)";

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@CountryId", x.CountryId);
                cmd.Parameters.AddWithValue("@LanguageId", x.LanguageId);
            }));
        }

        public void Delete(Languages_Countries lc)
        {
            deleted.Add(new EntityState(lc, (e, cmd) =>
            {
                cmd.CommandText = "DELETE FROM Languages_Countries WHERE id=?";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", e.Id);
            }));
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            var lc = (Languages_Countries)entity;

            if (HasColumn("id") && !reader.IsDBNull(reader.GetOrdinal("id")))
                lc.Id = Convert.ToInt32(reader["id"]);

            if (HasColumn("CountryId") && !reader.IsDBNull(reader.GetOrdinal("CountryId")))
                lc.CountryId = Convert.ToInt32(reader["CountryId"]);

            if (HasColumn("LanguageId") && !reader.IsDBNull(reader.GetOrdinal("LanguageId")))
                lc.LanguageId = Convert.ToInt32(reader["LanguageId"]);

            return lc;
        }
    }
}
