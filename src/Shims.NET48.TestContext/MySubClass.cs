using System;
using System.Collections.Generic;
using System.Text;

namespace Shims.NET48.TestContext
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    namespace Shims.TestContext
    {
        public class MySubClass
        {
            private MyClass myClass = new MyClass();


            public string MyPropertyString
            {
                get { return myClass.MyPropertyString; }
            }

            public int MyPropertyInt
            {
                get { return myClass.MyPropertyInt; }
            }

            public bool MyPropertyBool
            {
                get { return myClass.MyPropertyBool; }
            }

            public double MyPropertyDouble
            {
                get { return myClass.MyPropertyDouble; }
            }

            public float MyPropertyFloat
            {
                get { return myClass.MyPropertyFloat; }
            }

            public decimal MyPropertyDecimal
            {
                get { return myClass.MyPropertyDecimal; }
            }

            public DateTime MyPropertyDateTime
            {
                get { return myClass.MyPropertyDateTime; }
            }

            public Guid MyPropertyGuid
            {
                get { return myClass.MyPropertyGuid; }
            }

            public char MyPropertyChar
            {
                get { return myClass.MyPropertyChar; }
            }

            public byte MyPropertyByte
            {
                get { return myClass.MyPropertyByte; }
            }

            public long MyPropertyLong
            {
                get { return myClass.MyPropertyLong; }
            }

            public short MyPropertyShort
            {
                get { return myClass.MyPropertyShort; }
            }

            public void MyMethod()
            {
                myClass.MyMethod();
            }

            public string MyMethodWithReturn()
            {
                return myClass.MyMethodWithReturn();
            }

            public void MyMethodWithParameter(string parameter)
            {
                myClass.MyMethodWithParameter(parameter);
            }

            public void MyMethodWithParameters(string parameter1, string parameter2)
            {
                myClass.MyMethodWithParameters(parameter1, parameter2);
            }

            public void MyMethodWithParameters(string parameter1, string parameter2, string parameter3)
            {
                myClass.MyMethodWithParameters(parameter1, parameter2, parameter3);
            }

            public void MyMethodWithParameters(string parameter1, string parameter2, string parameter3, string parameter4)
            {
                myClass.MyMethodWithParameters(parameter1, parameter2, parameter3, parameter4);
            }

            public void MyMethodWithParameters(string parameter1, string parameter2, string parameter3, string parameter4, string parameter5)
            {
                myClass.MyMethodWithParameters(parameter1, parameter2, parameter3, parameter4, parameter5);
            }

            public void MyMethodWithParameters(string parameter1, string parameter2, string parameter3, string parameter4, string parameter5, string parameter6)
            {
                myClass.MyMethodWithParameters(parameter1, parameter2, parameter3, parameter4, parameter5, parameter6);
            }

            public string MyMethodWithReturnAndParameter(string parameter)
            {
                return myClass.MyMethodWithReturnAndParameter(parameter);
            }

            public string MyMethodWithReturnAndParameters(string parameter1, string parameter2)
            {
                return myClass.MyMethodWithReturnAndParameters(parameter1, parameter2);
            }

            public string MyMethodWithReturnAndParameters(string parameter1, string parameter2, string parameter3)
            {
                return myClass.MyMethodWithReturnAndParameters(parameter1, parameter2, parameter3);
            }

            public string MyMethodWithReturnAndParameters(string parameter1, string parameter2, string parameter3, string parameter4)
            {
                return myClass.MyMethodWithReturnAndParameters(parameter1, parameter2, parameter3, parameter4);
            }

            public string MyMethodWithReturnAndParameters(string parameter1, string parameter2, string parameter3, string parameter4, string parameter5)
            {
                return myClass.MyMethodWithReturnAndParameters(parameter1, parameter2, parameter3, parameter4, parameter5);
            }

            public string MyMethodWithReturnAndParameters(string parameter1, string parameter2, string parameter3, string parameter4, string parameter5, string parameter6)
            {
                return myClass.MyMethodWithReturnAndParameters(parameter1, parameter2, parameter3, parameter4, parameter5, parameter6);
            }
        }
    }
}
