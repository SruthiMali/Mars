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
    public class EditLanguage
    {
        [Given(@"I clicked on Language tab under Profile page")]
        public void GivenIClickedOnLanguageTabUnderProfilePage()
        {

            //Wait
            Thread.Sleep(3000);

            // Click on Profile tab
            // Driver.driver.FindElement(By.XPath("//a[text()='Profile']")).Click();

            Driver.driver.FindElement(By.LinkText("Profile")).Click();
        }
        
        [When(@"I edit a new language")]
        public void WhenIEditANewLanguage()
        {
            //Wait
            Thread.Sleep(3000);

            //Click on Edit button
            Driver.driver.FindElement(By.XPath("//tbody/tr/td[contains(text(),'English')]//..//following-sibling::td[2]/span[1]/i")).Click();

            // Edit the Language Level
            SelectElement ss = new SelectElement(Driver.driver.FindElement(By.XPath("//select[@name='level']")));

            Console.WriteLine(ss.Options);
            foreach (IWebElement element in ss.Options)
            {
                if (element.Text == "Native/Bilingual")
                {
                    element.Click();
                }
            }

            // Click on Update Button
            Driver.driver.FindElement(By.XPath("//div[@data-tab='first'] //input[@value='Update']")).Click();

        }

        [Then(@"that language should get displayed on my listings")]
        public void ThenThatLanguageShouldGetDisplayedOnMyListings()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Edit a Language");

                Thread.Sleep(1000);
                string ExpectedValue = "English has been updated to your languages";
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
