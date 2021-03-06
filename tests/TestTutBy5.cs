﻿using System;
using demo.framework;
using demo.framework.forms;
using NUnit.Framework;

namespace demo.tests
{
    class TestTutBy5 : BaseTest
    {
        private readonly String username = RunConfigurator.GetValue("username");
        private readonly String password = RunConfigurator.GetValue("password");
        private readonly String menuPattern = RunConfigurator.GetValue("menuPattern");
        private const string allСharacteristicsLink = "Все характеристики";

        [Test]
        public void RunTest5()
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
            string pattern = phoneDescriptionForm.GetMemory();

            Log.Step(5);
            phoneDescriptionForm.ClickLink(allСharacteristicsLink);
            var phoneDescriptionDetailsForm = new PhoneDescriptionDetailsForm();
            phoneDescriptionDetailsForm.AssertPhoneDescription(pattern);

            Log.Step(6);
            mainForm.Logout();
            mainForm.AssetrLogout();
        }
    }
}
