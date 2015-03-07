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
        private static readonly By lkMain = By.XPath("//a[contains(text(), 'Разместить свои предложения на KUPI.TUT.BY')]");
        private readonly Button btEnter = new Button(By.XPath("//a[contains(text(),'Войти')]"), "Link enter");
        private readonly TextBox tbLogin = new TextBox(By.Name("login"), "textbox login");
        private readonly TextBox tbPassword = new TextBox(By.Name("password"), "textbox login");
        private readonly Button btLogin = new Button(By.XPath("//input[@value='Войти']"), "login button");
        private readonly Link lkExit = new Link(By.XPath("//a[contains(text(),'Выйти')]"), "Link exit");
        private const String menuItem = "//a[contains(text(),'{0}')]";

        public MainForm() : base(lkMain, "kupi.tut.by main form") { }

        public void PressEnterButton()
        {
            btEnter.Click();
        }

        public void Login(string username, string password)
        {
            tbLogin.SetText(username);
            tbPassword.SetText(password);
            btLogin.Click();
            Assert.AreEqual(lkExit.IsPresent(), true);
        }

        public void NavigateMenu(String tabName)
        {
            new Link(By.XPath(String.Format(menuItem, tabName)), tabName).Click();
        }

        public void Logout()
        {
            lkExit.Click();
            Assert.AreNotEqual(lkExit.IsPresent(), true);
        }
    }
}
