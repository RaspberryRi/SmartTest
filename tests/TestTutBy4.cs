using System;
using demo.framework;
using demo.framework.forms;
using NUnit.Framework;

namespace demo.tests
{
    class TestTutBy4 : BaseTest
    {
        private readonly String username = RunConfigurator.GetValue("username");
        private readonly String password = RunConfigurator.GetValue("password");
        private readonly String menuPattern = RunConfigurator.GetValue("menuPattern");
        private readonly String customer = RunConfigurator.GetValue("customer");
        private readonly String platform = RunConfigurator.GetValue("platform");

        [Test]
        public void RunTest4()
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
            phoneForm.SelectPlatform(platform);
            phoneForm.SearchCustomerModel();
            Browser.WaitForPageToLoad();
            var searchResultForm = new SearchResultForm();
            searchResultForm.CheckPageWithoutResults();

            Log.Step(5);
            mainForm.Logout();
        }
    }
}
