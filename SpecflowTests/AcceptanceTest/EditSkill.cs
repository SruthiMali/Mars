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
    public class EditSkill
    {
        [Given(@"I clicked on Skill tab under Profile page")]
        public void GivenIClickedOnSkillTabUnderProfilePage()
        {
            //Wait
            Thread.Sleep(3000);

            // Click on Profile tab
            Driver.driver.FindElement(By.LinkText("Profile")).Click();

            //Click on Skills tab
            Driver.driver.FindElement(By.XPath("//a[@data-tab='second']")).Click();
        }
        
        [When(@"I edit a Skill")]
        public void WhenIEditASkill()
        {
            //Wait
            Thread.Sleep(3000);

            //Click on Edit button
            Driver.driver.FindElement(By.XPath("//tbody/tr/td[contains(text(),'Time Management')]//..//following-sibling::td[2]/span[1]/i")).Click();

            // Edit the Skill Level
            SelectElement ss = new SelectElement(Driver.driver.FindElement(By.XPath("//select[@name='level']")));

            Console.WriteLine(ss.Options);
            foreach (IWebElement element in ss.Options)
            {
                if (element.Text == "Intermediate")
                {
                    element.Click();
                }
            }

            // Click on Update Button
            Driver.driver.FindElement(By.XPath("//div[@data-tab='second'] //input[@value='Update']")).Click();
        }
        
        [Then(@"that Skill should get displayed on my listings")]
        public void ThenThatSkillShouldGetDisplayedOnMyListings()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Edit a Skill");

                Thread.Sleep(1000);
                string ExpectedValue = "Time Management has been updated to your skills";
                string ActualValue = Driver.driver.FindElement(By.XPath("//div[@class='ns-box-inner']")).Text;
                Thread.Sleep(500);
                if (ExpectedValue == ActualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Language was edited Successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "LanguageEdited");
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
