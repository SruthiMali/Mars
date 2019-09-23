using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using SpecflowPages;
using System;
using System.Collections.Generic;
using System.Threading;
using TechTalk.SpecFlow;
using static SpecflowPages.CommonMethods;

namespace SpecflowTests.AcceptanceTest
{
    [Binding]
    public class AddSkills
    {
        [Given(@"I clicked on the Skills tab under Profile page")]
        public void GivenIClickedOnTheSkillsTabUnderProfilePage()
        {

            //Wait
            Thread.Sleep(3000);

            // Click on Profile tab
            Driver.driver.FindElement(By.LinkText("Profile")).Click();

            //Click on Skills tab
            Driver.driver.FindElement(By.XPath("//a[@data-tab='second']")).Click();

        }
        
        [When(@"I add a new Skill")]
        public void WhenIAddANewSkill()
        {
            //Add Skill values in the List collection:
            List<String> skills = new List<String>();

            skills.Add("Time Management");
            skills.Add("Self-motivation");
            

            // Retrieve items from a List collection by using for loop:
            foreach (string skill in skills)
            {
                //Click on Add New button
                Driver.driver.FindElement(By.XPath("//th[text()='Skill']/following-sibling::th[2]")).Click();

                //Add Skill
                Driver.driver.FindElement(By.XPath("//input[@placeholder='Add Skill']")).SendKeys(skill);

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

        }

        [Then(@"that Skill should be displayed on my listings")]
        public void ThenThatSkillShouldBeDisplayedOnMyListings()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Add a Skill");

                Thread.Sleep(1000);
                string ExpectedValue = "Time Management";
                string ActualValue = Driver.driver.FindElement(By.XPath("//tbody/tr/td[1]")).Text;
                Thread.Sleep(500);
                if (ExpectedValue == ActualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added a Skill Successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "SkillAdded");
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
