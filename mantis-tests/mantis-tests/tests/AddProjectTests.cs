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
            List<ProjectData> oldList = app.Project.GetProjects();

            ProjectData newData = new ProjectData()
            {
                Name = "project1",
                Description = "description1"
            };

            foreach (ProjectData project in oldList)
            {
                if (project.Name == newData.Name)
                {
                    app.Project.Remove(project);
                }
            }
            oldList = app.Project.GetProjects();
            app.Project.Add(newData);
            List<ProjectData> newList = app.Project.GetProjects();
            oldList.Add(newData);
            oldList.Sort();
            newList.Sort();

            Assert.AreEqual(oldList, newList);
        }

    }
}