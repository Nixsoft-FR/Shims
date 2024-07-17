using System;
using System.Collections.Generic;
using System.Text;

namespace Shims.TestContext
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
                set { myClass.MyPropertyString = value; }
            }

            public int MyPropertyInt
            {
                get { return myClass.MyPropertyInt; }
                set { myClass.MyPropertyInt = value; }
            }

            public bool MyPropertyBool
            {
                get { return myClass.MyPropertyBool; }
                set { myClass.MyPropertyBool = value; }
            }

            public double MyPropertyDouble
            {
                get { return myClass.MyPropertyDouble; }
                set { myClass.MyPropertyDouble = value; }
            }

            public float MyPropertyFloat
            {
                get { return myClass.MyPropertyFloat; }
                set { myClass.MyPropertyFloat = value; }
            }

            public decimal MyPropertyDecimal
            {
                get { return myClass.MyPropertyDecimal; }
                set { myClass.MyPropertyDecimal = value; }
            }

            public DateTime MyPropertyDateTime
            {
                get { return myClass.MyPropertyDateTime; }
                set { myClass.MyPropertyDateTime = value; }
            }

            public Guid MyPropertyGuid
            {
                get { return myClass.MyPropertyGuid; }
                set { myClass.MyPropertyGuid = value; }
            }

            public char MyPropertyChar
            {
                get { return myClass.MyPropertyChar; }
                set { myClass.MyPropertyChar = value; }
            }

            public byte MyPropertyByte
            {
                get { return myClass.MyPropertyByte; }
                set { myClass.MyPropertyByte = value; }
            }

            public long MyPropertyLong
            {
                get { return myClass.MyPropertyLong; }
                set { myClass.MyPropertyLong = value; }
            }

            public short MyPropertyShort
            {
                get { return myClass.MyPropertyShort; }
                set { myClass.MyPropertyShort = value; }
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
