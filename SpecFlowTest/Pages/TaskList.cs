
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Html5;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;

namespace SpecFlowTest.Pages
{
    public class TaskList
    {
        Actions action;
        IWebDriver driver;
        WebDriverWait wait;
        string randomString = Guid.NewGuid().ToString();

        public TaskList(IWebDriver globalDriver, WebDriverWait waitTest)
        {
            driver = globalDriver;
            this.wait = waitTest;
            action = new Actions(globalDriver);
        }
        


        public void createList()

            
        {
            wait.Until(wait => driver.FindElement(By.XPath("//text[@rel='placeholder_create_list']"))).Click();
            wait.Until(wait => driver.FindElement(By.XPath("//input[@placeholder='List Name']")));
            driver.FindElement(By.XPath("//input[@placeholder='List Name']")).SendKeys(randomString);
            wait.Until(wait => driver.FindElement(By.CssSelector("button.submit.full.blue"))).Click();
            
        }

        public void addElement()
        {
            wait.Until(wait => driver.FindElement(By.XPath("//input[@placeholder='Add a to-do...']"))).SendKeys(randomString + Keys.Enter);
        }

        public void checkElement()
        {
            wait.Until(wait => driver.FindElement(By.XPath("//span[@class='taskItem-titleWrapper-title']")));
            string listName = "//span[@class='title'][contains(text(),'" + randomString + "')]";
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(listName))).Click();

        }

        public void editList()
        {
            string listName = "//span[@class='title'][contains(text(),'" + randomString + "')]";
            wait.Until(wait => driver.FindElement(By.XPath(listName))).Click();

            string url = driver.Url;
            string[] userId = url.Split('/');


            string editIcon = "//a[@href='#/lists/" + userId[5] + "']//span[@title='List options']//*[@class='options rtl-flip']";

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(editIcon))).Click();


        }

        public void deleteList()
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//a[@title='Delete List']//*[@class='trash']")));
            driver.FindElement(By.XPath("//a[@title='Delete List']//*[@class='trash']")).Click();
        }

        public void deleteListConfirm()
        {
            
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//text[@rel='label_delete_list']")));
            System.Threading.Thread.Sleep(1000);
            driver.FindElement(By.CssSelector("button.blue.full.confirm")).Click();

            Uri expectedUrl = new Uri("https://www.wunderlist.com/webapp#/lists/inbox");
          
            string url = driver.Url;
            Assert.AreEqual(expectedUrl, url);


        }



    }
}
