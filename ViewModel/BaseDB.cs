using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    
    public abstract class BaseDB
    {
        protected static string connectionString =
            @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
            System.IO.Path.GetFullPath(
                System.Reflection.Assembly.GetExecutingAssembly().Location +
                "/../../../../../ViewModel/CountriesProject.accdb");

        protected static OleDbConnection connection;
        protected OleDbCommand command;
        protected OleDbDataReader reader;

        protected List<EntityState> inserted = new();
        protected List<EntityState> updated = new();
        protected List<EntityState> deleted = new();

        public int InsertedCount { get; private set; }
        public int UpdatedCount { get; private set; }
        public int DeletedCount { get; private set; }

        protected BaseDB()
        {
            connection ??= new OleDbConnection(connectionString);
            command = new OleDbCommand { Connection = connection };
        }

        public abstract BaseEntity NewEntity();

        protected List<BaseEntity> Select()
        {
            List<BaseEntity> list = new();

            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                reader = command.ExecuteReader();

                while (reader.Read())
                    list.Add(CreateModel(NewEntity()));
            }
            finally
            {
                reader?.Close();
            }

            return list;
        }

        protected List<BaseEntity> Select(string sql, params OleDbParameter[] parameters)
        {
            List<BaseEntity> list = new();

            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                command.Parameters.Clear();
                command.CommandText = sql;

                if (parameters != null && parameters.Length > 0)
                    command.Parameters.AddRange(parameters);

                reader = command.ExecuteReader();

                while (reader.Read())
                    list.Add(CreateModel(NewEntity()));
            }
            finally
            {
                reader?.Close();
            }

            return list;
        }

        protected int ExecuteNonQuery(string sql, params OleDbParameter[] parameters)
        {
            int affected = 0;

            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                command.Parameters.Clear();
                command.CommandText = sql;

                if (parameters != null && parameters.Length > 0)
                    command.Parameters.AddRange(parameters);

                affected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }

            return affected;
        }

        protected object ExecuteScalar(string sql, params OleDbParameter[] parameters)
        {
            object result = null;

            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                command.Parameters.Clear();
                command.CommandText = sql;

                if (parameters != null && parameters.Length > 0)
                    command.Parameters.AddRange(parameters);

                result = command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }

            return result;
        }

        protected virtual BaseEntity CreateModel(BaseEntity entity)
        {
            try
            {
                int ord = reader.GetOrdinal("id");
                if (!reader.IsDBNull(ord))
                    entity.Id = Convert.ToInt32(reader["id"]);
            }
            catch { }

            return entity;
        }

        protected bool HasColumn(string columnName)
        {
            for (int i = 0; i < reader.FieldCount; i++)
                if (reader.GetName(i).Equals(columnName, StringComparison.OrdinalIgnoreCase))
                    return true;

            return false;
        }

        public int SaveChanges()
        {
            InsertedCount = 0;
            UpdatedCount = 0;
            DeletedCount = 0;

            int total = 0;

            if (connection.State != ConnectionState.Open)
                connection.Open();

            OleDbTransaction trans = connection.BeginTransaction();
            command.Transaction = trans;
            
            try
            {
                foreach (var e in inserted)
                {
                    command.Parameters.Clear();
                    e.CreateSql(e.Entity, command);
                    int a = command.ExecuteNonQuery();
                    InsertedCount += a;
                    total += a;
                }

                foreach (var e in updated)
                {
                    command.Parameters.Clear();
                    e.CreateSql(e.Entity, command);
                    int b = command.ExecuteNonQuery();
                    UpdatedCount += b;
                    total += b;
                }

                foreach (var e in deleted)
                {
                    command.Parameters.Clear();
                    e.CreateSql(e.Entity, command);
                    int c = command.ExecuteNonQuery();
                    DeletedCount += c;
                    total += c;
                }

                trans.Commit();
            }
            catch (Exception ex)
            {
                trans.Rollback();
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            finally
            {
                inserted.Clear();
                updated.Clear();
                deleted.Clear();
            }

            return total;
        }
    }

    public class EntityState
    {
        public BaseEntity Entity { get; set; }
        public Action<BaseEntity, OleDbCommand> CreateSql { get; set; }

        public EntityState(BaseEntity entity, Action<BaseEntity, OleDbCommand> sqlBuilder)
        {
            Entity = entity;
            CreateSql = sqlBuilder;
        }
    }
}