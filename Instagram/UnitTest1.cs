using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace InstagramAutomationTests
{
    [TestClass]
    public class InstagramTests
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [TestInitialize]
        public void Setup()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }

        [TestCleanup]
        public void Teardown()
        {
            driver.Quit();
        }

        [TestMethod]
        public void TestLogin()
        {
            // Replace these with your Instagram username and password
            string username = "vishuu_2810";
            string password = "vishu@2810";

            // Navigate to Instagram login page
            driver.Navigate().GoToUrl("https://www.instagram.com/accounts/login/");

            // Wait for the username input field to be present
            IWebElement usernameInput = wait.Until(driver => driver.FindElement(By.Name("username")));

            // Find username and password input fields, and login button
            IWebElement passwordInput = driver.FindElement(By.Name("password"));
            IWebElement loginButton = driver.FindElement(By.XPath("//button[@type='submit']"));

            // Enter username and password
            usernameInput.SendKeys(username);
            passwordInput.SendKeys(password);

            // Click login button
            loginButton.Click();

            // Wait for login process to complete
            wait.Until(driver => driver.Url.Contains("instagram.com"));

            // Verify if login was successful (replace with appropriate assertion)
            Assert.IsTrue(driver.Url.Contains("instagram.com"), "Login failed!");
        }

        [TestMethod]
        public void TestPostPhotoOrVideo()
        {
            // Replace this with the path to the image or video you want to upload
            string pathToImage = @"C:\Users\vishw\OneDrive\Pictures\Screenshots\Screenshot 2024-04-14 191055.png";

            // Navigate to Instagram home page
            driver.Navigate().GoToUrl("https://www.instagram.com/");

            // Perform login (you can reuse the login function from TestLogin)

            // Wait for the 'New Post' button to be present
            IWebElement newPostButton = wait.Until(driver => driver.FindElement(By.XPath("//div[@aria-label='New Post']")));

            // Click on the 'New Post' button
            newPostButton.Click();

            // Wait for the new post modal to appear
            IWebElement uploadInput = wait.Until(driver => driver.FindElement(By.XPath("//input[@type='file']")));

            // Click on 'Upload' button and select the image or video file
            uploadInput.SendKeys(pathToImage);


            // Wait for upload to complete

            // Add more steps to complete the posting process
        }

        [TestMethod]
        public void TestFollowUnfollowUser()
        {
            TestLogin();
            // Replace this with the username of the user you want to follow/unfollow
            string userToFollow = "sardaar_amritpal_singh_khalsa";

            // Navigate to the user's profile page
            driver.Navigate().GoToUrl($"https://www.instagram.com/{userToFollow}/");

            // Wait for the page to load completely
            wait.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));

            // Wait for the 'Follow' button to be present
            IWebElement followButton = wait.Until(driver =>
            {
                try
                {
                    var element = driver.FindElement(By.XPath("//button[contains(text(), 'Follow')]"));
                    if (element.Displayed && element.Enabled)
                        return element;
                    return null;
                }
                catch (NoSuchElementException)
                {
                    return null;
                }
            });

            // Click on the 'Follow' button
            followButton.Click();

            // Wait for the 'Following' button to appear
            IWebElement followingButton = wait.Until(driver =>
            {
                try
                {
                    var element = driver.FindElement(By.XPath("//button[contains(text(), 'Following')]"));
                    if (element.Displayed && element.Enabled)
                        return element;
                    return null;
                }
                catch (NoSuchElementException)
                {
                    return null;
                }
            });

            // Click on the 'Following' button to unfollow the user
            followingButton.Click();

            // Wait for the 'Follow' button to appear again
            IWebElement newFollowButton = wait.Until(driver =>
            {
                try
                {
                    var element = driver.FindElement(By.XPath("//button[contains(text(), 'Follow')]"));
                    if (element.Displayed && element.Enabled)
                        return element;
                    return null;
                }
                catch (NoSuchElementException)
                {
                    return null;
                }
            });

            // Verify if the 'Follow' button is visible again, indicating successful unfollow
            Assert.IsTrue(newFollowButton.Displayed, "Unfollow failed!");

            /*
            // Wait for the 'Follow' button to be present
            IWebElement followButton = wait.Until(driver => driver.FindElement(By.XPath("//button[contains(text(), 'Follow')]")));

            // Click on the 'Follow' button
            followButton.Click();

            // Wait for the 'Following' button to appear
            IWebElement followingButton = wait.Until(driver => driver.FindElement(By.XPath("//button[contains(text(), 'Following')]")));

            // Click on the 'Following' button to unfollow the user
            followingButton.Click();

            // Wait for the 'Follow' button to appear again
            IWebElement newFollowButton = wait.Until(driver => driver.FindElement(By.XPath("//button[contains(text(), 'Follow')]")));

            // Verify if the 'Follow' button is visible again, indicating successful unfollow
            Assert.IsTrue(newFollowButton.Displayed, "Unfollow failed!");*/
        }
    }
}
