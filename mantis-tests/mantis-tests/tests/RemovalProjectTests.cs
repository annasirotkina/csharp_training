using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;


namespace mantis_tests
{
    [TestFixture]
    public class RemovalProjectTests : Auth_TestBase
    {
        [Test]
        public void TestRemovalProject()
        {
            List<ProjectData> oldList = app.Project.GetProjects();
            ProjectData existingProject = oldList[0];
            if (existingProject == null)
            {
                ProjectData newData = new ProjectData()
                {
                    Name = "project1",
                    Description = "description1"
                };


                app.Project.Add(newData);
            }

            oldList = app.Project.GetProjects();
            app.Project.Remove(existingProject);

            List<ProjectData> newList = app.Project.GetProjects();
            oldList.RemoveAt(0);
            oldList.Sort();
            newList.Sort();

            Assert.AreEqual(oldList, newList);
        }
    }
}