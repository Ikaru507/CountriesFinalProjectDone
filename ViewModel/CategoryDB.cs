using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ViewModel
{
    public class CategoryDB : BaseDB
    {
        public override BaseEntity NewEntity() => new Category();

        public CategoryList SelectAll()
        {
            command.CommandText = "SELECT * FROM Category";
            return new CategoryList(Select());
        }

        public Category SelectById(int id)
        {
            var list = new CategoryList(Select("SELECT * FROM Category WHERE id=?", new OleDbParameter("@id", id)));
            return list.Count > 0 ? list[0] : null;
        }

        public void Insert(Category c)
        {
            inserted.Add(new EntityState(c, (e, cmd) =>
            {
                var x = (Category)e;
                cmd.CommandText = "INSERT INTO Category (CategoryName, Description) VALUES (?,?)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@CategoryName", x.CategoryName ?? "");
                cmd.Parameters.AddWithValue("@Description", x.Description ?? (object)DBNull.Value);
            }));
        }

        public void Update(Category c)
        {
            updated.Add(new EntityState(c, (e, cmd) =>
            {
                var x = (Category)e;
                cmd.CommandText = "UPDATE Category SET CategoryName=?, Description=? WHERE id=?";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@CategoryName", x.CategoryName ?? "");
                cmd.Parameters.AddWithValue("@Description", x.Description ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@id", x.Id);
            }));
        }

        public void Delete(Category c)
        {
            deleted.Add(new EntityState(c, (e, cmd) =>
            {
                cmd.CommandText = "DELETE FROM Category WHERE id=?";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", e.Id);
            }));
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            var c = (Category)entity;

            if (HasColumn("id") && !reader.IsDBNull(reader.GetOrdinal("id")))
                c.Id = Convert.ToInt32(reader["id"]);

            if (HasColumn("CategoryName") && !reader.IsDBNull(reader.GetOrdinal("CategoryName")))
                c.CategoryName = reader["CategoryName"].ToString();

            if (HasColumn("Description") && !reader.IsDBNull(reader.GetOrdinal("Description")))
                c.Description = reader["Description"].ToString();

            return c;
        }
    }
}
