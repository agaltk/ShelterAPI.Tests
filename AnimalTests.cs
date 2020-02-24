using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.Xpo;
using Microsoft.EntityFrameworkCore;
using ShelterApi.Models;
using ShelterAPI.Controllers;
using ShelterAPI.Data;
using ShelterAPI.Models;
using Xunit;

namespace ShelterAPI.Tests
{

    public class AnimalTests
    {
        
        AnimalController controller;


        public AnimalTests()
        {
            controller = new TestsConfig().GetController();
        }
        [Fact]
        public void GetAnimalsList()
        {
            IEnumerable<Animal> animals = controller.Get(null);
            Assert.Equal(8, animals.Count());
        }

        [Fact]
        public void GetAnimalDetailsById()
        {
            Animal animal = controller.Get(3);
            Assert.Equal(3, animal.Id);
        }
        [Fact]
        public void AddAnimal()
        {
            Animal newAnimal = new Animal() { Age = 5, Weight = 10, Size = 8, Name = "test", Added = new DateTime(2019, 5, 9, 9, 32, 52), Strain = "kot" };

            newAnimal = controller.Post(newAnimal);
            IEnumerable<Animal> animals = controller.Get(null);
            Assert.Equal(9, newAnimal.Id);
        }

        [Fact]
        public void EditAnimal()
        {
            Animal toUpdate = controller.Get(3);
            toUpdate.Name = "test";
            toUpdate = controller.Put(toUpdate.Id, toUpdate);
            Assert.Equal("test", toUpdate.Name);
        }

        [Fact]
        public void Delete()
        {
            Animal toDelete = controller.Get(3);
            string expectedMessage = $"{toDelete.Name} delected";
            string returnedMessage = controller.Delete(toDelete.Id);
            Assert.Equal(expectedMessage, returnedMessage);
        }

        [Fact]
        public void FindByName()
        {
            IEnumerable<Animal> animals = controller.GetByName("burek", null);
            foreach (var animal in animals)
            {
                Assert.Equal("burek", animal.Name);
            }
        }
        [Fact]
        public void FindByStrain()
        {
            IEnumerable<Animal> animals = controller.GetByStrain("pies", null);
            foreach (var animal in animals)
            {
                Assert.Equal("pies", animal.Strain);
            }

        }

        [Fact]
        public void FilterByStrainTest()
        {
            AnimalFilter animalFilter = new AnimalFilter();
            animalFilter.Strain = "kot";

            IEnumerable<Animal> animals = controller.Get(animalFilter);
            Assert.Equal(2, animals.Count());

        }
        [Fact]
        public void FilterByAgeAndSizeTest()
        {
            AnimalFilter animalFilter = new AnimalFilter();
            animalFilter.Size = 2;
            animalFilter.Age = 4;

            IEnumerable<Animal> animals = controller.Get(animalFilter);
            Assert.Equal(1, animals.Count());

        }
        [Fact]
        public void FilterByEmptyConditions()
        {
            AnimalFilter animalFilter = new AnimalFilter();

            IEnumerable<Animal> animals = controller.Get(animalFilter);
            Assert.Equal(8, animals.Count());

        }
        [Fact]
        public void FilterByWeightAndStrain()
        {
            AnimalFilter animalFilter = new AnimalFilter();
            animalFilter.Strain = "papuga";
            animalFilter.Weight = 50;

            IEnumerable<Animal> animals = controller.Get(animalFilter);
            Assert.Equal(0, animals.Count());

        }

        [Fact]
        public void SortByDateDescending()
        {
            bool compareDate = true;
            AnimalFilter animalFilter = new AnimalFilter();
            animalFilter.OrderBy = "Added desc";
            IEnumerable<Animal> animals = controller.Get(animalFilter);

            for (int i = 0; i < animals.Count() - 1; i++)
            {
                compareDate = (DateTime.Compare(animals.ElementAt(i).Added, animals.ElementAt(i + 1).Added) >= 0);
            }
            Assert.True(compareDate);

        }
        [Fact]
        public void SortBySizeAscending()
        {
            bool compareSize = true;
            AnimalFilter animalFilter = new AnimalFilter();
            animalFilter.OrderBy = "Size";
            IEnumerable<Animal> animals = controller.Get(animalFilter);

            for (int i = 0; i < animals.Count() - 1; i++)
            {
                compareSize = (animals.ElementAt(i).Size <= animals.ElementAt(i + 1).Size);
            }
            Assert.True(compareSize);

        }


    }

}