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
    public class EditCertification
    {
        [Given(@"I clicked on Certification tab under Profile page")]
        public void GivenIClickedOnCertificationTabUnderProfilePage()
        {
            //Wait
            Thread.Sleep(3000);

            // Click on Profile tab
            Driver.driver.FindElement(By.LinkText("Profile")).Click();

            // Click on Certification Tab under profile
            Driver.driver.FindElement(By.XPath("//a[@data-tab='fourth']")).Click();
        }
        
        [When(@"I edit a new Certification")]
        public void WhenIEditANewCertification()
        {
            //Wait
            Thread.Sleep(3000);

            //Click on Edit button
            Driver.driver.FindElement(By.XPath("//tbody/tr/td[contains(text(),'ISTQB')]//..//following-sibling::td[2]/span[1]/i")).Click();

            //Clear Certificate or Award
            Driver.driver.FindElement(By.XPath("//input[@placeholder='Certificate or Award']")).Clear();

            //Add Certificate or Award
            Driver.driver.FindElement(By.XPath("//input[@placeholder='Certificate or Award']")).SendKeys("Certified JAVA Programmer");

            // Click on Update Button
            Driver.driver.FindElement(By.XPath("//div[@data-tab='fourth'] //input[@value='Update']")).Click();
        }
        
        [Then(@"that Certification should get displayed on my listings")]
        public void ThenThatCertificationShouldGetDisplayedOnMyListings()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Edit a Certification");

                Thread.Sleep(1000);
                string ExpectedValue = " Certified JAVA Programmer has been updated to your certification";
                string ActualValue = Driver.driver.FindElement(By.XPath("//div[@class='ns-box-inner']")).Text;
                Thread.Sleep(500);
                if (ExpectedValue == ActualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Certification was edited Successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "CertificationEdited");
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
