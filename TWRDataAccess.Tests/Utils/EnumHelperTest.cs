﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TWRDataAccess.Types;
using TWRDataAccess.Utils;

namespace TWRDataAccess.Tests.Utils
{
    [TestClass]
    public class EnumHelperTest
    {
        [TestMethod]
        public void Test01()
        {
            IList<string> list = EnumHelper<SubjectType>.EnumToList();
            Assert.IsTrue(list.Count > 0);
            Assert.IsTrue(list.Contains("Movie"));
        }
    }
}
