using System;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using demo.framework.Elements;
using OpenQA.Selenium;
using NUnit.Framework;

namespace demo.framework.forms
{
    /// <summary>
    /// class describes kupi.tut.by/mobilnye-telefony page
    /// </summary>
    public class PhoneForm : BaseForm
    {
        private static readonly By PhonePageLocator = By.XPath("//div[contains(text(),'ПОПУЛЯРНЫЕ БРЕНДЫ')]"); 
        private readonly By lkPhone = By.XPath("//div[@class='head']");
        private readonly By cbCompare = By.XPath("//div[@class='compare']//input[@type='checkbox']");
        private readonly By compareNum = By.Id("compare_num");
        private const String cbCustomer = "//input[@type='checkbox']/following-sibling::label[contains(text(),'{0}')]";
        private readonly Link lkAllCustomers = new Link(By.Id("toggleBrand"), "all customers link");
        private readonly Link lkFasrChoice = new Link(By.Id("fast_choice"), "fast choise link");
        private readonly Button btPlatform = new Button(By.XPath("//label[contains(text(), 'Платформа:')]"), "platform button");
        private readonly Button btDropdown = new Button(By.XPath("//button[@data-id='2142557977']"), "dropdown menu");
        private const String btDropdownPlatform = "//a[@tabindex='0']//span[contains(text(), '{0}')]";
        private readonly Button btSearch = new Button(By.XPath("//input[@value='Подобрать']"), "search button");
        private readonly Link lkFirstPhoneImg = new Link(By.XPath("//img[@data-compare_img]"), "first phone img link");
        private const String lkSort = "//span[contains(text(), '{0}')]";

        public PhoneForm() : base(PhonePageLocator, "phone form") { }

        /// <summary>
        /// method for assert correct display of first phone
        /// </summary>
        /// <param name="applePhone"></param>
        public void AssertFirstPhoneTitle(String applePhone)
        {
            bool result = false;

            var phone = Browser.GetDriver().FindElement(lkPhone);

            Regex regex = new Regex(applePhone, RegexOptions.IgnoreCase);

            if (regex.IsMatch(phone.Text))
            {
                Log.Info("Test result: Passed. " + applePhone);
                result = true;
            }

            else
            {
                Log.Fatal("Test result: Failed. Not" + applePhone);
            }

            Assert.AreEqual(result, true);
        }

        /// <summary>
        /// method for select comparable products checkbox
        /// </summary>
        /// <param name="cbNum"></param>
        public void SelectComparableProducts(int cbNum)
        {
            int j;

            ReadOnlyCollection<IWebElement> checkBoxCollection = new ReadOnlyCollection<IWebElement>(Browser.GetDriver().FindElements(cbCompare));

            for (int i = 0; i < cbNum; i++)
            {
                checkBoxCollection[i].Click();
                j = i + 1;
                Log.Info("CheckBox " + j + " checked");
            }
        }

        /// <summary>
        /// method for assert correct display of compared products number
        /// </summary>
        /// <param name="count"></param>
        public void AssertComparedProductNumber(int count)
        {
            var compareCount = Browser.GetDriver().FindElement(compareNum);

            Assert.AreEqual(compareCount.Text, "" + count);
            Log.Info("Value of the goods was changed to " + count);
        }
        
        /// <summary>
        /// method for selecting customer checkbox
        /// </summary>
        /// <param name="tabName"></param>
        public void SelectCustomerCheckBox(String tabName)
        {
            lkAllCustomers.Click();

            new Link(By.XPath(String.Format(cbCustomer, tabName)), tabName).Click();
        }

        /// <summary>
        /// method assert if displays a popup element that shows the number of found models
        /// </summary>
        public void AssertCustomerNumberIsPresent()
        {
            Assert.AreEqual(lkFasrChoice.IsPresent(), true);
        }
            
        /// <summary>
        /// method for pressing search customer button
        /// </summary>
        public void SearchCustomerModel()
        {
            btSearch.Click();
        }

        /// <summary>
        /// method for selecting phone plathorm
        /// </summary>
        /// <param name="platform"></param>
        public void SelectPlatform(String platform)
        {
            btPlatform.Click();
            btDropdown.Click();
            new Link(By.XPath(String.Format(btDropdownPlatform, platform)), platform).Click();
        }

        /// <summary>
        /// method for selecting first phone image link 
        /// </summary>
        public void SelectFirstPhone()
        {
            lkFirstPhoneImg.Click();
        }

        /// <summary>
        /// method for selecting sort option
        /// </summary>
        /// <param name="sortOption"></param>
        public void SelectSortOption(String sortOption)
        {
            new Link(By.XPath(String.Format(lkSort, sortOption)), sortOption).Click();
        }
    }
}
