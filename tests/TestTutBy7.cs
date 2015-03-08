using System;
using demo.framework;
using demo.framework.forms;
using NUnit.Framework;

namespace demo.tests
{
    class TestTutBy7 : BaseTest
    {
        private readonly String username = RunConfigurator.GetValue("username");
        private readonly String password = RunConfigurator.GetValue("password");
        private readonly String menuPattern = RunConfigurator.GetValue("menuPattern");
        private readonly String cheapSortOption = RunConfigurator.GetValue("cheapSortOption");

        [Test]
        public void RunTest7()
        {
            Log.Step(1);
            var mainForm = new MainForm();

            Log.Step(2);
            mainForm.PressEnterButton();
            mainForm.Login(username, password);
            mainForm.AssertLogin();

            Log.Step(3);
            mainForm.NavigateMenu(menuPattern);
            Browser.WaitForPageToLoad();
            var phoneForm = new PhoneForm();

            Log.Step(4);
            phoneForm.SelectSortOption(cheapSortOption);
            Browser.WaitForPageToLoad();
            var sortCheapResultForm = new SortResultCheapPhonesForm();
            sortCheapResultForm.CountPrices();

            Log.Step(5);
            mainForm.Logout();
            mainForm.AssetrLogout();
        }
    }
}
