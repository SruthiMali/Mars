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
    public class DeleteCertification
    {
        [Given(@"I clicked on the Certification tab under the Profile page")]
        public void GivenIClickedOnTheCertificationTabUnderTheProfilePage()
        {
            //Wait
            Thread.Sleep(3000);

            // Click on Profile tab
            Driver.driver.FindElement(By.LinkText("Profile")).Click();

            // Click on Certification Tab under profile
            Driver.driver.FindElement(By.XPath("//a[@data-tab='fourth']")).Click();
        }
        
        [When(@"I delete a Certification")]
        public void WhenIDeleteACertification()
        {
            //Wait
            Thread.Sleep(3000);

            //Click on Delete button
            Driver.driver.FindElement(By.XPath("//tbody/tr/td[contains(text(),'ITIL')]//..//following-sibling::td[2]/span[2]/i ")).Click();
        }
        
        [Then(@"that Certification should not get displayed on my listings")]
        public void ThenThatCertificationShouldNotGetDisplayedOnMyListings()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Delete a Certification");

                Thread.Sleep(1000);
                string ExpectedValue = "ITIL has been deleted from your certification ";
                string ActualValue = Driver.driver.FindElement(By.XPath("//div[@class='ns-box-inner']")).Text;
                Thread.Sleep(500);
                if (ExpectedValue == ActualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Certification was deleted Successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "CertificationDeleted");
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
