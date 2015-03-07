using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using OpenQA.Selenium;
using NUnit.Framework;

namespace demo.framework.forms
{
    /// <summary>
    /// class describes kupi.tut.by/mobilnye-telefony description details for one phone page
    /// </summary>
    public class PhoneDescriptionDetailsForm : BaseForm
    {
        private static readonly By lkDetails = By.XPath("//li[@class='active']//a[contains(text(), 'Характеристики')]");
        private readonly By lkMemory = By.XPath("//td[contains(text(), 'Гб')]");

        public PhoneDescriptionDetailsForm()
            : base(lkDetails, "description details for one phone form") { }

        public void AssertPhoneDescription(string pattern)
        {
            bool result = false;

            var phone = Browser.GetDriver().FindElement(lkMemory);

            Regex regex = new Regex(pattern);

            if (regex.IsMatch(phone.Text))
            {
                Log.Info("Test result: Passed. Built-in memory consistent with the declared.");
                result = true;
            }

            else
            {
                Log.Fatal("Test result: Failed. Built-in memory not consistent with the declared.");
            }

            Assert.AreEqual(result, true);

        }
    }
}
