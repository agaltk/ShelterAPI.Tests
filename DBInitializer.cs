using ShelterApi.Models;
using ShelterAPI.Data;
using System;

namespace ShelterAPI.Tests
{

    public class DBInitializer
    {
        public DBInitializer() 
        {
        }

        public void Seed(ShelterContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            context.Animal.AddRange(
                new Animal() { Age = 2, Weight = 10, Size = 8, Name = "puszek", Added = new DateTime(2019, 5, 9, 9, 32, 52), Strain = "pies" },
                new Animal() {  Age = 6, Weight = 11, Size = 3, Name = "burek", Added = new DateTime(2017, 7, 15, 6, 39, 52), Strain = "pies" },
                new Animal() {  Age = 4, Weight = 18, Size = 2, Name = "azor", Added = new DateTime(2018, 12, 15, 15, 10, 52), Strain = "pies" },
                new Animal() {  Age = 9, Weight = 5, Size = 7, Name = "mysia", Added = new DateTime(2019, 11, 8, 9, 20, 52), Strain = "chomik" },
                new Animal() {  Age = 2, Weight = 9, Size = 4, Name = "riko", Added = new DateTime(2018, 10, 21, 21, 50, 52), Strain = "kot" },
                new Animal() {  Age = 2, Weight = 6, Size = 2, Name = "miki", Added = new DateTime(2019, 11, 8, 6, 7, 52), Strain = "kot" },
                new Animal() {  Age = 12, Weight = 1, Size = 3, Name = "burek", Added = new DateTime(2017, 6, 9, 11, 12, 52), Strain = "pies" },
                new Animal() { Age = 4, Weight = 10, Size = 10, Name = "dino", Added = new DateTime(2019, 3, 2, 8, 30, 52), Strain = "papuga" }
            );

            
            context.SaveChanges();
        }
    }

}