using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVVMAndDataBinding.Interfaces;
using MVVMAndDataBinding.ViewModels;

namespace MainWindowViewModelTest
{
    [TestClass]
    public class MainWindowViewModelTest
    {
        protected MainWindowViewModel MainWindow { get; set; }
        protected IUserRepository UserRepo { get; set; }
        [TestInitialize]
        public void Init()
        {
            //This runs a substitue after getting a download off of the NuGet tools
            //The idea is that you are substitute for the functionality of the UserRepo
            //UserRepo = Substitute.For<IUserRepository>();

            //List<User> garbageUsers = new List<User>(){
            //garbageUsers.Add(new User(){
                        //...
                //});

            //};

            //When GetUsers gets called, it'll return the garbage data
            //UserRepo.GetUsers().Returns(garbageUsers);
            //UserRepo.Received().GetUsers();
            //MainWindow = new MainWindowViewModel();
        }
        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
