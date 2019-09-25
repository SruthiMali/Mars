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
    public class Add_DuplicateCertification
    {
        [Given(@"I clicked the Certifications tab under Profile page")]
        public void GivenIClickedTheCertificationsTabUnderProfilePage()
        {
            //Wait
            Thread.Sleep(3000);

            // Click on Profile tab
            Driver.driver.FindElement(By.LinkText("Profile")).Click();

            // Click on Certification Tab under profile
            Driver.driver.FindElement(By.XPath("//a[@data-tab='fourth']")).Click();
        }
        
        [When(@"I add a duplicate Certificate")]
        public void WhenIAddADuplicateCertificate()
        {
            //Add Certificate or Award in the List collection:
            List<String> certifications = new List<String>();
            certifications.Add("ISTQB");
            certifications.Add("ITIL");

            //Add Certified From in the Array collection:
            string[] certifiedfrom = { "Adobe", "IT" };

            //Add year in the Array collection:
            string[] years = { "2016", "2017" };


            //Click on Add New button
            Driver.driver.FindElement(By.XPath("//table[@class='ui fixed table']/thead/tr/th[contains(text(),'Certificate')]//..//th[4]")).Click();

            // Retrieve items from a List collection by using for loop:
            for (int i = 0; i < certifications.Count; i++)
            {
                //Add Certificate or Award
                Driver.driver.FindElement(By.XPath("//input[@placeholder='Certificate or Award']")).SendKeys(certifications[i]);

                //Add Certified From
                Driver.driver.FindElement(By.XPath("//input[@name='certificationFrom']")).SendKeys(certifiedfrom[i]);


                // Click on Year and Select Year
                SelectElement ss1 = new SelectElement(Driver.driver.FindElement(By.XPath("//select[@name='certificationYear']")));

                Console.WriteLine(ss1.Options);
                foreach (IWebElement element in ss1.Options)
                {
                    if (element.Text == years[i])
                    {
                        element.Click();
                    }
                }

                //Click on Add button
                Driver.driver.FindElement(By.XPath("//input[@value='Add']")).Click();

            }

        }
        
        [Then(@"that Certificate should not be displayed on my listings")]
        public void ThenThatCertificateShouldNotBeDisplayedOnMyListings()
        {

            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Add a Duplicate Certification");

                Thread.Sleep(1000);
                string ExpectedValue = "This information is already exist.";
                Thread.Sleep(1000);
                string ActualValue = Driver.driver.FindElement(By.XPath("//div[@class='ns-box-inner']")).Text;
                Console.WriteLine(ActualValue);

                Thread.Sleep(500);
                if (ExpectedValue == ActualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Duplicate Certification was not added");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "DuplicateCertificationNotAdded");
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
