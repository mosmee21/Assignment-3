using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.Utility
{
    [Serializable, KnownType(typeof(Node))]
    public class Node
    {
        public User value {  get; set; }
        public Node Next { get; set; }
    }
}
