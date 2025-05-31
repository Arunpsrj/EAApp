using OpenQA.Selenium;
using Xunit;

namespace EAAppTest
{
    public class UnitTest1 : IClassFixture<DriverFixture>
    {
        private readonly DriverFixture driverFixture;

        public UnitTest1(DriverFixture driverFixture)
        {
            driverFixture.Setup(BrowserType.Chrome);
            this.driverFixture = driverFixture;
        }

        [Fact]
        public void Test1()
        {
            driverFixture.Driver.Navigate().GoToUrl("http://eawebapp:8000/");

            driverFixture.Driver.FindElement(By.LinkText("Home")).Click();
            driverFixture.Driver.FindElement(By.LinkText("Privacy")).Click();
            driverFixture.Driver.FindElement(By.LinkText("Product")).Click();
            driverFixture.Driver.FindElement(By.LinkText("Create")).Click();
            driverFixture.Driver.FindElement(By.Id("Name")).SendKeys("Chair");
            driverFixture.Driver.FindElement(By.Id("Description")).SendKeys("Sitting chair");
            driverFixture.Driver.FindElement(By.Id("Price")).SendKeys("100");
        }
    }
}