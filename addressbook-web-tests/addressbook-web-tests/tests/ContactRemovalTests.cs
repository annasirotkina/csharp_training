using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Threading;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            //проверка наличия хотя бы одного контакта

            if (app.Contact.CheckContact() == false)
            {
                ContactData contact = new ContactData("Ivan", "Ivanov");
                app.Contact.Create(contact);
            }
            //сам тест на удаление
            List<ContactData> oldContacts = app.Contact.GetContactList();
            ContactData toBeRemoved = oldContacts[0];
            app.Contact.Remove(0);

            Thread.Sleep(1000); //в этом месте нужна задержка, так как иначе не успевает прогрузиться и создается newContacts c удаленным элементом
            
            Assert.AreEqual(oldContacts.Count - 1, app.Contact.GetContactCount());

            List<ContactData> newContacts = app.Contact.GetContactList();
            oldContacts.RemoveAt(0);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                Assert.AreNotEqual(contact.Id, toBeRemoved.Id);
            }
        }
    }
}
