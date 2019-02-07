using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            //проверка наличия хотя бы одного контакта

            if (app.Contact.CheckContact() == false)
            {
                ContactData contact = new ContactData("Ivan", "Ivanov");
                app.Contact.Create(contact);
            }
            //сам тест на изменение
            
            List<ContactData> oldContacts = app.Contact.GetContactList();
            ContactData newData = new ContactData("Sidr", "Sidorov");
            
            app.Contact.Modify(0, newData);

           List<ContactData> newContacts = app.Contact.GetContactList();
           oldContacts[0].Firstname = newData.Firstname;
           oldContacts[0].Lastname = newData.Lastname;
           oldContacts.Sort();
           newContacts.Sort();
           Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
