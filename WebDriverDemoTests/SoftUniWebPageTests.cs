
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

        [Test]
        public void Login_InvalidUsernameAndPassword_ShouldFail()
        {
            // Arrange
            var enterButton = driver.FindElement(
                By.CssSelector("#page-header > div.page-header-buttons.buttons-wrapper > ul > li.page-header-buttons-list-element.btn-item.login-btn > span > a"));

            enterButton.Click();
            var userField = driver.FindElement(By.XPath("//*[@id=\"username\"]"));
            userField.SendKeys("user1");
            var passField = driver.FindElement(By.XPath("//*[@id=\"password-input\"]"));
            passField.SendKeys("user1Pass");

            //IWebElement userAndPassSumitButton = driver.FindElement(By.XPath("/html/body/main/section/section/form/article[2]/input"));

            var userAndPassSumitButton = driver.FindElement(By.CssSelector(
                "body > main > section > section > form > article.login-page-form-content-login-btn > input"));
            userAndPassSumitButton.Click();
            //userField.Clear();
            //passField.Clear();

            var expectedMessage = "Невалидно потребителско име или парола";           

            // Act
            string actualTextMessage = driver.FindElement(By.CssSelector(
                "body > main > section > section > form > article.validation-summary-errors > ul > li")).Text;           

            // Assert
            Assert.AreEqual(expectedMessage, actualTextMessage);            
        }

        [Test]
        public void Check_SearchButtonOnMainPageIsWorking_IsSucessful() 
        {
            driver.FindElement(By.CssSelector("#search-icon-container > a > img")).Click();
            Thread.Sleep(2000);
            var searchInputBox = driver.FindElement(By.CssSelector("#search-input"));
            searchInputBox.Click();
            searchInputBox.SendKeys("QA");
            searchInputBox.SendKeys(Keys.Enter);

            var expectedTextResult = "Резултати от търсене на “QA”";
            var actualText = driver.FindElement(By.CssSelector("body > div.content > div > div > h2")).Text;
            Assert.AreEqual(expectedTextResult, actualText);
        }
    }
}