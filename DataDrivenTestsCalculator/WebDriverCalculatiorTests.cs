using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DataDrivenTestsCalculator
{
    public class WebDriverCalculatiorTests
    {
        private ChromeDriver driver;
        private IWebElement fieldNum1 ;
        private IWebElement fieldNum2 ;
        private IWebElement resultField ;
        private IWebElement operationField ;
        private IWebElement calcBtn ;
        private IWebElement resetBtn ;

        [OneTimeSetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://number-calculator.nakov.repl.co/");
            fieldNum1 = driver.FindElement(By.Id("number1"));
            operationField = driver.FindElement(By.Id("operation"));
            fieldNum2 = driver.FindElement(By.Id("number2"));
            calcBtn = driver.FindElement(By.Id("calcButton"));
            resultField = driver.FindElement(By.Id("result"));
            resetBtn = driver.FindElement(By.Id("resetButton"));
        }

        [OneTimeTearDown]
        public void TearDown() 
        {
            driver.Quit();
            // driver.Close();
        }

        [TestCase("5", "+", "6", "Result: 11")]
        [TestCase("0", "+", "100", "Result: 100")]
        [TestCase("-1", "+", "100", "Result: 99")]
        [TestCase("0", "+", "0", "Result: 0")]
        [TestCase("2000000000", "+", "2000000000", "Result: 4000000000")]
        [TestCase("100.01", "+", "1.01", "Result: 101.02")]
        public void Sum_ValidNumbers_IsSuccessful(string numb1, string operation, string numb2, string operationResult)
        {
            // Arrange
            // initialize and locate the IWebElements that you need

            //Act            
            fieldNum1.SendKeys(numb1);
            operationField.SendKeys(operation);
            fieldNum2.SendKeys(numb2);
            calcBtn.Click();
            string result = resultField.Text;
            var expectedResult = operationResult;

            // Assert
            Assert.AreEqual(expectedResult, result);
            
            // clear all entered information andprepare for the new test
            resetBtn.Click();
        }

        [TestCase("", "+", "", "Result: invalid input")]
        [TestCase("", "+", " ", "Result: invalid input")]
        [TestCase("-", "+", "", "Result: invalid input")]
        [TestCase("0", "+", "0", "Result: 0")]
        [TestCase("*", "+", "2000000000", "Result: invalid input")]
        [TestCase(".", "+", "?", "Result: invalid input")]
        [TestCase("#", "+", "?", "Result: invalid input")]
        [TestCase("####???..", "+", "....    ....", "Result: invalid input")]
        public void Sum_InvalidNumbers_ReturnsErrorMessage(string numb1, string operation, string numb2, string operationResult)
        {
            // Arrange
            // initialize and locate the IWebElements that you need

            //Act            
            fieldNum1.SendKeys(numb1);
            operationField.SendKeys(operation);
            fieldNum2.SendKeys(numb2);
            calcBtn.Click();
            string result = resultField.Text;
            var expectedResult = operationResult;

            // Assert
            Assert.AreEqual(expectedResult, result);

            resetBtn.Click();
        }


        [TestCase("5.00", "-", "6", "Result: -1")]
        [TestCase("0", "-", "100", "Result: -100")]
        [TestCase("-1", "-", "100", "Result: -101")]
        [TestCase("0", "-", "0", "Result: 0")]
        [TestCase("2000000000", "-", "2000000000", "Result: 0")]
        [TestCase("100.01", "-", "0.01", "Result: 100")]
        [TestCase("1000", "-", "999", "Result: 1")]
        [TestCase("-1000", "-", "-1", "Result: -999")]
        public void Subtract_ValidNumbers_IsSuccessful(string numb1, string operation, string numb2, string operationResult)
        {
            // Arrange
            // initialize and locate the IWebElements that you need

            //Act            
            fieldNum1.SendKeys(numb1);
            operationField.SendKeys(operation);
            fieldNum2.SendKeys(numb2);
            calcBtn.Click();
            string result = resultField.Text;
            var expectedResult = operationResult;

            // Assert
            Assert.AreEqual(expectedResult, result);

            resetBtn.Click();

            //ToDo write when You have time another test cases when we have multiplicationa and Devision 
        }

        [TestCase("", "-", "", "Result: invalid input")]
        [TestCase("", "-", " ", "Result: invalid input")]
        [TestCase("-", "-", "", "Result: invalid input")]
        [TestCase("0", "-", "0", "Result: 0")]
        [TestCase("*", "-", "2000000000", "Result: invalid input")]
        [TestCase(".", "-", "?", "Result: invalid input")]
        [TestCase("#", "-", "?", "Result: invalid input")]
        [TestCase("####???..", "-", "....    ....", "Result: invalid input")]
        [TestCase("?1", "-", "5", "Result: invalid input")]
        public void Subtract_InvalidNumbers_ReturnsErrorMessage(string numb1, string operation, string numb2, string operationResult)
        {
            // Arrange
            // initialize and locate the IWebElements that you need into the SetUp

            //Act            
            fieldNum1.SendKeys(numb1);
            operationField.SendKeys(operation);
            fieldNum2.SendKeys(numb2);
            calcBtn.Click();
            string result = resultField.Text;
            var expectedResult = operationResult;

            // Assert
            Assert.AreEqual(expectedResult, result); 
            
            resetBtn.Click();
        }
    }
}