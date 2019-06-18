using System;
using Applitools.Appium;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace CSharpAppiumWebTutorial
{
    class Program
    {
        public static void IosTest()
        {
            //iOS Test
            Eyes eyes = new Eyes();
            eyes.ApiKey = Environment.GetEnvironmentVariable("APPLITOOLS_API_KEY");

            DesiredCapabilities dc = new DesiredCapabilities();
            dc.SetCapability("platformName", "iOS");
            dc.SetCapability("browserName", "Safari");
            dc.SetCapability("deviceName", "iPhone XR");
            dc.SetCapability("automationName", "XCUITest");
            dc.SetCapability("platformVersion", "12.1");

            RemoteWebDriver driver = new RemoteWebDriver(new Uri("http://localhost:4723/wd/hub"), dc);

            //Error in tutorial on this line, should be below
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60); 

            try
            {
                eyes.Open(driver, "Hello World!", "C# Appium Web");
                driver.Url = "https://applitools.com/helloworld";
                eyes.CheckWindow("Hello!");
                driver.FindElement(By.TagName("button")).Click();
                eyes.CheckWindow("Click!");
                eyes.Close(); 
            }
            finally
            {
                eyes.AbortIfNotClosed();
                driver.Quit(); 
            }
        }

        public static void AndroidTest()
        {
            Eyes eyes = new Eyes();
            eyes.ApiKey = Environment.GetEnvironmentVariable("APPLITOOLS_API_KEY");

            DesiredCapabilities dc = new DesiredCapabilities();
            dc.SetCapability("platformName", "Android");
            dc.SetCapability("platformVersion", "10");
            dc.SetCapability("deviceName", "Pix3");
            dc.SetCapability("browserName", "chrome");
            dc.SetCapability("automationName", "uiautomator2"); 
            RemoteWebDriver driver = new RemoteWebDriver(new Uri("http://localhost:4723/wd/hub"), dc);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);

            try
            {
                eyes.Open(driver, "Hello World", "Appium Native C#");
                driver.Url = "https://applitools.com/helloworld";
                eyes.CheckWindow("Hello!");
                driver.FindElement(By.TagName("button")).Click();
                eyes.CheckWindow("Click!");
                eyes.Close(); 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex); 
            }
            finally
            {
                driver.Quit();
                eyes.AbortIfNotClosed(); 
            }
        }
    }
}
