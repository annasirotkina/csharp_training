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
            }
            // проверка наличия хотя бы одной группы
            if (app.Group.CheckGroup() == false)
            {
                app.Group.Create(new GroupData(GenerateRandomString(30)));
            }
            
            GroupData group = GroupData.GetAll()[0]; // берем первую попавшуся группу
            List<ContactData> oldList = group.GetContacts(); // получаем список контактов, входящих в нее
            // проверка на то, что если все контакты уже в группе, то создать новый контакт
            int i = ContactData.GetAll().Except(oldList).Count();
            if (i == 0)
            {
                app.Contact.Create(new ContactData(GenerateRandomString(30), GenerateRandomString(30)));
            }

            ContactData contact = ContactData.GetAll().Except(oldList).First(); // получаем список контактов, не входящих в нее
                                                             
            
            app.Contact.AddContactToGroup(contact, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Add(contact);
            newList.Sort();
            oldList.Sort();
            Assert.AreEqual(oldList, newList);
        }
    }
}
