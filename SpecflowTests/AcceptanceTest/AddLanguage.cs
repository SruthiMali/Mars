using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using SpecflowPages;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using static SpecflowPages.CommonMethods;

namespace SpecflowTests.AcceptanceTest
{
    [Binding]
    public class SpecFlowFeature1Steps : Utils.Start
    {
        [Given(@"I clicked on the Language tab under Profile page")]
        public void GivenIClickedOnTheLanguageTabUnderProfilePage()
        {
            //Wait
            Thread.Sleep(3000);
       
            // Click on Profile tab
            // Driver.driver.FindElement(By.XPath("//a[text()='Profile']")).Click();

            Driver.driver.FindElement(By.LinkText("Profile")).Click();


        }
        
        [When(@"I add a new language")]
        public void WhenIAddANewLanguage()
        {
            //Click on Add New button
            Driver.driver.FindElement(By.XPath("//th[text()='Language']/following-sibling::th[2]")).Click();

            //Add Language
            Driver.driver.FindElement(By.XPath("//input[@placeholder='Add Language']")).SendKeys("English");

            //Click on Language Level and select language level

            /* SelectElement oSelect = new SelectElement(driver.FindElements(By.ClassName("ui dropdown")));

             oSelect.SelectByValue("Fluent");*/

            SelectElement ss = new SelectElement(driver.FindElement(By.XPath("//select[@name='level']")));

            Console.WriteLine(ss.Options);
            foreach (IWebElement element in ss.Options)
            {
                if (element.Text == "Fluent")
                {
                    element.Click();
                }
            }

            
            //Click on Add button
            Driver.driver.FindElement(By.XPath("//input[@value='Add']")).Click();

        }

        [Then(@"that language should be displayed on my listings")]
        public void ThenThatLanguageShouldBeDisplayedOnMyListings()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Add a Language");

                Thread.Sleep(1000);
                string ExpectedValue = "English";
                string ActualValue = Driver.driver.FindElement(By.XPath("//tbody/tr/td[1]")).Text;
                Thread.Sleep(500);
                if(ExpectedValue == ActualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added a Language Successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "LanguageAdded");
                }

                else
                    CommonMethods.test.Log(LogStatus.Fail, "Test Failed");

            }
            catch(Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed",e.Message);
            }

             

        }
    }
}
