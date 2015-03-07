using System;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using demo.framework.Elements;
using NUnit.Framework;
using OpenQA.Selenium;

namespace demo.framework.forms
{
    /// <summary>
    /// class describes kupi.tut.by/mobilnye-telefony search results page
    /// </summary>
    public class SearchResultForm : BaseForm
    {
        private static readonly By PhonePageLocator = By.XPath("//h1[@data-pc_name = 'Мобильные телефоны']");
        private readonly By SearchLocator = By.XPath("//div[@class='head']");
        private readonly Link lkNoElements = new Link(By.XPath("//strong[contains(text(), 'К сожалению, мы не нашли товаров по вашему запросу.')]"), "no elements found label");

        public SearchResultForm() : base(PhonePageLocator, "search result form") { }

        public void CheckSearchCustomerResults(String customer)
        {
            ReadOnlyCollection<IWebElement> searchResultsCollection = new ReadOnlyCollection<IWebElement>(Browser.GetDriver().FindElements(SearchLocator));

            bool result = true;

            if (searchResultsCollection.Count == 0)
            {
                Log.Fatal("Search result is empty.");
            }

            else
            {
                Regex regex = new Regex(customer, RegexOptions.IgnoreCase);

                foreach (var link in searchResultsCollection)
                {
                    if (regex.IsMatch(link.Text))
                    {
                        Log.Info("Search result is correct.");
                    }

                    else
                    {
                        Log.Fatal("Search result is not correct.");
                        result = false;
                    }
                }
            }

            Assert.AreEqual(result, true);
        }

        public void CheckPageWithoutResults()
        {
            Assert.AreEqual(lkNoElements.IsPresent(), true);
        }
    }
}
