using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutoArray
{
    [TestClass()]
    public class AutoArrayTestSuite
    {
        private AutoArray array;

        [TestInitialize()]
        public void init()
        {
            array = new AutoArray();
        }
    }
}
