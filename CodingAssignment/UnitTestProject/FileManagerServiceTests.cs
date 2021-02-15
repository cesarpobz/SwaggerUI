using CodingAssignment.Models;
using CodingAssignment.Services;
using CodingAssignment.Services.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class FileManagerServiceTests
    {

        private IFileManagerService _service;

        [TestInitialize]
        public void Init()
        {
            _service = new FileManagerService();
        }

        [TestMethod]
        public void DeserailizeDataTest()
        {
            //Arrange

            //Act
            var res = _service.GetData();

            //Assert
            Assert.IsNotNull(res);

            Assert.IsInstanceOfType(res, typeof(DataFileModel));

        }

        [TestMethod]
        public void InsertTest()
        {
            //Arrange
            DataModel data = new DataModel();
            data.Id = 4;
            data.Name = "Test4";
            //Act
            var res = _service.Insert(data);

            //Assert
            Assert.IsNotNull(res);

            Assert.IsInstanceOfType(res, typeof(bool));

        }
        [TestMethod]
        public void UpdateTest()
        {
            //Arrange
            DataModel data = new DataModel();
            data.Id = 2;
            data.Name = "Test4";
            int id = 2;
            //Act
            var res = _service.Update(data, id);

            //Assert
            Assert.IsNotNull(res);

            Assert.IsInstanceOfType(res, typeof(bool));

        }
        [TestMethod]
        public void DeleteTest()
        {
            //Arrange
            int id = 2;
            //Act
            var res = _service.Delete(id);

            //Assert
            Assert.IsNotNull(res);

            Assert.IsInstanceOfType(res, typeof(bool));

        }
    }
}
