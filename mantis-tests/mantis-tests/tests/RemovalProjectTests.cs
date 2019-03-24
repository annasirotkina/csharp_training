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
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "root"
            };

            List<ProjectData> oldList = app.API.GetAllProject(account);

            ProjectData existingProject = oldList[0];
            if (existingProject == null)
            {
                ProjectData newData = new ProjectData()
                {
                    Name = "project1",
                    Description = "description1"
                };


                app.API.AddProject(account, newData);
            }

            oldList = app.API.GetAllProject(account);
            app.Project.Remove(existingProject);

            List<ProjectData> newList = app.API.GetAllProject(account);
            oldList.RemoveAt(0);
            oldList.Sort();
            newList.Sort();

            Assert.AreEqual(oldList, newList);
        }
    }
}