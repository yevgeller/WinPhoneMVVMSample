using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using WinPhoneMVVMSample.ViewModels;
using WinPhoneMVVMSample.Models;

namespace Test.WinPhoneMVVMSample
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddPerson_TestPerson_CountIsIncreasedByOne()
        {
            RegisterViewModel r = new RegisterViewModel();
            r.People.Add(new Person { Name = "John Smith", Gender = "Lady" });
            Assert.IsTrue(r.People.Count == 1);
        }
    }
}
