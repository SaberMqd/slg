using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace map
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlParaser pra = new XmlParaser("C:/Users/Shmily/Desktop/test3.xml");
            CrustalBlockCollection testCollection = pra.GetAllCrustalBlock();
        }
    }
}
