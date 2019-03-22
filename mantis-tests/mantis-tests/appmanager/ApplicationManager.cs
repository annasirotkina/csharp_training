using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected string baseURL;

        public RegistrationHelper Registration { get; private set; }
        public FtpHelper Ftp { get; private set; }

        public LoginHelper loginHelper;
        public ProjectHelper projectHelper;
        public ManagmentMenuHelper menu;

        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost:8080/mantisbt-2.20.0/";
            Registration = new RegistrationHelper(this);
            Ftp = new FtpHelper(this);
            FirefoxOptions options = new FirefoxOptions();
            options.BrowserExecutableLocation = @"c:\Program Files\Mozilla Firefox\firefox.exe";
            options.UseLegacyImplementation = true;
            Ftp = new FtpHelper(this);
            loginHelper = new LoginHelper(this);
            projectHelper = new ProjectHelper(this);
            menu = new ManagmentMenuHelper(this, baseURL);
        }

        ~ApplicationManager()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        public static ApplicationManager GetInstance()
        {
            if (! app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.driver.Url = newInstance.baseURL + "/login_page.php";
                app.Value = newInstance;
            }
            return app.Value;
        }

        public IWebDriver Driver
        {
            get
            {
                return driver;
            }
        }
        public LoginHelper Auth
        {
            get
            {
                return loginHelper;
            }
        }

        public ProjectHelper Project
        {
            get
            {
                return projectHelper;
            }
        }

        public ManagmentMenuHelper Menu
        {
            get
            {
                return menu;
            }
        }

    }
}
