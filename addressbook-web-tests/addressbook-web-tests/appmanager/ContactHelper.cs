using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }

        public ContactHelper Create(ContactData contact)
        {
            InitContactCreation();
            FillContactData(contact);
            SubmitContactData();

            manager.Navigator.GoToHomePage();
            return this;
        }

        public ContactHelper Remove(int v)
        {
            if (! IsElementPresent(By.Name("selected[]")))
            {
                ContactData contact = new ContactData("Ivan", "Ivanov");
                Create(contact);
            }
            
            SelectContact(v);
            RemoveContact();
            CloseAlert();
            return this;
        }

        public ContactHelper Modify(int v, ContactData newData)
        {
            if (!IsElementPresent(By.Name("selected[]")))
            {
                ContactData contact = new ContactData("Ivan", "Ivanov");
                Create(contact);
            }

            InitContactModification(v);
            FillContactData(newData);
            SubmitContactModification();

            manager.Navigator.GoToHomePage();
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public ContactHelper InitContactModification(int v)
        {
            driver.FindElement(By.XPath("(//img[@alt='Edit'])[" + (v+1) + "]")).Click();
            return this;
        }

        public void CloseAlert()
        {
            driver.SwitchTo().Alert().Accept();
        }

        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            return this;
        }

        public ContactHelper SelectContact(int v)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (v+1) + "]")).Click();
            return this;
        }

        public ContactHelper InitContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }
        public ContactHelper FillContactData(ContactData contact)
        {
            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("lastname"), contact.Lastname);
            return this;
        }
        public ContactHelper SubmitContactData()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }
    }
}
