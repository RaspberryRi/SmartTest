using System;
using demo.framework.Elements;
using OpenQA.Selenium;
using NUnit.Framework;

namespace demo.framework.forms
{
    /// <summary>
    /// class describes kupi.tut.by main page
    /// </summary>
    public class MainForm : BaseForm
    {
        private static readonly By lkMain =
            By.XPath("//a[contains(text(), 'Разместить свои предложения на KUPI.TUT.BY')]");

        private readonly Button btEnter = new Button(By.XPath("//a[contains(text(),'Войти')]"), "Link enter");
        private readonly TextBox tbLogin = new TextBox(By.Name("login"), "textbox login");
        private readonly TextBox tbPassword = new TextBox(By.Name("password"), "textbox login");
        private readonly Button btLogin = new Button(By.XPath("//input[@value='Войти']"), "login button");
        private readonly Link lkExit = new Link(By.XPath("//a[contains(text(),'Выйти')]"), "Link exit");
        private const String menuItem = "//a[contains(text(),'{0}')]";

        public MainForm() : base(lkMain, "kupi.tut.by main form") { }

        /// <summary>
        /// method for pressing enter button
        /// </summary>
        public void PressEnterButton()
        {
            btEnter.Click();
        }

        /// <summary>
        /// method set user's login and password and press login button
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public void Login(string username, string password)
        {
            tbLogin.SetText(username);
            tbPassword.SetText(password);
            btLogin.Click();
        }

        /// <summary>
        /// method assert login. Link on the page containing text "Выйти" is exist
        /// </summary>
        public void AssertLogin()
        {
            Assert.AreEqual(lkExit.IsPresent(), true);
        }

        /// <summary>
        /// method for menu navigate
        /// </summary>
        /// <param name="tabName"></param>
        public void NavigateMenu(String tabName)
        {
            new Link(By.XPath(String.Format(menuItem, tabName)), tabName).Click();
        }

        /// <summary>
        /// method for logout user
        /// </summary>
        public void Logout()
        {
            lkExit.Click();
            Assert.AreNotEqual(lkExit.IsPresent(), true);
        }

        /// <summary>
        /// method assert that user logout. Link on the page containing text "Выйти" is not exist
        /// </summary>
        public void AssetrLogout()
        {
            Assert.AreNotEqual(lkExit.IsPresent(), true);
        }
    }
}
