using framework.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Text;

namespace framework.Helpers
{
    public class WebDriverUtility
    {
        public RemoteWebDriver GetDriver(DriverOptions driverOptions)
        {
            switch (driverOptions)
            {
                case InternetExplorerOptions internetExplorerOptions:
                    internetExplorerOptions = new InternetExplorerOptions();
                    return new InternetExplorerDriver(internetExplorerOptions);
                case FirefoxOptions firefoxOptions:
                    firefoxOptions.AddAdditionalCapability(CapabilityType.BrowserName, "firefox");
                    firefoxOptions.AddAdditionalCapability(CapabilityType.Platform, new Platform(PlatformType.Windows));
                    firefoxOptions.BrowserExecutableLocation = @"C:\Program Files (x86)\Mozilla Firefox\firefox.exe";
                    return new FirefoxDriver(firefoxOptions);
                case ChromeOptions chromeOptions:
                    chromeOptions.AddAdditionalCapability(CapabilityType.EnableProfiling, true, true);
                    chromeOptions.BinaryLocation = @"C:\Program Files\Google\Chrome\Application\chrome.exe";
                    chromeOptions.AddAdditionalCapability(CapabilityType.EnableProfiling, true, true);
                    return new ChromeDriver(chromeOptions);
                default:
                    return new RemoteWebDriver(new Uri("http://172.17.212.150:30001/wd/hub"), driverOptions.ToCapabilities());
            }
        }

        public virtual void NaviateSite()
        {
            //DriverContext.Browser.GoToUrl(Settings.AUT);
            LogHelpers.Write("Opened the browser !!!");
        }


        public DriverOptions GetDriverOption(BrowserType browserType)
        {
            return browserType switch
            {
                BrowserType.InternetExplorer => new InternetExplorerOptions(),
                BrowserType.FireFox => new FirefoxOptions(),
                BrowserType.Chrome => new ChromeOptions(),
                BrowserType.Remote => null,
                _ => new ChromeOptions(),
            };
        }
    }
}
