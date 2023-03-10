
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebDriverDemoTests
{
    [TestFixture]
    public class SoftUniWebPageTests
    {
        private WebDriver driver;

        [OneTimeSetUp]
        public void OneTimeSetup_OpenBrowserAndNavigate()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://softuni.bg");
            driver.Manage().Window.Maximize();
            Thread.Sleep(3000);
        }

        [OneTimeTearDown]
        public void OneTimeTeardown() 
        {
            driver.Quit();
        }

        [Test]
        public void Check_MainWebPageTitle_IsCorrect_IsSuccessful()
        {
            // Arrange/Act
            var expectedBrowserTabTitle = "Обучение по програмиране - Софтуерен университет";
            var actualBrowserTabTitle = driver.Title;

            // Assert
            Assert.AreEqual(expectedBrowserTabTitle, actualBrowserTabTitle);
        }

        [Test]
        public void Check_MainWebPageForUsDropDownMenu_IsPresent_IsSuccessful()
        {
            // Arrange/Act           
            string expectedBrowserForUsText = "ЗА НАС";
            var actualBrowserForUsElement = driver.FindElement(By.CssSelector("#nav-items-list > ul > li.page-header-items-list-element.dropdown-item.relative-dropdown > a > span.main-title"));

            // Assert
            Assert.AreEqual(expectedBrowserForUsText, actualBrowserForUsElement.Text);
        }
    }
}