using System;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using OpenQA.Selenium;
using NUnit.Framework;

namespace demo.framework.forms
{
    /// <summary>
    /// class describes kupi.tut.by/mobilnye-telefony sort result for cheap products page
    /// </summary>
    public class SortResultCheapPhonesForm : BaseForm
    {
        private readonly String cheapSortOption = RunConfigurator.GetValue("cheapSortOption");
        private static readonly By lkCheap = By.XPath("//a[@class='active']//span[contains(text(), cheapSortOption)]");
        private readonly By priceCount = By.XPath("//div[contains(text(), 'от ')]/child::big[@class='prop_price']");

        public SortResultCheapPhonesForm() : base(lkCheap, "sort result for cheap products form") { }

        /// <summary>
        /// method asserts that descending sort results is correct
        /// </summary>
        public void CountPrices()
        {
            bool counter = true;
            int price1, price2;

            string pattern = "\\s+";
            string replacement = "";

            Regex rgx = new Regex(pattern);

            ReadOnlyCollection<IWebElement> pricesCollection = new ReadOnlyCollection<IWebElement>(Browser.GetDriver().FindElements(priceCount));
            
            for (int i = 0; i < pricesCollection.Count-1; i++)
            {
                price1 = Convert.ToInt32(rgx.Replace(pricesCollection[i].Text, replacement));
                price2 = Convert.ToInt32(rgx.Replace(pricesCollection[i + 1].Text, replacement));

                if (price1 <= price2)
                {
                    Log.Info("Correctly sorted in step " + i);
                }

                else if (price1 > price2)
                {
                    Log.Fatal("Not sorted correctly in step " + i);
                    counter = false;
                }
            }
            Assert.AreEqual(counter, true);
        }
    }
}
