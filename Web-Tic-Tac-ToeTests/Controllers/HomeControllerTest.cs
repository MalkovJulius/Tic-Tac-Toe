using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Web_Tic_Tac_Toe.Controllers;
using System.Web.Mvc;

namespace Web_Tic_Tac_ToeTests
{
    [TestClass]
    public class HomeControllerTest
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        //I don't sure whether to do it
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
            "TestData\\ForMessageDescription.xml",
            "Case",
            DataAccessMethod.Sequential)]
        [TestMethod]
        public void MessageDescriptionTest()
        {
            //arrange
            var setValue = Convert.ToInt32(TestContext.DataRow["CountStep"]);
            var expectValue = Convert.ToString(TestContext.DataRow["ExpectVal"]);

            //act
            var Controller = new HomeController();
            var target = new PrivateObject(Controller);
            var returnString = target.Invoke("MessageDescription", setValue);

            //assert
            StringAssert.Equals(returnString, expectValue);
        }



        //[ExpectedException(typeof(ArgumentNullException), "Exception not throw ")]
        //[TestMethod]
        //public void SomeThingTest()
        //{
        //    //arrange

        //    //act

        //    //assert
        //}       
    }
}
