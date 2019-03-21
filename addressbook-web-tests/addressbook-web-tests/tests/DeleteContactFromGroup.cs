using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    class DeleteContactFromGroupTests : AuthTestBase
    {
        [Test]

        public void TestDeleteContactFromGroup()
        {
            // проверка наличия хотя бы одной группы
            if (app.Group.CheckGroup() == false)
            {
                app.Group.Create(new GroupData(GenerateRandomString(30)));
            }

            GroupData group = GroupData.GetAll()[0];
                        
            int i = group.GetContacts().Count();
            if (i == 0)
            {
                app.Contact.Create(new ContactData(GenerateRandomString(30), GenerateRandomString(30)));
            }
            List<ContactData> oldList = group.GetContacts();
            ContactData contact = oldList[0];

            app.Contact.DeleteContactFromGroup(contact, group);

            List<ContactData> newList = GroupData.GetAll()[0].GetContacts();
            oldList.RemoveAt(0);
            oldList.Sort();
            newList.Sort();
            Assert.AreEqual(oldList, newList);
        }
    }
}
