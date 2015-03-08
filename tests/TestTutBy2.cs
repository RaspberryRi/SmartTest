using System;
using demo.framework;
using demo.framework.forms;
using NUnit.Framework;

namespace demo.tests
{
    class TestTutBy2 : BaseTest
    {
        private readonly String username = RunConfigurator.GetValue("username");
        private readonly String password = RunConfigurator.GetValue("password");
        private readonly String menuPattern = RunConfigurator.GetValue("menuPattern");
        private readonly String comparableProductsSelect = RunConfigurator.GetValue("comparableProductsSelect");
        private readonly String comparableProductsUnSelect = RunConfigurator.GetValue("comparableProductsUnSelect");
        private readonly String comparedProductNumberAfterSelect = RunConfigurator.GetValue("comparedProductNumberAfterSelect");
        private readonly String comparedProductNumberAfterUnSelect = RunConfigurator.GetValue("comparedProductNumberAfterUnSelect");

        [Test]
        public void RunTest2()
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
            phoneForm.SelectComparableProducts(Convert.ToInt32(comparableProductsSelect));
            phoneForm.AssertComparedProductNumber(Convert.ToInt32(comparedProductNumberAfterSelect));

            Log.Step(5);
            phoneForm.SelectComparableProducts(Convert.ToInt32(comparableProductsUnSelect));
            phoneForm.AssertComparedProductNumber(Convert.ToInt32(comparedProductNumberAfterUnSelect));

            Log.Step(6);
            mainForm.Logout();
            mainForm.AssetrLogout();
        }
    }
}
