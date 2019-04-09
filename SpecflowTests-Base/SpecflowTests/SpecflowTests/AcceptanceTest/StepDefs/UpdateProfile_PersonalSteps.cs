using System;
using System.Threading;
using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using SpecflowPages;
using TechTalk.SpecFlow;
using static SpecflowPages.CommonMethods;

namespace SpecflowTests.AcceptanceTest.StepDefs
{
    [Binding]
    public class UpdateProfile_PersonalSteps
    {
        
        [Given(@"I clicked on the arrow next to Display Name in Profile page")]
        public void GivenIClickedOnTheArrowNextToDisplayNameInProfilePage()
        {
            //Wait
            Thread.Sleep(1500);

            // Click on Edit Name Arrow
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[2]/div/div/div[1]/i")).Click();
        }

        [When(@"I change the First Name and last Name")]
        public void WhenIChangeTheFirstNameAndLastName()
        {
            // Change First Name
            Driver.driver.FindElement(By.Name("firstName")).Clear();
            Driver.driver.FindElement(By.Name("firstName")).SendKeys("Arosha");

            // Change Last Name
            Driver.driver.FindElement(By.Name("lastName")).Clear();
            Driver.driver.FindElement(By.Name("lastName")).SendKeys("Perera");

            //Click save
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[2]/div/div/div[2]/div/div[2]/button")).Click();
            
        }


        [Then(@"that modified name should be displayed in my profile page")]
        public void ThenThatModifiedNameShouldBeDisplayedInMyProfilePage()
        {
            Thread.Sleep(1000);
            CommonMethods.test = CommonMethods.extent.StartTest("Change Display Name");

            //Click save
            String DisplayName = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[2]/div/div/div[1]")).Text;
            Thread.Sleep(1000);

            if ("Arosha Perera".Equals(DisplayName))
            {
                CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Update DisplayName Successfully");
                SaveScreenShotClass.SaveScreenshot(Driver.driver, "DisplayNameUpdated");
            }
            else
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed");
            }
        }

    }
}
