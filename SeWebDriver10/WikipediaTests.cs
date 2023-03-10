using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeWebDriver10
{
    internal class WikipediaTests
    {
        static void Main(string[] args)
        {
            // Create new Chrome browser instance
            var driver = new ChromeDriver();

            // Navigate to  Wikipedia 
            driver.Url = "https://www.wikipedia.org/";

            Console.WriteLine("Current Title: " + driver.Title);

            // Locate Search Field by Id
            var searchInputField = driver.FindElement(By.Id("searchInput"));

            //Click on element
            searchInputField.Click();

            // Fill element and press key enter button
            searchInputField.SendKeys("QA" + Keys.Enter);

            Console.WriteLine("After search Title: " + driver.Title);

            // Close Browser
            driver.Quit();
        }
    }
}