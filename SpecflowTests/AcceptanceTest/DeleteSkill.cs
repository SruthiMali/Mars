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
    public class DeleteSkill
    {
        [Given(@"I clicked on the Skill tab under the Profile page")]
        public void GivenIClickedOnTheSkillTabUnderTheProfilePage()
        {
            //Wait
            Thread.Sleep(3000);

            // Click on Profile tab
            Driver.driver.FindElement(By.LinkText("Profile")).Click();

            //Click on Skills tab
            Driver.driver.FindElement(By.XPath("//a[@data-tab='second']")).Click();
        }
        
        [When(@"I delete a Skill")]
        public void WhenIDeleteASkill()
        {
            //Wait
            Thread.Sleep(3000);

            //Click on Delete button
            Driver.driver.FindElement(By.XPath("//tbody/tr/td[contains(text(),'Time Management')]//..//following-sibling::td[2]/span[2]/i ")).Click();
        }
        
        [Then(@"that Skill should not get displayed on my listings")]
        public void ThenThatSkillShouldNotGetDisplayedOnMyListings()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Delete a Skill");

                Thread.Sleep(1000);
                string ExpectedValue = "Time Management has been deleted ";
                string ActualValue = Driver.driver.FindElement(By.XPath("//div[@class='ns-box-inner']")).Text;
                Thread.Sleep(500);
                if (ExpectedValue == ActualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Skill was deleted Successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "SkillDeleted");
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
