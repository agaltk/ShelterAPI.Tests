using Microsoft.EntityFrameworkCore;
using ShelterAPI.Controllers;
using ShelterAPI.Data;
using System;

namespace ShelterAPI.Tests
{

    public class TestsConfig
    {
        public DbContextOptions<ShelterContext> dbContextOptions { get; set; }
        public static string connectionString = "Server=localhost;Database=shelter;Uid=root;Pwd=123admin";
        AnimalController controller;
        public TestsConfig() 
        {
        }

        public AnimalController GetController()
        {
            dbContextOptions = new DbContextOptionsBuilder<ShelterContext>().UseMySql(connectionString).Options;
            var context = new ShelterContext(dbContextOptions);
            controller = new AnimalController(context);
            DBInitializer db = new DBInitializer();
            db.Seed(context);
            return controller;


        }


    }

}