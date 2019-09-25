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
    public class AddCertification_BlankFielda
    {
        [Given(@"I clicked on the Certification under the Profile page")]
        public void GivenIClickedOnTheCertificationUnderTheProfilePage()
        {
            //Wait
            Thread.Sleep(3000);

            // Click on Profile tab
            Driver.driver.FindElement(By.LinkText("Profile")).Click();

            // Click on Certification Tab under profile
            Driver.driver.FindElement(By.XPath("//a[@data-tab='fourth']")).Click();
        }
        
        [When(@"I add a new Certification leaving some fields blank")]
        public void WhenIAddANewCertificationLeavingSomeFieldsBlank()
        {
            //Click on Add New button
            Driver.driver.FindElement(By.XPath("//table[@class='ui fixed table']/thead/tr/th[contains(text(),'Certificate')]//..//th[4]")).Click();

            //Click on Add button
            Driver.driver.FindElement(By.XPath("//input[@value='Add']")).Click();


        }
        
        [Then(@"that blank Certification should not be displayed on my listings")]
        public void ThenThatBlankCertificationShouldNotBeDisplayedOnMyListings()
        {

            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Add a Blank Certification");

                Thread.Sleep(1000);
                string ExpectedValue = "Please enter Certification Name, Certification From and Certification Year";
                Thread.Sleep(1000);
                string ActualValue = Driver.driver.FindElement(By.XPath("//div[@class='ns-box-inner']")).Text;
                Console.WriteLine(ActualValue);

                Thread.Sleep(500);
                if (ExpectedValue == ActualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Blank Certification was not added");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "BlankCertificationNotAdded");
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
