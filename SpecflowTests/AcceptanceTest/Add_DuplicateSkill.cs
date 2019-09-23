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
    public class Add_DuplicateSkill
    {
        [Given(@"I clicked the Skill tab under Profile page")]
        public void GivenIClickedTheSkillTabUnderProfilePage()
        {
            //Wait
            Thread.Sleep(3000);

            // Click on Profile tab
            Driver.driver.FindElement(By.LinkText("Profile")).Click();

            //Click on Skills tab
            Driver.driver.FindElement(By.XPath("//a[@data-tab='second']")).Click();
        }
        
        [When(@"I add a duplicate Skill")]
        public void WhenIAddADuplicateSkill()
        {
            //Click on Add New button
            Driver.driver.FindElement(By.XPath("//th[text()='Skill']/following-sibling::th[2]")).Click();

            //Add Skill
            Driver.driver.FindElement(By.XPath("//input[@placeholder='Add Skill']")).SendKeys("Time Management");

            //Click on Skill Level and select Skill level
            SelectElement ss = new SelectElement(Driver.driver.FindElement(By.XPath("//select[@name='level']")));

            Console.WriteLine(ss.Options);
            foreach (IWebElement element in ss.Options)
            {
                if (element.Text == "Expert")
                {
                    element.Click();
                }
            }
            //Click on Add button
            Driver.driver.FindElement(By.XPath("//input[@value='Add']")).Click();

        }

        [Then(@"that Skill should not be displayed on my listings")]
        public void ThenThatSkillShouldNotBeDisplayedOnMyListings()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Add a Duplicate Skill");

                Thread.Sleep(1000);
                string ExpectedValue = "This skill is already exist in your skill list.";
                Thread.Sleep(1000);
                string ActualValue = Driver.driver.FindElement(By.XPath("//div[@class='ns-box-inner']")).Text;
                Console.WriteLine(ActualValue);

                Thread.Sleep(500);
                if (ExpectedValue == ActualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Duplicate Skill was not added");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "DuplicateSkillNotAdded");
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
