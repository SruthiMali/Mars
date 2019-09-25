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
    public class CancelCertification
    {
        [Given(@"I clicked on the Certification tab under the Profile")]
        public void GivenIClickedOnTheCertificationTabUnderTheProfile()
        {
            //Wait
            Thread.Sleep(3000);

            // Click on Profile tab
            Driver.driver.FindElement(By.LinkText("Profile")).Click();

            // Click on Certification Tab under profile
            Driver.driver.FindElement(By.XPath("//a[@data-tab='fourth']")).Click();
        }
        
        [When(@"I Cancel a Certification")]
        public void WhenICancelACertification()
        {
            //Click on Add New button
            Driver.driver.FindElement(By.XPath("//table[@class='ui fixed table']/thead/tr/th[contains(text(),'Certificate')]//..//th[4]")).Click();

            //Add Certificate or Award
            Driver.driver.FindElement(By.XPath("//input[@placeholder='Certificate or Award']")).SendKeys("FakeCertification");

            Thread.Sleep(3000);

            // Click on Cancel Button
            Driver.driver.FindElement(By.XPath("//div[@data-tab='fourth']//input[@value='Cancel']")).Click();
        }
        
        [Then(@"that Certification should not get displayed in my listings")]
        public void ThenThatCertificationShouldNotGetDisplayedInMyListings()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Cancel a Certification");

                Thread.Sleep(1000);
                string ExpectedValue = "FakeCertification";
                string ActualValue = Driver.driver.FindElement(By.XPath("//tbody/tr/td[1]")).Text;
                Thread.Sleep(500);
                if (ExpectedValue != ActualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Cancelled a Certification Successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "CertificationCancelled");
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
