using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace SpecFlowTest
{
    public class Navigation
    {
        Actions action;
        IWebDriver driver;
        WebDriverWait wait;

        public Navigation(IWebDriver globalDriver, WebDriverWait waitTest)
            {
                driver = globalDriver;
                this.wait = waitTest;
                action = new Actions(globalDriver);
        }
        
        public void signInClick()
        {
            wait.Until(wait => driver.FindElement(By.LinkText("Sign In"))).Click();
        }

        public void wunderlistInbox()
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='task-list inbox']"))); 
        }
    }
}
