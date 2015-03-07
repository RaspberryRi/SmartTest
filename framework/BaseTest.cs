using System.Diagnostics;
using NUnit.Framework;

namespace demo.framework
{
    [TestFixture]
    public class BaseTest : BaseEntity
    {
       [SetUp]
        public void SetUp()
       {
            Browser.GetInstance();
            Browser.GetDriver().Navigate().GoToUrl(Configuration.GetBaseUrl());
        }

        [TearDown]
        public void TearDown()
        {
            var processes = Process.GetProcessesByName(Configuration.GetBrowser());
            foreach (var process in processes)
            {
                process.Kill();
            }
            Browser.GetDriver().Quit();
        }
    }
}
