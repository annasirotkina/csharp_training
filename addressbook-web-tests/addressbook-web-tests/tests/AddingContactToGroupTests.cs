using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class AddingContactToGroupTests : AuthTestBase
    {
        [Test]

        public void TestAddingContactToGroup()
        {
            //проверка наличия хотя бы одного контакта

            if (app.Contact.CheckContact() == false)
            {
                app.Contact.Create(new ContactData(GenerateRandomString(30), GenerateRandomString(30)));
                //contact.Add(new ContactData(GenerateRandomString(30), GenerateRandomString(30)));
            }
            // проверка наличия хотя бы одной группы
            //app.Navigator.GoToGroupsPage();
            // if (app.Group.CheckGroup() == false)
            //{
            //     GroupData group = new GroupData("aaa");
            //     group.Header = "ddd";
            //     group.Footer = "fff";
            //     app.Group.Create(group);
            //  }
            
            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();
            ContactData contact = ContactData.GetAll().Except(oldList).First();

            app.Contact.AddContactToGroup(contact, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Add(contact);
            newList.Sort();
            oldList.Sort();
            Assert.AreEqual(oldList, newList);
        }
    }
}
