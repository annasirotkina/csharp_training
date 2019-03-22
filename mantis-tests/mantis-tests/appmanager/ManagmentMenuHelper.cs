using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests
{
    public class ManagmentMenuHelper : HelperBase
    {
        private string baseURL;

        public ManagmentMenuHelper(ApplicationManager manager, string baseURL) : base(manager)
        {
            this.baseURL = baseURL;
        }

        public void GoToManageMenu()
        {
            if (driver.Url == baseURL + "/mantisbt-2.20.0/manage_overview_page.php")
            {
                return;
            }
            driver.FindElement(By.XPath("//a[@href='/mantisbt-2.20.0/manage_overview_page.php']")).Click();
        }

        public void GoToProjectForm()
        {
            if (driver.Url == baseURL + "/mantisbt-2.20.0/manage_proj_page.php")
            {
                return;
            }
            driver.FindElement(By.XPath("//*[text()='Управление проектами']")).Click();
        }
    }
}
