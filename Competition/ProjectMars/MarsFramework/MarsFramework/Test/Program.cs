using MarsFramework.Global;
using MarsFramework.Pages;
using NUnit.Framework;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MarsFramework.Global.GlobalDefinitions;

namespace MarsFramework
{
    /*
       The main class with test cases
       Contains all the test cases performing tests on Profile, Share Skill and ManageListing
       */
    /// <summary>
    /// The main <c>Program</c> class.
    /// Contains all the test cases performing tests on Profile, Share Skill and ManageListing
    /// </summary>
    /// 
    public class Program
    {
        [TestFixture]
        [Category("Sprint1")]
        class Tenant : Global.Base
        {
            [Test]
            public void UserAccount()
            {

                // Creates a toggle for the given test, adds all log events under it    
                test = extent.StartTest("Search for a Property");

                // Create an class and object to call the method
                Profile obj = new Profile();
                obj.EditProfile();

            }

        }

       
        [TestFixture]
        [Category("Sprint2")]
        class Service : Global.Base
        {
            /// <summary>
            /// Tests Save New Skill in to the Listing
            /// </summary>
            [Test]
            public void SaveNewService()
            {
                //Allocate the number of services to be saved
                int NoOfServices = 2;

                ServiceListing ServiceListingObj = new ServiceListing();

                for (int i = 0; i < NoOfServices; i++)
                {
                    // Creates a toggle for the given test, adds all log events under it    
                    test = extent.StartTest("Save New Service");

                    // Open Share Skill Page
                    if (i == 0)
                    {
                        Profile profilePG = new Profile();
                        profilePG.ViewShareSkillPage();
                    }
                    else
                    {
                        ManageListing manageListingObj = new ManageListing();
                        manageListingObj.ViewShareSkillPage();
                    }

                    try
                    {
                        // Save New Service Listing

                        string ActualResult = ServiceListingObj.SaveNew(i);

                        //If Shared succesfully, the record should display in ManageListings Page
                        string ExpectedResult = "True";

                        Assert.AreEqual(ExpectedResult, ActualResult);
                        
                        // Screenshot
                        String img = SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "ShareSkill_" + i);
                        test.Log(LogStatus.Info, "Share Skill Successfully_" + i + ": " + img);
                    }
                    catch (Exception e)
                    {
                        Base.test.Log(LogStatus.Error, "Error in Shared Skill Save : " + e.Message);
                    }

                }
            }

            /// <summary>
            /// Tests View option for a particular Service 
            /// </summary>
            [Test]
            public void ViewServiceListing()
            {
                // Creates a toggle for the given test, adds all log events under it    
                test = extent.StartTest("View A Listing");

                // View A Service Listing
                ManageListing ManageListingObj = new ManageListing();
                ManageListingObj.ViewManageListingPage();

                try
                {
                    string ActualResult = ManageListingObj.PerformAction("View");

                    //If Action Performed succesfully, page redirects to Service Detail Page
                    string ExpectedResult = "Service Detail";

                    Assert.AreEqual(ExpectedResult, ActualResult);

                    // Screenshot
                    String img = SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "View Service");
                    test.Log(LogStatus.Info, "View Service Successfully"  + img);
                }
                catch (Exception e)
                {
                    Base.test.Log(LogStatus.Error, "Error in View Service : " + e.Message);
                }

            }

            /// <summary>
            /// Tests Edit option for a particular Service 
            /// </summary>
            [Test]
            public void EditServiceListing()
            {
                // Creates a toggle for the given test, adds all log events under it    
                test = extent.StartTest("Edit A Listing");

                // Edit A Service Listing
                ManageListing ManageListingObj = new ManageListing();
                ManageListingObj.ViewManageListingPage();

                try
                {
                    string ActualResult = ManageListingObj.PerformAction("Edit");

                    //If Action Performed succesfully, page redirects to Service Listing Page
                    string ExpectedResult = "ServiceListing";

                    Assert.AreEqual(ExpectedResult, ActualResult);

                    // Screenshot
                    String img = SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "Edit Service");
                    test.Log(LogStatus.Info, "Edit Service Successfully" + img);
                }
                catch (Exception e)
                {
                    Base.test.Log(LogStatus.Error, "Error in Edit Service : " + e.Message);
                }

                //Edit the Service
                ServiceListing serviceListingObj = new ServiceListing();
                //serviceListingObj.SaveNew();
            }

            /// <summary>
            /// Tests Delte option for a particular Service 
            /// </summary>
            [Test]
            public void DeleteServiceListing()
            {
                // Creates a toggle for the given test, adds all log events under it    
                test = extent.StartTest("Delete A Listing");

                // Remove a Service Listing
                ManageListing ManageListingObj = new ManageListing();
                ManageListingObj.ViewManageListingPage();

                try
                {
                    string ActualResult = ManageListingObj.PerformAction("Delete");

                    //If Action Performed succesfully, record cannot be found from ListingManagement
                    string ExpectedResult = "False";

                    Assert.AreEqual(ExpectedResult, ActualResult);

                    // Screenshot
                    string img = SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "Delete Service");
                    test.Log(LogStatus.Info, "Delete Service Successfully" + img);
                }
                catch (Exception e)
                {
                    Base.test.Log(LogStatus.Error, "Error in Delete Service : " + e.Message);
                }

            }

            /// <summary>
            /// Tests DeActivate option for a particular Service 
            /// </summary>
            [Test]
            public void DeactivateAService()
            {
                // Creates a toggle for the given test, adds all log events under it    
                test = extent.StartTest("Deactivate A Service Listing");

                // Calling Manage Listing and Deactivate a Service
                ManageListing ManageListingObj = new ManageListing();
                ManageListingObj.ViewManageListingPage();

                try
                {
                    bool status = ManageListingObj.DeActivateService();

                    Assert.False(status);

                    // Screenshot
                    string img = SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "DeActivate Service");
                    test.Log(LogStatus.Info, "DeActivated Service Successfully" + img);
                }
                catch (Exception e)
                {
                    Base.test.Log(LogStatus.Error, "Error in De-Activating Service : " + e.Message);
                }
            }
        }
    }
}