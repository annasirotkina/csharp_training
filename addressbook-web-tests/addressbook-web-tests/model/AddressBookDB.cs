using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB;

namespace WebAddressbookTests
{
    public class AddressBookDB : LinqToDB.Data.DataConnection // класс для соединения с БД
    {
        public AddressBookDB() : base("AddressBook") { } // вызывает конструктор базового класса и указывает название БД

        public ITable<GroupData> Groups { get { return GetTable<GroupData>(); } } // возвращает таблицу данных
        public ITable<ContactData> Contacts { get { return GetTable<ContactData>(); } }
    }
}
