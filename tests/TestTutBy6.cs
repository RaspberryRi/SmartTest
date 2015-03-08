using System;
using demo.framework;
using demo.framework.forms;
using NUnit.Framework;

namespace demo.tests
{
    class TestTutBy6 : BaseTest
    {
        private readonly String username = RunConfigurator.GetValue("username");
        private readonly String password = RunConfigurator.GetValue("password");
        private readonly String menuPattern = RunConfigurator.GetValue("menuPattern");

        [Test]
        public void RunTest6()
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
            phoneForm.SelectFirstPhone();
            var phoneDescriptionForm = new PhoneDescriptionForm();

            Log.Step(5);
            phoneDescriptionForm.AddToPurchaseList("Добавить в ");
            phoneDescriptionForm.CheckPurchaseListLink("Товар в");

            Log.Step(6);
            phoneDescriptionForm.ClickLink("Списке покупок");
            phoneDescriptionForm.AssertPhoneInPurchaseList();

            Log.Step(7);
            mainForm.Logout();
            mainForm.AssetrLogout();
        }
    }
}
