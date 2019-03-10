using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : GroupTestBase
    {
        [Test]
        public void GroupModificationTest()
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

            // сам тест на изменение

            GroupData newData = new GroupData("zzz");
            newData.Header = null;
            newData.Footer = null;

            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData toBeModified = oldGroups[0];

            app.Group.Modify(toBeModified, newData);

            Assert.AreEqual(oldGroups.Count, app.Group.GetGroupCount());

            List<GroupData> newGroups = GroupData.GetAll();
            toBeModified.Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                if (group.Id == toBeModified.Id)
                {
                    Assert.AreEqual(newData.Name, group.Name);
                }
            }
        }
    }
}
