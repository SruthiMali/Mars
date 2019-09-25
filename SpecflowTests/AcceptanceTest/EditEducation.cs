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
    public class EditEducation
    {
        [Given(@"I clicked on Education tab under Profile page")]
        public void GivenIClickedOnEducationTabUnderProfilePage()
        {
            //Wait
            Thread.Sleep(3000);

            // Click on Profile tab
            Driver.driver.FindElement(By.LinkText("Profile")).Click();

            // Click on Education Tab under profile
            Driver.driver.FindElement(By.XPath("//a[@data-tab='third']")).Click();
        }
        
        [When(@"I edit an education")]
        public void WhenIEditAnEducation()
        {
            //Wait
            Thread.Sleep(3000);

            //Click on Edit button
            Driver.driver.FindElement(By.XPath("//tbody/tr/td[contains(text(),'B.Tech')]//..//following-sibling::td[2]/span[1]/i")).Click();

            // Edit the graduation year
            SelectElement ss = new SelectElement(Driver.driver.FindElement(By.XPath("//select[@name='yearOfGraduation']")));

            Console.WriteLine(ss.Options);
            foreach (IWebElement element in ss.Options)
            {
                if (element.Text == "2010")
                {
                    element.Click();
                }
            }

            // Click on Update Button
            Driver.driver.FindElement(By.XPath("//div[@data-tab='third'] //input[@value='Update']")).Click();
        }
        
        [Then(@"that education should get displayed on my listings")]
        public void ThenThatEducationShouldGetDisplayedOnMyListings()
        {

            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Edit a Education");

                Thread.Sleep(1000);
                string ExpectedValue = "Education as been updated";
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
