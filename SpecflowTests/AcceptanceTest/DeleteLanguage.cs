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
    public class DeleteLanguage
    {
        [Given(@"I clicked on the Language tab under the Profile page")]
        public void GivenIClickedOnTheLanguageTabUnderTheProfilePage()
        {
            //Wait
            Thread.Sleep(3000);

            // Click on Profile tab
            // Driver.driver.FindElement(By.XPath("//a[text()='Profile']")).Click();

            Driver.driver.FindElement(By.LinkText("Profile")).Click();
        }
        
        [When(@"I delete a language")]
        public void WhenIDeleteALanguage()
        {
            //Wait
            Thread.Sleep(3000);

            //Click on Delete button
            Driver.driver.FindElement(By.XPath("//tbody/tr/td[contains(text(),'English')]//..//following-sibling::td[2]/span[2]/i ")).Click();

        }

        [Then(@"that language should not get displayed on my listings")]
        public void ThenThatLanguageShouldNotGetDisplayedOnMyListings()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Delete a Language");

                Thread.Sleep(1000);
                string ExpectedValue = "English has been deleted from your languages";
                string ActualValue = Driver.driver.FindElement(By.XPath("//div[@class='ns-box-inner']")).Text;
                Thread.Sleep(500);
                if (ExpectedValue == ActualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Language was deleted Successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "LanguageDeleted");
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
