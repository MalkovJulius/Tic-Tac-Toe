using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using System;
using Web_Tic_Tac_Toe.Controllers;

namespace Web_Ti_cTac_Toe.Controllers.Tests
{
    [TestClass()]
    public class AuthorizationAuthenticationControllerTests
    {
        [TestMethod()]
        public void IndexTest()
        {
            var AAC = new AuthorizationAuthenticationController();

            ViewResult view = AAC.Index() as ViewResult;

            Assert.IsNotNull(view);
        }


    }
}