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
    public class AddLanguage_WithoutLanguageLevel
    {
        [Given(@"I clicked the Language tab under the Profile page")]
        public void GivenIClickedTheLanguageTabUnderTheProfilePage()
        {
            //Wait
            Thread.Sleep(3000);

            // Click on Profile tab
            // Driver.driver.FindElement(By.XPath("//a[text()='Profile']")).Click();

            Driver.driver.FindElement(By.LinkText("Profile")).Click();
        }
        
        [When(@"I add a Language without selecting language level")]
        public void WhenIAddALanguageWithoutSelectingLanguageLevel()
        {

            //Click on Add New button
            Driver.driver.FindElement(By.XPath("//th[text()='Language']/following-sibling::th[2]")).Click();

            //Add Language
            Driver.driver.FindElement(By.XPath("//input[@placeholder='Add Language']")).SendKeys("English");

            // Do not select Language Level

            //Click on Add button
            Driver.driver.FindElement(By.XPath("//input[@value='Add']")).Click();
        }
        
        [Then(@"that language should not be displayed in my listings")]
        public void ThenThatLanguageShouldNotBeDisplayedInMyListings()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Add a Language without Selecting Language Level");

                Thread.Sleep(1000);
                string ExpectedValue = "Please enter language and level";
                Thread.Sleep(1000);
                string ActualValue = Driver.driver.FindElement(By.XPath("//div[@class='ns-box-inner']")).Text;
                Console.WriteLine(ActualValue);

                Thread.Sleep(500);
                if (ExpectedValue == ActualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Language without Language Level was not added ");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "LanguageWithoutLanguageLevelNotAdded");
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
