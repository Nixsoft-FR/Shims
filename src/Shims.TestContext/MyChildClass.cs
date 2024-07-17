using System;
using System.Collections.Generic;
using System.Text;

namespace Shims.TestContext
{
    public class MyChildClass : MyClass
    {
        public new string MyPropertyString
        {
            get { return base.MyPropertyString; }
            set { base.MyPropertyString = value; }
        }

        public new int MyPropertyInt
        {
            get { return base.MyPropertyInt; }
            set { base.MyPropertyInt = value; }
        }

        public new bool MyPropertyBool
        {
            get { return base.MyPropertyBool; }
            set { base.MyPropertyBool = value; }
        }

        public new double MyPropertyDouble
        {
            get { return base.MyPropertyDouble; }
            set { base.MyPropertyDouble = value; }
        }

        public new float MyPropertyFloat
        {
            get { return base.MyPropertyFloat; }
            set { base.MyPropertyFloat = value; }
        }

        public new decimal MyPropertyDecimal
        {
            get { return base.MyPropertyDecimal; }
            set { base.MyPropertyDecimal = value; }
        }

        public new DateTime MyPropertyDateTime
        {
            get { return base.MyPropertyDateTime; }
            set { base.MyPropertyDateTime = value; }
        }

        public new Guid MyPropertyGuid
        {
            get { return base.MyPropertyGuid; }
            set { base.MyPropertyGuid = value; }
        }

        public new char MyPropertyChar
        {
            get { return base.MyPropertyChar; }
            set { base.MyPropertyChar = value; }
        }

        public new byte MyPropertyByte
        {
            get { return base.MyPropertyByte; }
            set { base.MyPropertyByte = value; }
        }

        public new long MyPropertyLong
        {
            get { return base.MyPropertyLong; }
            set { base.MyPropertyLong = value; }
        }

        public new short MyPropertyShort
        {
            get { return base.MyPropertyShort; }
            set { base.MyPropertyShort = value; }
        }
        public void MyChildMethod()
        {
           MyMethod();
        }

        public string MyChildMethodWithReturn()
        {
            return MyMethodWithReturn();
        }

        public void MyChildMethodWithParameter(string parameter)
        {
            MyMethodWithParameter(parameter);
        }

        public void MyChildMethodWithParameters(string parameter1, string parameter2)
        {
            MyMethodWithParameters(parameter1, parameter2);
        }

        public void MyChildMethodWithParameters(string parameter1, string parameter2, string parameter3)
        {
            MyMethodWithParameters(parameter1, parameter2, parameter3);
        }

        public void MyChildMethodWithParameters(string parameter1, string parameter2, string parameter3, string parameter4)
        {
            MyMethodWithParameters(parameter1, parameter2, parameter3, parameter4);
        }

        public void MyChildMethodWithParameters(string parameter1, string parameter2, string parameter3, string parameter4, string parameter5)
        {
            MyMethodWithParameters(parameter1, parameter2, parameter3, parameter4, parameter5);
        }

        public void MyChildMethodWithParameters(string parameter1, string parameter2, string parameter3, string parameter4, string parameter5, string parameter6)
        {
            MyMethodWithParameters(parameter1, parameter2, parameter3, parameter4, parameter5, parameter6);
        }

        public string MyChildMethodWithReturnAndParameter(string parameter)
        {
            return MyMethodWithReturnAndParameter(parameter);
        }

        public string MyChildMethodWithReturnAndParameters(string parameter1, string parameter2)
        {
            return MyMethodWithReturnAndParameters(parameter1, parameter2);
        }

        public string MyChildMethodWithReturnAndParameters(string parameter1, string parameter2, string parameter3)
        {
            return MyMethodWithReturnAndParameters(parameter1, parameter2, parameter3);
        }

        public string MyChildMethodWithReturnAndParameters(string parameter1, string parameter2, string parameter3, string parameter4)
        {
            return MyMethodWithReturnAndParameters(parameter1, parameter2, parameter3, parameter4);
        }

        public string MyChildMethodWithReturnAndParameters(string parameter1, string parameter2, string parameter3, string parameter4, string parameter5)
        {
            return MyMethodWithReturnAndParameters(parameter1, parameter2, parameter3, parameter4, parameter5);
        }

        public string MyChildMethodWithReturnAndParameters(string parameter1, string parameter2, string parameter3, string parameter4, string parameter5, string parameter6)
        {
            return MyMethodWithReturnAndParameters(parameter1, parameter2, parameter3, parameter4, parameter5, parameter6);
        }


    }
}
