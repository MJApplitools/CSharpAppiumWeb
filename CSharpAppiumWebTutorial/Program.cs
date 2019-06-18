using System;
using Applitools.Appium;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace CSharpAppiumWebTutorial
{
    class Program
    {
        static void Main(string[] args)
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
    }
}
