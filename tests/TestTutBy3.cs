using System;
using demo.framework;
using demo.framework.forms;
using NUnit.Framework;

namespace demo.tests
{
    class TestTutBy3 : BaseTest
    {
        private readonly String username = RunConfigurator.GetValue("username");
        private readonly String password = RunConfigurator.GetValue("password");
        private readonly String menuPattern = RunConfigurator.GetValue("menuPattern");
        private readonly String customer = RunConfigurator.GetValue("customer");

        [Test]
        public void RunTest3()
        {
            Log.Step(1);
            var mainForm = new MainForm();

            Log.Step(2);
            mainForm.PressEnterButton();
            mainForm.Login(username, password);

            Log.Step(3);
            mainForm.NavigateMenu(menuPattern);
            Browser.WaitForPageToLoad();
            var phoneForm = new PhoneForm();

            Log.Step(4);
            phoneForm.SelectCustomerCheckBox(customer);
            phoneForm.AssertCustomerNumberIsPresent();

            Log.Step(5);
            phoneForm.SearchCustomerModel();
            Browser.WaitForPageToLoad();
            var searchResultForm = new SearchResultForm();
            searchResultForm.CheckSearchCustomerResults(customer);
            

            Log.Step(6);
            mainForm.Logout();
        }
    }
}
