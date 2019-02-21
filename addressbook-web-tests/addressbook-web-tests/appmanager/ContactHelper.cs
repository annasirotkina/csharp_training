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
        
        public List<ContactData> GetContactList()
        {
            List<ContactData> contacts = new List<ContactData>();
            manager.Navigator.GoToHomePage();
            ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("tr[name=\"entry\"]"));
            foreach (IWebElement element in elements)
            {
                var cells = element.FindElements(By.TagName("td"));
                string lastname = cells[1].Text;
                string firstname = cells[2].Text;
                string id = cells[0].FindElement(By.TagName("input")).GetAttribute("value");

                contacts.Add(new ContactData(firstname, lastname));
            }
            return contacts;
        }
         

        public ContactHelper Remove(int v)
        {
            SelectContact(v);
            RemoveContact();
            CloseAlert();
            manager.Navigator.GoToHomePage();
            return this;
        }

        public ContactHelper Modify(int v, ContactData newData)
        {
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

        public bool CheckContact()
        {
            return IsElementPresent(By.Name("selected[]"));
        }
    }
}
