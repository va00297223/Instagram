using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using System.Threading;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            SubmitForm();
            EnterInvalidEmailAddress();
            EnterInvalidPassword();
        }

        // Custom wait method to wait until an element is visible
        static IWebElement WaitForElementVisible(IWebDriver driver, By locator, int timeoutInSeconds)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            return wait.Until(driver => driver.FindElement(locator));
        }

        // Test case-1: Submitting the form without filling the data
        static void SubmitForm()
        {
            var driver = new EdgeDriver();
            try
            {
                driver.Url = "https://www.instagram.com/accounts/emailsignup/";

                // Wait for the email/phone field to be visible
                var emailOrPhoneField = WaitForElementVisible(driver, By.Name("emailOrPhone"), 10);

                emailOrPhoneField.SendKeys(""); // Enter your email or phone number here

                // Find the signup button
                var signupButton = driver.FindElement(By.CssSelector("button[type='submit']"));

                // Check if the signup button is enabled before clicking
                if (signupButton.Enabled)
                {
                    // Click the button
                    signupButton.Click();
                }
                else
                {
                    Console.WriteLine("Signup button is disabled.");
                    // Handle the disabled button scenario
                }

                Thread.Sleep(5000); // This is just for demonstration, replace with explicit wait for any expected condition

                var errorMessages = driver.FindElements(By.CssSelector(".sds-control-status.error")).Select((x) => x.Text);

                if (errorMessages.Any())
                {
                    foreach (var errorMessage in errorMessages)
                    {
                        Console.WriteLine(errorMessage);
                    }
                    Console.WriteLine("Test is Passed.");
                }
                else
                {
                    Console.WriteLine("Test-1 is failed.");
                }
                Console.ReadLine();
            }
            finally
            {
                driver.Quit();
            }
        }

        // Test-2: Entering an invalid email address
        static void EnterInvalidEmailAddress()
        {
            var driver = new EdgeDriver();
            try
            {
                driver.Url = "https://www.instagram.com/accounts/emailsignup/";

                var emailOrPhoneField = driver.FindElement(By.Name("emailOrPhone"));
                emailOrPhoneField.SendKeys("xyz@gmail"); // Enter an invalid email address

                var fullNameField = driver.FindElement(By.Name("fullName"));
                fullNameField.SendKeys("XYZ ABC");

                var usernameField = driver.FindElement(By.Name("username"));
                usernameField.SendKeys("XYZ123");

                var passwordField = driver.FindElement(By.Name("password"));
                passwordField.SendKeys("P@ssw0rd");

                var signupButton = driver.FindElement(By.CssSelector("button[type='submit']"));
    
                // Check if the signup button is enabled before clicking
                if (signupButton.Enabled)
                {
                    // Click the button
                    signupButton.Click();
                }
                else
                {
                    Console.WriteLine("Signup button is disabled.");
                    // Handle the disabled button scenario
                }

                Thread.Sleep(5000); // This is just for demonstration, replace with explicit wait for any expected condition

                var errorMessages = driver.FindElements(By.CssSelector(".sds-control-status.error")).Select((x) => x.Text);

                if (errorMessages.Any())
                {
                    foreach (var errorMessage in errorMessages)
                    {
                        Console.WriteLine(errorMessage);
                    }
                    Console.WriteLine("Test-2 is Passed.");
                }
                else
                {
                    Console.WriteLine("Test-2 is failed.");
                }
                Console.ReadLine();
            }
            finally
            {
                driver.Quit();
            }
        }
        // Test-3: Entering an invalid password
        static void EnterInvalidPassword()
        {
            var driver = new EdgeDriver();
            try
            {
                driver.Url = "https://www.instagram.com/accounts/emailsignup/";

                var emailOrPhoneField = driver.FindElement(By.Name("emailOrPhone"));
                emailOrPhoneField.SendKeys("xyz@gmail.com");

                var fullNameField = driver.FindElement(By.Name("fullName"));
                fullNameField.SendKeys("XYZ ABC");

                var usernameField = driver.FindElement(By.Name("username"));
                usernameField.SendKeys("XYZ123");

                var passwordField = driver.FindElement(By.Name("password"));
                passwordField.SendKeys("mmmmmmmm"); // Enter an invalid password

                var signupButton = driver.FindElement(By.CssSelector("button[type='submit']"));

                // Check if the signup button is enabled before clicking
                if (signupButton.Enabled)
                {
                    // Click the button
                    signupButton.Click();
                }
                else
                {
                    Console.WriteLine("Signup button is disabled.");
                    // Handle the disabled button scenario
                }

                Thread.Sleep(5000); // This is just for demonstration, replace with explicit wait for any expected condition

                var errorMessages = driver.FindElements(By.CssSelector(".sds-control-status.error")).Select((x) => x.Text);

                if (errorMessages.Any())
                {
                    foreach (var errorMessage in errorMessages)
                    {
                        Console.WriteLine(errorMessage);
                    }
                    Console.WriteLine("Test-3 is Passed.");
                }
                else
                {
                    Console.WriteLine("Test-3 is failed.");
                }
                Console.ReadLine();
            }
            finally
            {
                driver.Quit();
            }
        }
    }
}

        
    
