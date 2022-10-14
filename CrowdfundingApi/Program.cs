using ADOLibrary;
using CrowdfundingApi;
using System;
using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();


/*
 * DEMO USE ADO library
*/

Student Converter(SqlDataReader dr) {
    return new Student() {
        Id = (int)dr["Id"],
        LastName = dr["LastName"].ToString(),
        FirstName = dr["FirstName"].ToString(),
        BirthDate = dr["BirthDate"] == DBNull.Value ? new DateTime() : (DateTime)dr["BirthDate"],
        YearResult = (int)dr["YearResult"],
        SectionId = (int)dr["SectionId"],
        Active = (bool)dr["Active"]
    };
}

Connection connection = new Connection(" db . . . ..  ");
#region ExecuteNonQuery
Command cmdNonQuery = new Command("DELETE FROM Student WHERE Id = 29");

Console.WriteLine("Execute Non Query {0}", connection.ExecuteNonQuery(cmdNonQuery));
#endregion

#region ExecuteReader
Command cmd = new Command("SELECT * FROM V_Student WHERE YearResult > 10");

IEnumerable<Student> liste = connection.ExecuteReader<Student>(cmd, Converter);

foreach (Student item in liste) {
    Console.WriteLine("Id : {0} | Nom : {1} | Résultat : {2}", item.Id, item.LastName, item.YearResult);
}
#endregion

#region ExecuteScalar
Command cmd2 = new Command("SELECT LastName FROM Student WHERE Id = 1");

Console.WriteLine("Execute Scalar :  {0}", connection.ExecuteScalar(cmd2));
#endregion