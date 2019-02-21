using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class GroupData : IEquatable<GroupData>, IComparable<GroupData>
    {
        public GroupData(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        
        public string Header { get; set; }
        public string Footer { get; set; }

        public string Id { get; set; }

        public int CompareTo(GroupData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return Name.CompareTo(other.Name);
        }

        public bool Equals(GroupData other)
        {
            if (Object.ReferenceEquals(other, null)) // если тот объект, с которым сравниваем равен 0, 
            {                   // то вернуть false, так как тот объект, с которым мы сравниваем точно не 0
                return false;
            }

            if (Object.ReferenceEquals(this, other)) // если это один и тот же объект
            {
                return true;
            }

            return Name == other.Name;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override string ToString()
        {
            return "name="  + Name;
        }
    }
}
