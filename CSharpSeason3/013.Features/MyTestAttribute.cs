using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _013.Features
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class MyTestAttribute : Attribute
    {
        public string Description { get; set; }
        public string VersionNumber { get; set; }
        public int ID { get; set; }

        public MyTestAttribute(string desc)
        {
            this.Description = desc;
        }
    }
}
