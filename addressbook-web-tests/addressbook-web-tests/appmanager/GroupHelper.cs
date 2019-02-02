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
    public class GroupHelper : HelperBase
    {
        public GroupHelper(ApplicationManager manager) : base(manager)
        {
        }

        public GroupHelper Create(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();

            InitGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupsPage();
            return this;
        }

        public List<GroupData> GetGroupList()
        {
            List<GroupData> groups = new List<GroupData>();
            manager.Navigator.GoToGroupsPage();
            ICollection<IWebElement>elements = driver.FindElements(By.CssSelector("span.group")); // считывается список элементов со страницы
            foreach (IWebElement element in elements) // для каждого элемента в коллекции нужно выполнить ...
            {
                groups.Add(new GroupData(element.Text));  // вот эти действия (преобразовать текст в объект типа GroupData) 
            }
            return groups;
        }

        public GroupHelper Remove(int v)
        {
            manager.Navigator.GoToGroupsPage();

            if (! IsElementPresent(By.Name("selected[]")))
            {
                GroupData group = new GroupData("aaa");
                group.Header = "ddd";
                group.Footer = "fff";
                Create(group);
            }

            SelectGroup(v);
            RemoveGroup();
            ReturnToGroupsPage();
            return this;
        }
  
        public bool GroupExist()
        {
            return IsElementPresent(By.Name("selected[]"));
        }

        public GroupHelper Modify(int v, GroupData newData)
        {
            manager.Navigator.GoToGroupsPage();
            if (! IsElementPresent(By.Name("selected[]")))
            {
                GroupData group = new GroupData("aaa");
                group.Header = "ddd";
                group.Footer = "fff";
                Create(group);
            }
            
            SelectGroup(v);
            InitGroupModification();
            FillGroupForm(newData);
            SubmitGroupModification();
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            return this;
        }

        public GroupHelper InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }
        public GroupHelper FillGroupForm(GroupData group)
        {
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
            return this;
        }
        
        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }
        public GroupHelper ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
            return this;
        }
        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index+1) + "]")).Click();
            return this;
        }
    }
}
