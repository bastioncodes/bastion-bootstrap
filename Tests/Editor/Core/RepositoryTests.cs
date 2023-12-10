using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace SebastianFeistl.Winky.Core.Tests.Editor
{
    public class RepositoryTests
    {
        [Test]
        public void AddAndFind_ModelAddedSuccessfully()
        {
            var repository = new TestRepository();
            var model = new TestModel("Test");
            int id = 1;

            repository.Add(id, model);
            var retrievedModel = repository.Find(id);

            Assert.AreEqual(model, retrievedModel);
        }

        [Test]
        public void Add_DuplicateId_ThrowsException()
        {
            var repository = new TestRepository();
            var model = new TestModel("Test");
            int id = 1;

            repository.Add(id, model);

            Assert.Throws<ArgumentException>(() => repository.Add(id, new TestModel()));
        }
        
        [Test]
        public void Remove_ModelRemovedSuccessfully()
        {
            var repository = new TestRepository();
            var model = new TestModel("Test");
            int id = 1;

            repository.Add(id, model);
            repository.Remove(id);

            Assert.IsFalse(repository.Exists(id));
        }
        
        [Test]
        public void Remove_NonExistentModel_ThrowsException()
        {
            var repository = new TestRepository();
            int nonExistentId = 99;

            Assert.Throws<KeyNotFoundException>(() => repository.Remove(nonExistentId));
        }
        
        [Test]
        public void Clear_AllModelsRemoved()
        {
            var repository = new TestRepository();
            repository.Add(1, new TestModel());
            repository.Add(2, new TestModel());

            repository.Clear();

            Assert.IsTrue(repository.IsEmpty);
        }
    }
}
