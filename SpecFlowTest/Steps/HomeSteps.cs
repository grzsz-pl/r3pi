using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using SpecFlowTest.Pages;
using System;
using System.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;


namespace SpecFlowTest
{
    [Binding]
    public class HomeSteps
    {
        Actions action;
        IWebDriver driver;
        WebDriverWait driverWait;
        Navigation nav;
        Login loginpage;
        TaskList task;


      
        [BeforeScenario]

        public void BeforeScenario()
        {
            driver = new ChromeDriver();
            action = new Actions(driver);
            driverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            nav = new Navigation(driver, driverWait);
            loginpage = new Login(driver, driverWait);
            task = new TaskList(driver, driverWait);

        }

        [AfterScenario]

        public void AfterScenario()
        {
                        driver.Close();
        }

        [Given(@"I have opened start page")]
        public void GivenIHaveOpened()
        {
            driver.Url = "https://www.wunderlist.com/";
        }


        [When(@"I go to sign in page")]
        public void WhenIGoToSignInPage()
        {
            nav.signInClick();
        }

        [When(@"I enter username")]
        public void WhenIEnterUsername()
        {
            loginpage.microsoftSelector();
            loginpage.emailFieldMS();
        }

        [When(@"I enter password")]
        public void WhenIEnterPassword()
        {
            loginpage.passwordField();
        }

        [Then(@"I see profile page")]
        public void ThenISeeProfilePage()
        {
            nav.wunderlistInbox();
        }
        // Second scenario 

        [Given(@"I have log in")]
        public void GivenIHaveLogIn()
        {
            driver.Url = "https://www.wunderlist.com/";
            nav.signInClick();
            loginpage.microsoftSelector();
            loginpage.emailFieldMS();
            loginpage.passwordField();

        }

        [When(@"I create new list")]
        public void WhenICreateNewList()
        {
            task.createList();
            
        }

        [When(@"add item to it")]
        public void WhenAddItemToIt()
        {
            task.addElement();
        }

        [Then(@"I see this list")]
        public void ThenISeeThisList()
        {
            task.checkElement();
        }
        [When(@"I click right on list name")]
        public void WhenIClickRightOnListName()
        {
            task.editList();
   
        }

        [When(@"I click Delete list")]
        public void WhenIClickDeleteList()
        {

            task.deleteList();

            
        }

        [Then(@"list is removed")]
        public void ThenListIsRemoved()
        {
            task.deleteListConfirm();
            //task.listNotDisplayed();
        }

        //next scenario//


    }
}
