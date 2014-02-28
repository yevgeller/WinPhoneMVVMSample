using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using WinPhoneMVVMSample.ViewModels;
using WinPhoneMVVMSample.Models;
using System.Windows.Input;

namespace Test.WinPhoneMVVMSample
{
    [TestClass]
    public class RegisterViewModelTest
    {
        [TestMethod]
        public void AddPerson_TestPerson_InitialPersonCountIsZero()
        {
            RegisterViewModel r = new RegisterViewModel();
            Assert.AreEqual(r.People.Count, 0);
        }

        [TestMethod]
        public void AddPerson_TestPerson_CountIsIncreasedByOne()
        {
            RegisterViewModel r = new RegisterViewModel();
            r.People.Add(new Person { Name = "John Smith", Gender = "Lady" });
            Assert.AreEqual(r.People.Count, 1);
        }

        [TestMethod]
        public void RegisterCommand_VariablesSet_CanExecute()
        {
            RegisterViewModel r = new RegisterViewModel();
            r.UserName = "test";
            r.IsALady = true;
            ICommand cmd = r.RegisterCommand;
            Assert.IsTrue(cmd.CanExecute(new object()));
        }

        [TestMethod]
        public void RegisterCommand_UserNameNotSet_CannotExecute()
        {
            RegisterViewModel r = new RegisterViewModel();
            //r.UserName = "test";
            r.IsALady = true;
            ICommand cmd = r.RegisterCommand;
            Assert.IsFalse(cmd.CanExecute(new object()));
        }

        [TestMethod]
        public void RegisterCommand_GenderNotSet_CannotExecute()
        {
            RegisterViewModel r = new RegisterViewModel();
            r.UserName = "test";
            //r.IsALady = true;
            ICommand cmd = r.RegisterCommand;
            Assert.IsFalse(cmd.CanExecute(new object()));
        }

        [TestMethod]
        public void RegisterCommand_VariablesSet_UserNameAndGenderNotSetAfterExecute()
        {
            RegisterViewModel r = new RegisterViewModel();
            r.UserName = "test";
            r.IsALady = true;

            ICommand cmd = r.RegisterCommand;
            cmd.Execute(new object());

            Assert.IsFalse(r.IsALady);
            Assert.IsFalse(r.IsAGentleman);
            Assert.AreEqual(r.UserName, string.Empty);
        }
    }
}
