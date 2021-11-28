using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Appium.Windows;
using System;

namespace Appium__Automation_Test_Of_Desktop_Sumator_App
{
    public class Tests
    {
        private AppiumLocalService appiumLocalService;
        private WindowsDriver<WindowsElement> driver;

        [SetUp]
        public void Setup()
        {
            //Start Appium server
            appiumLocalService = new AppiumServiceBuilder().UsingAnyFreePort().Build();
            appiumLocalService.Start();

            var appiumOptions = new AppiumOptions();
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.App,
                @"C:\Adi\Automation docs\Day7\WindowsFormsApp.exe");
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Windows");
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.DeviceName, "WindowsPC");
            driver = new WindowsDriver<WindowsElement>(
                new Uri("http://[::1]:4723/wd/hub"), appiumOptions);
        }

        [Test]
        public void Test_WinForm_Summator_App()
        {
            var textBoxFirstNum = driver.FindElementByAccessibilityId("textBoxFirstNum");
            textBoxFirstNum.SendKeys("5");
            var textBoxSecondNum = driver.FindElementByAccessibilityId("textBoxSecondNum");
            textBoxSecondNum.SendKeys("8");
            var buttonCalc = driver.FindElementByAccessibilityId("buttonCalc");
            buttonCalc.Click();
            var textBoxSum = driver.FindElementByAccessibilityId("textBoxSum");
            Assert.AreEqual("13", textBoxSum.Text);
        }
        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}