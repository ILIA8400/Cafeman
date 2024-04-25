using CafeMan_Project;
using CafeMan_Project.Controllers;
using CafeMan_Project.Models.Dal;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;


var builder = WebApplication.CreateBuilder(args);

var app = builder.ConfigureServices().ConfigurePipeline();

app.Run();
