using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : GroupTestBase
    {


        [Test]
        public void GroupRemovalTest()
        {
            // проверка наличия хотя бы одной группы
            app.Navigator.GoToGroupsPage();
            if (app.Group.CheckGroup() == false)
            {
                GroupData group = new GroupData("aaa");
                group.Header = "ddd";
                group.Footer = "fff";
                app.Group.Create(group);
            }

            // сам тест на удаление

            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData toBeRemoved = oldGroups[0];

            app.Group.Remove(toBeRemoved);

            Assert.AreEqual(oldGroups.Count - 1, app.Group.GetGroupCount());

            List<GroupData> newGroups = GroupData.GetAll();

            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }
        }
    }
}
