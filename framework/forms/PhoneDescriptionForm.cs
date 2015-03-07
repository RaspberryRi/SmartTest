using System;
using System.Text.RegularExpressions;
using demo.framework.Elements;
using OpenQA.Selenium;
using NUnit.Framework;

namespace demo.framework.forms
{
    /// <summary>
    /// class describes kupi.tut.by/mobilnye-telefony description for one phone page
    /// </summary>
    public class PhoneDescriptionForm : BaseForm
    {
        private static readonly By PhonePageLocator = By.XPath("//a[contains(text(), 'Все характеристики')]");
        private const String lkAddToPurchaseList = "//label[contains(text(), '{0}')]";
        private readonly string linkPattern = "//a[contains(text(), '{0}')]";
        private readonly String lkPhoneInPurchaseList = "//div[@class='overflow_content wishlist_list']//a[contains(text(),'{0}')]";
        private readonly By lkSelectedPhone = By.XPath("//h1[@data-pc_name='Мобильные телефоны']");
        private readonly By lkMemory = By.XPath("//li[contains(text(), 'Память ')]");

        public PhoneDescriptionForm() : base(PhonePageLocator, "description for one phone form") { }

        public void AddToPurchaseList(String pattern)
        {
            new Link(By.XPath(String.Format(lkAddToPurchaseList, pattern)), pattern).Click();
        }

        public void CheckPurchaseListLink(String pattern)
        {
            Assert.AreEqual(new Link(By.XPath(String.Format(lkAddToPurchaseList, pattern)), pattern).IsPresent(), true);
        }

        public void ClickLink(String pattern)
        {
            new Link(By.XPath(String.Format(linkPattern, pattern)), pattern).Click();
        }

        public void AssertPhoneInPurchaseList()
        {
            String pattern = Browser.GetDriver().FindElement(lkSelectedPhone).Text;
            
            Assert.AreEqual((new Link(By.XPath(String.Format(lkPhoneInPurchaseList, pattern)), pattern)).IsPresent(), true);
        }

        public string GetString()
        {
            var phone = Browser.GetDriver().FindElement(lkMemory);

            string text = phone.Text;
            
            string pattern = Convert.ToString(Regex.Replace(text, @"[^\d]+", ""));

            return pattern;
        }
    }
}
