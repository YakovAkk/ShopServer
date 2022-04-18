using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDomain.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class NameCollectionAttribute : Attribute
    {
        public string CollectionName { get; set; }
        public NameCollectionAttribute(string name)
        {
            CollectionName = name;
        }
    }
}
