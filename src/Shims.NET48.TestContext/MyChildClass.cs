using System;

namespace Shims.NET48.TestContext
{
    public class MyChildClass : MyClass
    {
        public new string MyPropertyString
        {
            get { return base.MyPropertyString; }
        }

        public new int MyPropertyInt
        {
            get { return base.MyPropertyInt; }
        }

        public new bool MyPropertyBool
        {
            get { return base.MyPropertyBool; }
        }

        public new double MyPropertyDouble
        {
            get { return base.MyPropertyDouble; }
        }

        public new float MyPropertyFloat
        {
            get { return base.MyPropertyFloat; }
        }

        public new decimal MyPropertyDecimal
        {
            get { return base.MyPropertyDecimal; }
        }

        public new DateTime MyPropertyDateTime
        {
            get { return base.MyPropertyDateTime; }
        }

        public new Guid MyPropertyGuid
        {
            get { return base.MyPropertyGuid; }
        }

        public new char MyPropertyChar
        {
            get { return base.MyPropertyChar; }
        }

        public new byte MyPropertyByte
        {
            get { return base.MyPropertyByte; }
        }

        public new long MyPropertyLong
        {
            get { return base.MyPropertyLong; }
        }

        public new short MyPropertyShort
        {
            get { return base.MyPropertyShort; }
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

        public MyOtherClass MyChildMethodWithReturnMyOtherClassFromParent()
        {
            return MyMethodReturninMyOtherClass();
        }

        public MyOtherClass MyChildMethodWithReturnMyOtherClassFromGeneric()
        {
            return MyMethodWithParametersAndGenericReturn<MyOtherClass>("test", false);
        }

    }
}
