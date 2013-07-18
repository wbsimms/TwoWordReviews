using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TWRDataAccess;
using TWRDataAccess.Entities;
using TWRDataAccess.Types;

namespace TWRDataAccess.Tests
{
    [TestClass]
    public class ModelTest
    {
        [TestMethod]
        public void Test01()
        {
            using (var container = new TWRDataAccess.TWRContext())
            {
                Subject subject = new Subject() {Name = "poo2",SubjectType = SubjectType.Park};
                container.Subjects.Add(subject);
                container.SaveChanges();
            }
        }
    }
}
