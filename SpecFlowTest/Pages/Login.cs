using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace SpecFlowTest
{
    public class Login
    {
        Actions action;
        IWebDriver driver;
        WebDriverWait wait;

        public string username = "gszaj@outlook.com";
        public string userPass = "AutomationTest01";

        public Login(IWebDriver globalDriver, WebDriverWait waitTest)
        {
            driver = globalDriver;
            this.wait = waitTest;
            action = new Actions(globalDriver);
        }

        

        public void microsoftSelector()
        {
            wait.Until(wait => driver.FindElement(By.XPath("//span[@class='external-auth microsoft-selector']//a[@class='button big']")));
            driver.FindElement(By.XPath("//span[@class='external-auth microsoft-selector']//a[@class='button big']")).Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//span[@class='external-auth microsoft']//a[1]"))).Click();

        }

        public void emailFieldMS()
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//input[@id='i0116']")));
       
            driver.FindElement(By.CssSelector("#i0116")).SendKeys(username);
            driver.FindElement(By.CssSelector("#idSIButton9")).Click();
        }



        public void passwordField()
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='loginHeader']")));
            System.Threading.Thread.Sleep(1000);
            driver.FindElement(By.CssSelector("#i0118")).SendKeys(userPass);
            driver.FindElement(By.Id("idSIButton9")).Click();  
        }
        }
    }

