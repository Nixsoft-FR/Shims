using System;

namespace Shims.TestContext
{
    public class MyClass
    {
        public string MyPropertyString { get; set; }

        public int MyPropertyInt { get; set; }

        public bool MyPropertyBool { get; set; }

        public double MyPropertyDouble { get; set; }

        public float MyPropertyFloat { get; set; }

        public decimal MyPropertyDecimal { get; set; }

        public long MyPropertyLong { get; set; }

        public short MyPropertyShort { get; set; }

        public byte MyPropertyByte { get; set; }

        public char MyPropertyChar { get; set; }

        public Guid MyPropertyGuid { get; set; }

        public DateTime MyPropertyDateTime { get; set; }

        public string MySpecialPropertyString
        {
            get { return ((IMyClass)this).MySpecialPropertyString; }
            set { ((IMyClass)this).MySpecialPropertyString = value; }
        }

        public void MyMethod()
        {
            Console.WriteLine("Hello World!");
        }

        public string MyMethodWithReturn()
        {
            return "Hello World!";
        }

        public void MyMethodWithParameter(string parameter)
        {
            Console.WriteLine(parameter);
        }

        public void MyMethodWithParameters(string parameter1, string parameter2)
        {
            Console.WriteLine($"{parameter1} {parameter2}");
        }

        public void MyMethodWithParameters(string parameter1, string parameter2, string parameter3)
        {
            Console.WriteLine($"{parameter1} {parameter2} {parameter3}");
        }

        public void MyMethodWithParameters(string parameter1, string parameter2, string parameter3, string parameter4)
        {
            Console.WriteLine($"{parameter1} {parameter2} {parameter3} {parameter4}");
        }

        public void MyMethodWithParameters(string parameter1, string parameter2, string parameter3, string parameter4, string parameter5)
        {
            Console.WriteLine($"{parameter1} {parameter2} {parameter3} {parameter4} {parameter5}");
        }

        public void MyMethodWithParameters(string parameter1, string parameter2, string parameter3, string parameter4, string parameter5, string parameter6)
        {
            Console.WriteLine($"{parameter1} {parameter2} {parameter3} {parameter4} {parameter5} {parameter6}");
        }

        public string MyMethodWithReturnAndParameter(string parameter)
        {
            return parameter;
        }

        public string MyMethodWithReturnAndParameters(string parameter1, string parameter2)
        {
            return $"{parameter1} {parameter2}";
        }

        public string MyMethodWithReturnAndParameters(string parameter1, string parameter2, string parameter3)
        {
            return $"{parameter1} {parameter2} {parameter3}";
        }

        public string MyMethodWithReturnAndParameters(string parameter1, string parameter2, string parameter3, string parameter4)
        {
            return $"{parameter1} {parameter2} {parameter3} {parameter4}";
        }

        public string MyMethodWithReturnAndParameters(string parameter1, string parameter2, string parameter3, string parameter4, string parameter5)
        {
            return $"{parameter1} {parameter2} {parameter3} {parameter4} {parameter5}";
        }

        public string MyMethodWithReturnAndParameters(string parameter1, string parameter2, string parameter3, string parameter4, string parameter5, string parameter6)
        {
            return $"{parameter1} {parameter2} {parameter3} {parameter4} {parameter5} {parameter6}";
        }
    }
}
