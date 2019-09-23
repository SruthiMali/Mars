using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using SpecflowPages;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using static SpecflowPages.CommonMethods;

namespace SpecflowTests.AcceptanceTest
{
    [Binding]
    public class CancelLanguage
    {
        [Given(@"I clicked on the Language tab under the Profile")]
        public void GivenIClickedOnTheLanguageTabUnderTheProfile()
        {
            //Wait
            Thread.Sleep(5000);

            // Click on Profile tab
            // Driver.driver.FindElement(By.XPath("//a[text()='Profile']")).Click();

            Driver.driver.FindElement(By.LinkText("Profile")).Click();
        }
        
        [When(@"I Cancel a language")]
        public void WhenICancelALanguage()
        {
            //Click on Add New button
            Driver.driver.FindElement(By.XPath("//th[text()='Language']/following-sibling::th[2]")).Click();

            //Click on Add Language to enter the Language
            Driver.driver.FindElement(By.XPath("//input[@placeholder='Add Language']")).SendKeys("Hindi");

            Thread.Sleep(3000);

            // Click on Cancel Button
            Driver.driver.FindElement(By.XPath("//div[@data-tab='first']//input[@value='Cancel']")).Click();
            
        }

        [Then(@"that language should not get displayed in my listings")]
        public void ThenThatLanguageShouldNotGetDisplayedInMyListings()
        {

            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Cancel a Language");

                Thread.Sleep(1000);
                string ExpectedValue = "Hindi";
                string ActualValue = Driver.driver.FindElement(By.XPath("//tbody/tr/td[1]")).Text;
                Thread.Sleep(500);
                if (ExpectedValue != ActualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Cancelled a Language Successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "LanguageCancelled");
                }

                else
                    CommonMethods.test.Log(LogStatus.Fail, "Test Failed");

            }
            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }

        }
    }
}
