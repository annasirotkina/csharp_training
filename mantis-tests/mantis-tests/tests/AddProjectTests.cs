using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class AddProjectTests : Auth_TestBase
    {
        [Test]
        public void TestAddProject()
        {
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "root"
            };

            List<ProjectData> oldList = app.API.GetAllProject(account);

            ProjectData newData = new ProjectData()
            {
                Name = "project1",
                Description = "description1"
            };

            foreach (ProjectData project in oldList)
            {
                if (project.Name == newData.Name)
                {
                    app.API.DeleteProject(account, project);
                }
            }
            oldList = app.API.GetAllProject(account);
            app.Project.Add(newData);
            List<ProjectData> newList = app.API.GetAllProject(account);
            oldList.Add(newData);
            oldList.Sort();
            newList.Sort();

            Assert.AreEqual(oldList, newList);
        }

    }
}