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
    public class AddSkill_WithoutSkillLevel
    {
        [Given(@"I clicked the Skills tab under the Profile page")]
        public void GivenIClickedTheSkillsTabUnderTheProfilePage()
        {
            //Wait
            Thread.Sleep(3000);

            // Click on Profile tab
            Driver.driver.FindElement(By.LinkText("Profile")).Click();

            //Click on Skills tab
            Driver.driver.FindElement(By.XPath("//a[@data-tab='second']")).Click();
        }
        
        [When(@"I add a Skill without selecting skill level")]
        public void WhenIAddASkillWithoutSelectingSkillLevel()
        {
            //Click on Add New button
            Driver.driver.FindElement(By.XPath("//th[text()='Skill']/following-sibling::th[2]")).Click();

            //Add Skill
            Driver.driver.FindElement(By.XPath("//input[@placeholder='Add Skill']")).SendKeys("Time Management");

            //Click on Add button
            Driver.driver.FindElement(By.XPath("//input[@value='Add']")).Click();

        }

        [Then(@"that Skill should not be displayed in my listings")]
        public void ThenThatSkillShouldNotBeDisplayedInMyListings()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Add a Skill without Selecting Skill Level");

                Thread.Sleep(1000);
                string ExpectedValue = "Please enter skill and experience level";
                Thread.Sleep(1000);
                string ActualValue = Driver.driver.FindElement(By.XPath("//div[@class='ns-box-inner']")).Text;
                Console.WriteLine(ActualValue);

                Thread.Sleep(500);
                if (ExpectedValue == ActualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Skill without Skill Level was not added ");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "SkillWithoutSkillLevelNotAdded");
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
