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
    public class DeleteEducation
    {
        [Given(@"I clicked on the Education tab under the Profile page")]
        public void GivenIClickedOnTheEducationTabUnderTheProfilePage()
        {
            //Wait
            Thread.Sleep(3000);

            // Click on Profile tab
            Driver.driver.FindElement(By.LinkText("Profile")).Click();

            // Click on Education Tab under profile
            Driver.driver.FindElement(By.XPath("//a[@data-tab='third']")).Click();
        }
        
        [When(@"I delete an education")]
        public void WhenIDeleteAnEducation()
        {
            //Wait
            Thread.Sleep(3000);

            //Click on Delete button
            Driver.driver.FindElement(By.XPath("//tbody/tr/td[contains(text(),'B.Tech')]//..//following-sibling::td[2]/span[2]/i ")).Click();
        }
        
        [Then(@"that Education should not get displayed on my listings")]
        public void ThenThatEducationShouldNotGetDisplayedOnMyListings()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Delete an Education");

                Thread.Sleep(1000);
                string ExpectedValue = "Education entry successfully removed ";
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
