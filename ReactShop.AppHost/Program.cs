var builder = DistributedApplication.CreateBuilder(args);

// Add SQL Server and a database
var sql = builder.AddSqlServer("sqlserver");

var db = sql.AddDatabase("ReactShopDb");

// Your API, with the DB reference (injects a connection string)
builder.AddProject<Projects.ReactShop_Server>("reactshop-server")
       .WithReference(db);

builder.Build().Run();
