﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            List<ContactData> oldContacts = app.Contact.GetContactList();
           oldContacts.ForEach(Console.WriteLine); //написано для дебага, печать списка
            
            app.Contact.Remove(0);

            List<ContactData> newContacts = app.Contact.GetContactList(); // создается тот же самый список по количеству элементов что и в oldContacts
            newContacts.ForEach(Console.WriteLine);//написано для дебага, печать списка
            oldContacts.RemoveAt(0);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
