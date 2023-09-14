using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamzaRizwanWebAutomationFrameWork.HelperFuntions
{
    public class Asserter
    {
        public void AssertAreEqual(string expected, string actual)
        {
            try
            {
                Assert.AreEqual(expected, actual);
            }
            catch (AssertionException AssertionException)
            {
                Helper helper = new Helper();
                helper.TakeBrowserScreenShot();
            }

        }
    }
}