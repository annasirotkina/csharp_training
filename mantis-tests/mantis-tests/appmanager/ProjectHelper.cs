using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Text.RegularExpressions;

namespace mantis_tests
{
    public class ProjectHelper : HelperBase
    {
        public ProjectHelper(ApplicationManager manager) : base(manager) { }

        public ProjectHelper Add(ProjectData project)
        {
            manager.Menu.GoToManageMenu();
            manager.Menu.GoToProjectForm();
            InitAddProject();
            FillProjectForm(project);
            SubmitAddProject();
            return this;
        }

        public void Remove(ProjectData project)
        {
            manager.Menu.GoToManageMenu();
            manager.Menu.GoToProjectForm();
            SelectProject(project);
            RemoveProject();
            SubmitRemoveProject();
        }

        public List<ProjectData> GetProjects()
        {
            List<ProjectData> projects = new List<ProjectData>();
            manager.Menu.GoToManageMenu();
            manager.Menu.GoToProjectForm();
            IList<IWebElement> rows = driver.FindElements(By.ClassName("table-responsive"))[0].FindElements(By.TagName("tr"));
            foreach (IWebElement row in rows)
            {
                if (row != rows[0])
                {
                    IWebElement link = row.FindElement(By.TagName("a"));
                    string name = link.Text;
                    string href = link.GetAttribute("href");
                    Match m = Regex.Match(href, @"\d+$");
                    string id = m.Value;

                    projects.Add(new ProjectData()
                    {
                        Name = name,
                        Id = id
                    });
                }
            }

            return projects;
        }
        public void SubmitAddProject()
        {
            driver.FindElement(By.XPath("//input[@type='submit' and @value='Добавить проект']")).Click();
        }

        public ProjectHelper FillProjectForm(ProjectData project)
        {
            driver.FindElement(By.Name("name")).SendKeys(project.Name);
            driver.FindElement(By.Name("description")).SendKeys(project.Description);
            return this;
        }

        public void InitAddProject()
        {
            driver.FindElement(By.CssSelector("[type='submit']")).Click();
        }

        public void RemoveProject()
        {
            driver.FindElement(By.XPath("//input[@type='submit' and @value='Удалить проект']")).Click();
        }

        public void SubmitRemoveProject()
        {
            driver.FindElement(By.XPath("//input[@type='submit' and @value='Удалить проект']")).Click();
        }

        public void SelectProject(ProjectData project)
        {
            driver.FindElement(By.XPath("//a[@href='manage_proj_edit_page.php?project_id=" + project.Id + "']")).Click();
        }
    }
}