

using ADOLibrary;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;

namespace DAL.Repositories {
    public class StatusProjetRepo : IStatusProjetRepo {

        private string _connectionString;

        private Connection AdoLibCon;

        public StatusProjetRepo(IConfiguration c) {
            _connectionString = c.GetConnectionString("default");
            //Init ADO LIB
            AdoLibCon = new Connection(_connectionString);
        }

        private StatusDalModel Converter(SqlDataReader dr) {
            return new StatusDalModel() {
                Id = (int) dr["Id"],
                TypeStatus = dr["TypeStatus"].ToString() ?? ""
            };
        }

        public void Create(StatusDalModel s) {
            Command cmd = new Command("INSERT INTO [StatusProjects] (TypeStatus) VALUES (@name)");
            cmd.AddParameter("name", s.TypeStatus);
            AdoLibCon.ExecuteNonQuery(cmd);
        }

        public void Delete(int id) {
            Command cmd = new Command("DELETE FROM [StatusProjects] WHERE Id = @p0");
            cmd.AddParameter("@p0", id);
            AdoLibCon.ExecuteScalar(cmd);
        }

        public IEnumerable<StatusDalModel> GetAll() {
            Command cmd = new Command("SELECT * FROM [StatusProjects]");
            return AdoLibCon.ExecuteReader(cmd, Converter);
        }

        public void Update(StatusDalModel s) {
            Command cmd = new Command("UPDATE [StatusProjects] SET TypeStatus = @name WHERE Id = @id");
            cmd.AddParameter("@name", s.TypeStatus);
            cmd.AddParameter("@id", s.Id);
            AdoLibCon.ExecuteScalar(cmd);
        }
    }
}
