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
    public class CancelSkill
    {
        [Given(@"I clicked on the Skill tab under the Profile")]
        public void GivenIClickedOnTheSkillTabUnderTheProfile()
        {
            //Wait
            Thread.Sleep(3000);

            // Click on Profile tab
            Driver.driver.FindElement(By.LinkText("Profile")).Click();

            //Click on Skills tab
            Driver.driver.FindElement(By.XPath("//a[@data-tab='second']")).Click();
        }
        
        [When(@"I Cancel a skill")]
        public void WhenICancelASkill()
        {
            //Click on Add New button
            Driver.driver.FindElement(By.XPath("//th[text()='Skill']/following-sibling::th[2]")).Click();

            //Click on Add Skill to enter the Skill
            Driver.driver.FindElement(By.XPath("//input[@placeholder='Add Skill']")).SendKeys("Communication");

            Thread.Sleep(3000);

            // Click on Cancel Button
            Driver.driver.FindElement(By.XPath("//div[@data-tab='second']//input[@value='Cancel']")).Click();
        }
        
        [Then(@"that skill should not get displayed in my listings")]
        public void ThenThatSkillShouldNotGetDisplayedInMyListings()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Cancel a Skill");

                Thread.Sleep(1000);
                string ExpectedValue = "Communication";
                string ActualValue = Driver.driver.FindElement(By.XPath("//tbody/tr/td[1]")).Text;
                Thread.Sleep(500);
                if (ExpectedValue != ActualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Cancelled a Skill Successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "SkillCancelled");
                   
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
