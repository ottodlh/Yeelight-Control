using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YControl.classes
{
    internal class ScreenProperties
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public ScreenProperties(int _id, string _name)
        {
            Id = _name + "_" + _id;
            Name = _name;
        }
    }
}
