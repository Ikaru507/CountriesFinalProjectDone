 using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace ViewModel
{
    public class AttractionsDB : BaseDB
    {
        public override BaseEntity NewEntity() => new Attractions();

        public AttractionsList SelectAll()
        {
            command.CommandText = "SELECT * FROM Attractions";
            return new AttractionsList(Select());
        }

        public void Insert(Attractions a)
        {
            inserted.Add(new EntityState(a, (e, cmd) =>
            {
                var x = (Attractions)e;
                cmd.CommandText = "INSERT INTO Attractions (AttractionName, CountryID, CategoryID, Description) VALUES (?,?,?,?)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@AttractionName", x.AttractionName ?? "");
                cmd.Parameters.AddWithValue("@CountryID", x.Country?.Id ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@CategoryID", x.Category?.Id ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Description", x.Description ?? (object)DBNull.Value);
            }));
        }

        public void Update(Attractions a)
        {
            updated.Add(new EntityState(a, (e, cmd) =>
            {
                var x = (Attractions)e;
                cmd.CommandText = "UPDATE Attractions SET AttractionName=?, CountryID=?, CategoryID=?, Description=? WHERE id=?";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@AttractionName", x.AttractionName ?? "");
                cmd.Parameters.AddWithValue("@CountryID", x.Country?.Id ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@CategoryID", x.Category?.Id ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Description", x.Description ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@id", x.Id);
            }));
        }

        public void Delete(Attractions a)
        {
            deleted.Add(new EntityState(a, (e, cmd) =>
            {
                cmd.CommandText = "DELETE FROM Attractions WHERE id=?";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", e.Id);
            }));
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Attractions a = (Attractions)entity;

            if (HasColumn("id") && !reader.IsDBNull(reader.GetOrdinal("id")))
                a.Id = Convert.ToInt32(reader["id"]);

            if (HasColumn("AttractionName") && !reader.IsDBNull(reader.GetOrdinal("AttractionName")))
                a.AttractionName = reader["AttractionName"].ToString();

            if (HasColumn("Description") && !reader.IsDBNull(reader.GetOrdinal("Description")))
                a.Description = reader["Description"].ToString();

            return a;
        }

        public Attractions SelectById(int id)
        {
            var list = new AttractionsList(Select("SELECT * FROM Attractions" +
                " WHERE id=?", new OleDbParameter("@id", id)));
            return list.Count > 0 ? list[0] : null;
        }
    }
}