using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using SpecflowPages;
using System;
using System.Collections.Generic;
using System.Threading;
using TechTalk.SpecFlow;
using static SpecflowPages.CommonMethods;

namespace SpecflowTests.AcceptanceTest.StepDefs
{
    [Binding]
    public class UpdateProfile_LanguagesSteps : Utils.Start
    {
        //Scenario 1
        [Given(@"I clicked on the Language tab under Profile page")]
        public void GivenIClickedOnTheLanguageTabUnderProfilePage()
        {
            //Wait
            Thread.Sleep(1500);

            // Click on Profile tab
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/a[2]")).Click();

        }

        [When(@"I add a new language")]
        public void WhenIAddANewLanguage()
        {
            //Click on Add New button
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div")).Click();

            //Add Language
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[1]/input")).SendKeys("English");

            //Click on Language Level
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select")).Click();

            //Choose the language level
            IWebElement Lang = Driver.driver.FindElements(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select/option"))[1];
            Lang.Click();

            //Click on Add button
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[1]")).Click();

        }

        [Then(@"that language should be displayed on my listings")]
        public void ThenThatLanguageShouldBeDisplayedOnMyListings()
        {
            try
            {
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Add a Language");

                Thread.Sleep(1000);
                string ExpectedValue = "English";

                //iterate the table until the record found
                IWebElement tableElement = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table"));

                IList<IWebElement> tableRow = tableElement.FindElements(By.TagName("tbody"));

                bool isExist = false;

                foreach (IWebElement row in tableRow)
                {
                    IList<IWebElement> rowTD = row.FindElements(By.TagName("td"));

                    if (rowTD[0].Text.Equals(ExpectedValue))
                    {

                        Thread.Sleep(500);
                        isExist = true;

                        CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added a Language Successfully");
                        SaveScreenShotClass.SaveScreenshot(Driver.driver, "LanguageAdded");

                        break;
                    }
                }

                if (!isExist)
                {
                    CommonMethods.test.Log(LogStatus.Fail, "Test Failed");
                }

            }
            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }

        }

        //Scenario 2
        [When(@"I edit the language")]
        public void WhenIEditTheLanguage()
        {
            //iterate the table until the record found
            IWebElement tableElement = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table"));

            IList<IWebElement> tableRow = tableElement.FindElements(By.TagName("tbody"));

            int RowNo = 0;

            foreach (IWebElement row in tableRow)
            {
                RowNo++;

                IList<IWebElement> rowTD = row.FindElements(By.TagName("td"));

                if (rowTD[0].Text.Equals("English"))
                {

                    //Click edit button
                    Driver.driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + RowNo + "]/tr/td[3]/span[1]")).Click();

                    //Clear the field and update the Language
                    Driver.driver.FindElement(By.Name("name")).Clear();
                    Driver.driver.FindElement(By.Name("name")).SendKeys("Spanish");

                    //Click on Update button
                    Driver.driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td/div/span/input[1]")).Click();

                    break;

                }
            }

        }

        [Then(@"the updated language should be displayed on my listings")]
        public void ThenTheUpdatedLanguageShouldBeDisplayedOnMyListings()
        {
            try
            {
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Edit a Language");

                Thread.Sleep(1000);
                string ExpectedValue = "Spanish";
                string ActualValue = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[1]")).Text;

                Thread.Sleep(500);
                if (ExpectedValue == ActualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Updated a Language Successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "LanguageUpdated");
                }
                else
                {
                    CommonMethods.test.Log(LogStatus.Fail, "Test Failed");
                }
            }
            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }

        }

        //Scenario 3
        [When(@"I edit the level on the language")]
        public void WhenIEditTheLevelOnTheLanguage()
        {
            //iterate the table until the record found
            IWebElement tableElement = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table"));

            IList<IWebElement> tableRow = tableElement.FindElements(By.TagName("tbody"));

            int RowNo = 0;

            foreach (IWebElement row in tableRow)
            {
                RowNo++;

                IList<IWebElement> rowTD = row.FindElements(By.TagName("td"));

                if (rowTD[0].Text.Equals("Spanish"))
                {

                    //Click edit button
                    Driver.driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + RowNo + "]/tr/td[3]/span[1]")).Click();
                    
                    //Edit on Language Level
                    Driver.driver.FindElement(By.Name("level")).Click();

                    //Click on Language Level
                    Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + RowNo + "]/tr/td/div/div[2]/select/option[3]")).Click();
                                                        //*[@id="account-profile-section"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select/option[2]
                    //Click on Update button
                    Driver.driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + RowNo + "]/tr/td/div/span/input[1]")).Click();

                    break;
                }
            }
        }

        [Then(@"the updated level should be displayed on my listings")]
        public void ThenTheUpdatedLevelShouldBeDisplayedOnMyListings()
        {
            try
            {
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Update a Language level");

                Thread.Sleep(1000);

                //iterate the table until the record found
                IWebElement tableElement = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table"));

                IList<IWebElement> tableRow = tableElement.FindElements(By.TagName("tbody"));
                
                bool isExist = false;
                string ExpectedValue = "Conversational";

                foreach (IWebElement row in tableRow)
                {
                    IList<IWebElement> rowTD = row.FindElements(By.TagName("td"));

                    if (rowTD[1].Text.Equals(ExpectedValue))
                    {
                        isExist = true;
                        Thread.Sleep(500);

                        CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Updated a Language Level Successfully");
                        SaveScreenShotClass.SaveScreenshot(Driver.driver, "LanguageLevelUpdated");

                        break;
                    }

                }
                if (!isExist)
                {
                    CommonMethods.test.Log(LogStatus.Fail, "Test Failed");

                }
            }
            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }

        }

        //Scenario 4
        [When(@"I delete an existing language")]
        public void WhenIDeleteAnExistingLanguage()
        {
            //iterate the table until the record found
            IWebElement tableElement = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table"));

            IList<IWebElement> tableRow = tableElement.FindElements(By.TagName("tbody"));

            int RowNo = 0;

            foreach (IWebElement row in tableRow)
            {
                RowNo++;

                IList<IWebElement> rowTD = row.FindElements(By.TagName("td"));

                if (rowTD[0].Text.Equals("Spanish"))
                {
                    //Click delete button
                    Driver.driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + RowNo + "]/tr/td[3]/span[2]")).Click();
                }
            }
        }

        [Then(@"that language should be removed on my listings")]
        public void ThenThatLanguageShouldBeRemovedOnMyListings()
        {
            try
            {
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Remove a Language");

                Thread.Sleep(1000);
                string ExpectedValue = "Spanish";

                //iterate the table until the record found
                IWebElement tableElement = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table"));

                IList<IWebElement> tableRow = tableElement.FindElements(By.TagName("tbody"));

                bool isExist = false;

                foreach (IWebElement row in tableRow)
                {   
                    IList<IWebElement> rowTD = row.FindElements(By.TagName("td"));

                    if (rowTD[0].Text.Equals(ExpectedValue))
                    {
                        CommonMethods.test.Log(LogStatus.Fail, "Test Failed");
                        isExist = true;
                    }
                }

                if(!isExist)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Removed a Language Successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "LanguageRemoved");
                }
            }
            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }

        }

       
    }
}
