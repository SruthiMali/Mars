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
    public class Add_DuplicateEducation
    {
        [Given(@"I clicked the Education tab under Profile page")]
        public void GivenIClickedTheEducationTabUnderProfilePage()
        {
            //Wait
            Thread.Sleep(3000);

            // Click on Profile tab
            Driver.driver.FindElement(By.LinkText("Profile")).Click();

            // Click on Education Tab under profile
            Driver.driver.FindElement(By.XPath("//a[@data-tab='third']")).Click();
        }

        [When(@"I add a duplicate Education")]
        public void WhenIAddADuplicateEducation()
        {
            //Add College or University values in the List collection:
            List<String> collegelists = new List<String>();
            collegelists.Add("CQU");
            collegelists.Add("VRK");

            //Add degree names in the Array collection:
            string[] degrees = { "IS", "IT" };

            //Add Title in the Array collection:
            string[] titles = { "M.Tech", "B.Tech" };

            //Add graduation year in the Array collection:
            string[] years = { "2016", "2008" };

            //Add Country names in the Array collection:
            string[] countrys = { "Australia", "India" };

            //Click on Add New button
            Driver.driver.FindElement(By.XPath("//table[@class='ui fixed table']/thead/tr/th[6]")).Click();

            // Retrieve items from a List collection by using for loop:
            for (int i = 0; i < collegelists.Count; i++)
            {
                //Add College or University Name 
                Driver.driver.FindElement(By.XPath("//input[@placeholder='College/University Name']")).SendKeys(collegelists[i]);

                //Click on Country of College and select Country Name
                SelectElement ss = new SelectElement(Driver.driver.FindElement(By.XPath("//select[@name='country']")));

                Console.WriteLine(ss.Options);
                foreach (IWebElement element in ss.Options)
                {
                    if (element.Text == countrys[i])
                    {
                        element.Click();
                    }
                }

                // Click on Title and Select title
                SelectElement ss1 = new SelectElement(Driver.driver.FindElement(By.XPath("//select[@name='title']")));

                Console.WriteLine(ss1.Options);
                foreach (IWebElement element in ss1.Options)
                {
                    if (element.Text == titles[i])
                    {
                        element.Click();
                    }
                }

                //Add degree
                Driver.driver.FindElement(By.XPath("//input[@name='degree']")).SendKeys(degrees[i]);

                // Click on Year of Graduation and Select Year
                SelectElement ss2 = new SelectElement(Driver.driver.FindElement(By.XPath("//select[@name='yearOfGraduation']")));

                Console.WriteLine(ss2.Options);
                foreach (IWebElement element in ss2.Options)
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
        
        [Then(@"that Education should not be displayed on my listings")]
        public void ThenThatEducationShouldNotBeDisplayedOnMyListings()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Add a Duplicate Education");

                Thread.Sleep(1000);
                string ExpectedValue = "This information is already exist.";
                Thread.Sleep(1000);
                string ActualValue = Driver.driver.FindElement(By.XPath("//div[@class='ns-box-inner']")).Text;
                Console.WriteLine(ActualValue);

                Thread.Sleep(500);
                if (ExpectedValue == ActualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Duplicate Education was not added");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "DuplicateEducationNotAdded");
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
