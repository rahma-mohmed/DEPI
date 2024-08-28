using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    internal class TestGrade
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestInvalidSubject()
        {
            Grade grade = new Grade { Subject = "", Score = 85 };
            grade.Validate();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestInvalidScore()
        {
            Grade grade = new Grade { Subject = "Math", Score = 105 };
            grade.Validate();
        }
    }
}
