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
    public class AddEducation_BlankFields
    {
        [Given(@"I clicked on the Education under the Profile page")]
        public void GivenIClickedOnTheEducationUnderTheProfilePage()
        {

            //Wait
            Thread.Sleep(3000);

            // Click on Profile tab
            Driver.driver.FindElement(By.LinkText("Profile")).Click();

            // Click on Education Tab under profile
            Driver.driver.FindElement(By.XPath("//a[@data-tab='third']")).Click();
        }
        
        [When(@"I add a new Education leaving some fields blank")]
        public void WhenIAddANewEducationLeavingSomeFieldsBlank()
        {
            //Click on Add New button
            Driver.driver.FindElement(By.XPath("//table[@class='ui fixed table']/thead/tr/th[6]")).Click();

            //Add degree
            Driver.driver.FindElement(By.XPath("//input[@name='degree']")).SendKeys("MIS");

            //Click on Add button
            Driver.driver.FindElement(By.XPath("//input[@value='Add']")).Click();
        }
        
        [Then(@"that blank Education should not be displayed on my listings")]
        public void ThenThatBlankEducationShouldNotBeDisplayedOnMyListings()
        {
           try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Add a Blank Education");

                Thread.Sleep(1000);
                string ExpectedValue = "Please enter all the fields";
                Thread.Sleep(1000);
                string ActualValue = Driver.driver.FindElement(By.XPath("//div[@class='ns-box-inner']")).Text;
                Console.WriteLine(ActualValue);

                Thread.Sleep(500);
                if (ExpectedValue == ActualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Blank Education was not added");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "BlankEducationNotAdded");
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
