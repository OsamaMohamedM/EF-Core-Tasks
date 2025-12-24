using LMS.Context;
using LMS.DataSeed;

var appContext = new AppDbContext();
DataSeeder.Seed(appContext);