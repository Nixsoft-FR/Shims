using Shims.TestContext;
using Shims.TestContext.Shims.TestContext;
using System.Runtime.CompilerServices;

namespace Shims.NET8.Tests;

[TestClass]
public class MySubClass_Test : UnitTestBase
{
    #region MyMethodWithReturn

    [TestMethod]
    public void MySubClass_MyMethodWithReturn_OK_WithCallback()
    {
        bool callbackCalled = false;

        Shim<MyClass> myClass = new Shim<MyClass>();
        myClass.Setup(x => x.MyMethodWithReturn())
               .Returns("Hello Mock!")
               .Callback(() =>
               {
                   callbackCalled = true;
               });

        MySubClass instance = new MySubClass();
        string result = instance.MyMethodWithReturn();
        Assert.AreEqual("Hello Mock!", result);
        Assert.IsTrue(callbackCalled);
    }

    [TestMethod]
    public void MySubClass_MyMethodWithReturn_OK_WithoutCallback()
    {
        Shim<MyClass> myClass = new Shim<MyClass>();
        myClass.Setup(x => x.MyMethodWithReturn())
               .Returns("Hello Mock!");

        MySubClass instance = new MySubClass();
        string result = instance.MyMethodWithReturn();

        Assert.AreEqual("Hello Mock!", result);
    }

    [TestMethod]
    public void MySubClass_MyMethodWithReturn_KO_Throws_WithCallback()
    {
        bool callbackCalled = false;

        Shim<MyClass> myClass = new Shim<MyClass>();
        myClass.Setup(x => x.MyMethodWithReturn())
               .Throws<ArgumentException>()
               .Callback(() =>
               {
                   callbackCalled = true;
               });

        MySubClass instance = new MySubClass();
        Assert.ThrowsException<ArgumentException>(() => instance.MyMethodWithReturn());
        Assert.IsTrue(callbackCalled);
    }

    [TestMethod]
    public void MySubClass_MyMethodWithReturn_KO_Throws_WithoutCallback()
    {
        Shim<MyClass> myClass = new Shim<MyClass>();
        myClass.Setup(x => x.MyMethodWithReturn())
               .Throws<ArgumentException>();

        MySubClass instance = new MySubClass();
        Assert.ThrowsException<ArgumentException>(() => instance.MyMethodWithReturn());
    }

    [TestMethod]
    public void MySubClass_MyMethodWithReturn_KO_ThrowsWithException_WithCallback()
    {
        bool callbackCalled = false;

        Shim<MyClass> myClass = new Shim<MyClass>();
        myClass.Setup(x => x.MyMethodWithReturn())
               .Throws(new ArgumentException("Test"))
               .Callback(() =>
               {
                   callbackCalled = true;
               });

        MySubClass instance = new MySubClass();
        try
        {
            instance.MyMethodWithReturn();
            Assert.Fail("Exception not thrown");

        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Test", ex.Message);
        }
        Assert.IsTrue(callbackCalled);
    }

    [TestMethod]
    public void MySubClass_MyMethodWithReturn_KO_ThrowsWithException_WithoutCallback()
    {
        Shim<MyClass> myClass = new Shim<MyClass>();
        myClass.Setup(x => x.MyMethodWithReturn())
               .Throws(new ArgumentException("Test"));

        MySubClass instance = new MySubClass();
        try
        {
            instance.MyMethodWithReturn();
            Assert.Fail("Exception not thrown");
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Test", ex.Message);
        }
    }

    [TestMethod]
    public void MySubClass_MyMethodWithReturn_KO_ThowsWithDelegate_WithCallback()
    {
        bool callbackCalled = false;

        Shim<MyClass> myClass = new Shim<MyClass>();
        Delegate exceptionFunction = () => new ArgumentException("Test");
        myClass.Setup(x => x.MyMethodWithReturn())
               .Throws(exceptionFunction)
               .Callback(() =>
               {
                   callbackCalled = true;
               });

        MySubClass instance = new MySubClass();
        try
        {
            instance.MyMethodWithReturn();
            Assert.Fail("Exception not thrown");
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Test", ex.Message);
        }
        Assert.IsTrue(callbackCalled);
    }

    [TestMethod]
    public void MySubClass_MyMethodWithReturn_KO_ThowsWithDelegate_WithoutCallback()
    {
        Shim<MyClass> myClass = new Shim<MyClass>();
        Delegate exceptionFunction = () => new ArgumentException("Test");
        myClass.Setup(x => x.MyMethodWithReturn())
               .Throws(exceptionFunction);

        MySubClass instance = new MySubClass();
        try
        {
            instance.MyMethodWithReturn();
            Assert.Fail("Exception not thrown");
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Test", ex.Message);
        }
    }

    [TestMethod]
    public void MySubClass_MyMethodWithReturn_KO_ThowsWithAction_WithCallback()
    {
        bool callbackCalled = false;

        Shim<MyClass> myClass = new Shim<MyClass>();
        myClass.Setup(x => x.MyMethodWithReturn())
               .Throws(() => new ArgumentException("Test"))
               .Callback(() =>
               {
                   callbackCalled = true;
               });

        MySubClass instance = new MySubClass();
        try
        {
            instance.MyMethodWithReturn();
            Assert.Fail("Exception not thrown");
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Test", ex.Message);
        }

        Assert.IsTrue(callbackCalled);
    }

    [TestMethod]
    public void MySubClass_MyMethodWithReturn_KO_ThowsWithAction_WithoutCallback()
    {
        Shim<MyClass> myClass = new Shim<MyClass>();
        myClass.Setup(x => x.MyMethodWithReturn())
               .Throws(() => new ArgumentException("Test"));

        MySubClass instance = new MySubClass();
        try
        {
            instance.MyMethodWithReturn();
            Assert.Fail("Exception not thrown");
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Test", ex.Message);
        }
    }

    #endregion

    #region MyMethod

    [TestMethod]
    public void MySubClass_MyMethod_OK_WithCallback()
    {
        bool callbackCalled = false;

        Shim<MyClass> myClass = new Shim<MyClass>();
        myClass.Setup(mock => mock.MyMethod())
               .Callback(() =>
               {
                   callbackCalled = true;
               });

        MySubClass instance = new MySubClass();
        instance.MyMethod();
        Assert.IsTrue(callbackCalled);
    }

    [TestMethod]
    public void MySubClass_MyMethod_KO_Throws_WithoutCallback()
    {
        Shim<MyClass> myClass = new Shim<MyClass>();
        myClass.Setup(mock => mock.MyMethod())
               .Throws<ArgumentException>();

        MySubClass instance = new MySubClass();
        Assert.ThrowsException<ArgumentException>(() => instance.MyMethod());
    }

    [TestMethod]
    public void MySubClass_MyMethod_KO_Throws_WithCallback()
    {
        bool callbackCalled = false;

        Shim<MyClass> myClass = new Shim<MyClass>();
        myClass.Setup(mock => mock.MyMethod())
               .Throws<ArgumentException>()
               .Callback(() =>
               {
                   callbackCalled = true;
               });

        MySubClass instance = new MySubClass();
        Assert.ThrowsException<ArgumentException>(() => instance.MyMethod());
        Assert.IsTrue(callbackCalled);
    }

    [TestMethod]
    public void MySubClass_MyMethod_KO_ThrowsWithException_WithoutCallback()
    {
        Shim<MyClass> myClass = new Shim<MyClass>();
        myClass.Setup(mock => mock.MyMethod())
               .Throws(new ArgumentException("Test"));

        MySubClass instance = new MySubClass();
        try
        {
            instance.MyMethod();
            Assert.Fail("Exception not thrown");
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Test", ex.Message);
        }
    }

    [TestMethod]
    public void MySubClass_MyMethod_KO_ThrowsWithException_WithCallback()
    {
        bool callbackCalled = false;

        Shim<MyClass> myClass = new Shim<MyClass>();
        myClass.Setup(mock => mock.MyMethod())
               .Throws(new ArgumentException("Test"))
               .Callback(() =>
               {
                   callbackCalled = true;
               });

        MySubClass instance = new MySubClass();
        try
        {
            instance.MyMethod();
            Assert.Fail("Exception not thrown");
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Test", ex.Message);
        }
        Assert.IsTrue(callbackCalled);
    }

    [TestMethod]
    public void MySubClass_MyMethod_KO_ThowsWithDelegate_WithoutCallback()
    {
        Shim<MyClass> myClass = new Shim<MyClass>();
        Delegate exceptionFunction = () => new ArgumentException("Test");
        myClass.Setup(mock => mock.MyMethod())
               .Throws(exceptionFunction);

        MySubClass instance = new MySubClass();
        try
        {
            instance.MyMethod();
            Assert.Fail("Exception not thrown");
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Test", ex.Message);
        }
    }

    [TestMethod]
    public void MySubClass_MyMethod_KO_ThowsWithDelegate_WithCallback()
    {
        bool callbackCalled = false;

        Shim<MyClass> myClass = new Shim<MyClass>();
        Delegate exceptionFunction = () => new ArgumentException("Test");
        myClass.Setup(mock => mock.MyMethod())
               .Throws(exceptionFunction)
               .Callback(() =>
               {
                   callbackCalled = true;
               });

        MySubClass instance = new MySubClass();
        try
        {
            instance.MyMethod();
            Assert.Fail("Exception not thrown");
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Test", ex.Message);
        }
        Assert.IsTrue(callbackCalled);
    }

    [TestMethod]
    public void MySubClass_MyMethod_KO_ThowsWithAction_WithoutCallback()
    {
        Shim<MyClass> myClass = new Shim<MyClass>();
        myClass.Setup(mock => mock.MyMethod())
               .Throws(() => new ArgumentException("Test"));

        MySubClass instance = new MySubClass();
        try
        {
            instance.MyMethod();
            Assert.Fail("Exception not thrown");
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Test", ex.Message);
        }
    }

    [TestMethod]
    public void MySubClass_MyMethod_KO_ThowsWithAction_WithCallback()
    {
        bool callbackCalled = false;

        Shim<MyClass> myClass = new Shim<MyClass>();
        myClass.Setup(mock => mock.MyMethod())
               .Throws(() => new ArgumentException("Test"))
               .Callback(() =>
               {
                   callbackCalled = true;
               });

        MySubClass instance = new MySubClass();
        try
        {
            instance.MyMethod();
            Assert.Fail("Exception not thrown");
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Test", ex.Message);
        }
        Assert.IsTrue(callbackCalled);
    }

    #endregion

    #region MyMethodWithParameter

    [TestMethod]
    public void MySubClass_MyMethodWithParameter_OK_WithCallback()
    {
        bool callbackCalled = false;

        Shim<MyClass> myClass = new Shim<MyClass>();
        myClass.Setup(mock => mock.MyMethodWithParameter("Test"))
               .Callback((string s) =>
               {
                   Assert.AreEqual("Test", s);
                   callbackCalled = true;
               });

        MySubClass instance = new MySubClass();
        instance.MyMethodWithParameter("Test");
        Assert.IsTrue(callbackCalled);
    }

    [TestMethod]
    public void MySubClass_MyMethodWithParameter_KO_Throws_WithoutCallback()
    {
        Shim<MyClass> myClass = new Shim<MyClass>();
        myClass.Setup(mock => mock.MyMethodWithParameter("Test"))
               .Throws<ArgumentException>();

        MySubClass instance = new MySubClass();
        Assert.ThrowsException<ArgumentException>(() => instance.MyMethodWithParameter("Test"));
    }

    [TestMethod]
    public void MySubClass_MyMethodWithParameter_KO_Throws_WithCallback()
    {
        bool callbackCalled = false;

        Shim<MyClass> myClass = new Shim<MyClass>();
        myClass.Setup(mock => mock.MyMethodWithParameter("Test"))
               .Throws<ArgumentException>()
               .Callback((string s) =>
               {
                   Assert.AreEqual("Test", s);
                   callbackCalled = true;
               });

        MySubClass instance = new MySubClass();
        Assert.ThrowsException<ArgumentException>(() => instance.MyMethodWithParameter("Test"));
        Assert.IsTrue(callbackCalled);
    }

    [TestMethod]
    public void MySubClass_MyMethodWithParameter_KO_ThrowsWithException_WithoutCallback()
    {
        Shim<MyClass> myClass = new Shim<MyClass>();
        myClass.Setup(mock => mock.MyMethodWithParameter("Test"))
               .Throws(new ArgumentException("Test"));

        MySubClass instance = new MySubClass();
        try
        {
            instance.MyMethodWithParameter("Test");
            Assert.Fail("Exception not thrown");
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Test", ex.Message);
        }
    }

    [TestMethod]
    public void MySubClass_MyMethodWithParameter_KO_ThrowsWithException_WithCallback()
    {
        bool callbackCalled = false;

        Shim<MyClass> myClass = new Shim<MyClass>();
        myClass.Setup(mock => mock.MyMethodWithParameter("Test"))
               .Throws(new ArgumentException("Test"))
               .Callback((string s) =>
               {
                   Assert.AreEqual("Test", s);
                   callbackCalled = true;
               });

        MySubClass instance = new MySubClass();
        try
        {
            instance.MyMethodWithParameter("Test");
            Assert.Fail("Exception not thrown");
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Test", ex.Message);
        }
        Assert.IsTrue(callbackCalled);
    }

    [TestMethod]
    public void MySubClass_MyMethodWithParameter_KO_ThowsWithDelegate_WithoutCallback()
    {
        Shim<MyClass> myClass = new Shim<MyClass>();
        Delegate exceptionFunction = () => new ArgumentException("Test");
        myClass.Setup(mock => mock.MyMethodWithParameter("Test"))
               .Throws(exceptionFunction);

        MySubClass instance = new MySubClass();
        try
        {
            instance.MyMethodWithParameter("Test");
            Assert.Fail("Exception not thrown");
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Test", ex.Message);
        }
    }

    [TestMethod]
    public void MySubClass_MyMethodWithParameter_KO_ThowsWithDelegate_WithCallback()
    {
        bool callbackCalled = false;

        Shim<MyClass> myClass = new Shim<MyClass>();
        Delegate exceptionFunction = () => new ArgumentException("Test");
        myClass.Setup(mock => mock.MyMethodWithParameter("Test"))
               .Throws(exceptionFunction)
               .Callback((string s) =>
               {
                   Assert.AreEqual("Test", s);
                   callbackCalled = true;
               });

        MySubClass instance = new MySubClass();
        try
        {
            instance.MyMethodWithParameter("Test");
            Assert.Fail("Exception not thrown");
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Test", ex.Message);
        }
        Assert.IsTrue(callbackCalled);
    }

    [TestMethod]
    public void MySubClass_MyMethodWithParameter_KO_ThowsWithAction_WithoutCallback()
    {
        Shim<MyClass> myClass = new Shim<MyClass>();
        myClass.Setup(mock => mock.MyMethodWithParameter("Test"))
               .Throws(() => new ArgumentException("Test"));

        MySubClass instance = new MySubClass();
        try
        {
            instance.MyMethodWithParameter("Test");
            Assert.Fail("Exception not thrown");
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Test", ex.Message);
        }
    }

    [TestMethod]
    public void MySubClass_MyMethodWithParameter_KO_ThowsWithAction_WithCallback()
    {
        bool callbackCalled = false;

        Shim<MyClass> myClass = new Shim<MyClass>();
        myClass.Setup(mock => mock.MyMethodWithParameter("Test"))
               .Throws(() => new ArgumentException("Test"))
               .Callback((string s) =>
               {
                   Assert.AreEqual("Test", s);
                   callbackCalled = true;
               });

        MySubClass instance = new MySubClass();
        try
        {
            instance.MyMethodWithParameter("Test");
            Assert.Fail("Exception not thrown");
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Test", ex.Message);
        }
        Assert.IsTrue(callbackCalled);
    }

    #endregion

    #region MyMethodWithParameters

    #region Two parameters

    [TestMethod]
    public void MySubClass_MyMethodWithTwoParameters_OK_WithCallback()
    {
        bool callbackCalled = false;

        Shim<MyClass> myClass = new Shim<MyClass>();
        myClass.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2"))
               .Callback((string s1, string s2) =>
               {
                   Assert.AreEqual("Test1", s1);
                   Assert.AreEqual("Test2", s2);
                   callbackCalled = true;
               });

        MySubClass instance = new MySubClass();
        instance.MyMethodWithParameters("Test1", "Test2");
        Assert.IsTrue(callbackCalled);
    }

    [TestMethod]
    public void MySubClass_MyMethodWithTwoParameters_KO_Throws_WithoutCallback()
    {
        Shim<MyClass> myClass = new Shim<MyClass>();
        myClass.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2"))
               .Throws<ArgumentException>();

        MySubClass instance = new MySubClass();
        Assert.ThrowsException<ArgumentException>(() => instance.MyMethodWithParameters("Test1", "Test2"));
    }

    [TestMethod]
    public void MySubClass_MyMethodWithTwoParameters_KO_Throws_WithCallback()
    {
        bool callbackCalled = false;

        Shim<MyClass> myClass = new Shim<MyClass>();
        myClass.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2"))
               .Throws<ArgumentException>()
               .Callback((string s1, string s2) =>
               {
                   Assert.AreEqual("Test1", s1);
                   Assert.AreEqual("Test2", s2);
                   callbackCalled = true;
               });

        MySubClass instance = new MySubClass();
        Assert.ThrowsException<ArgumentException>(() => instance.MyMethodWithParameters("Test1", "Test2"));
        Assert.IsTrue(callbackCalled);
    }

    [TestMethod]
    public void MySubClass_MyMethodWithTwoParameters_KO_ThrowsWithException_WithoutCallback()
    {
        Shim<MyClass> myClass = new Shim<MyClass>();
        myClass.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2"))
               .Throws(new ArgumentException("Test"));

        MySubClass instance = new MySubClass();
        try
        {
            instance.MyMethodWithParameters("Test1", "Test2");
            Assert.Fail("Exception not thrown");
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Test", ex.Message);
        }
    }

    [TestMethod]
    public void MySubClass_MyMethodWithTwoParameters_KO_ThrowsWithException_WithCallback()
    {
        bool callbackCalled = false;

        Shim<MyClass> myClass = new Shim<MyClass>();
        myClass.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2"))
               .Throws(new ArgumentException("Test"))
               .Callback((string s1, string s2) =>
               {
                   Assert.AreEqual("Test1", s1);
                   Assert.AreEqual("Test2", s2);
                   callbackCalled = true;
               });

        MySubClass instance = new MySubClass();
        try
        {
            instance.MyMethodWithParameters("Test1", "Test2");
            Assert.Fail("Exception not thrown");
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Test", ex.Message);
        }
        Assert.IsTrue(callbackCalled);
    }

    [TestMethod]
    public void MySubClass_MyMethodWithTwoParameters_KO_ThowsWithDelegate_WithoutCallback()
    {
        Shim<MyClass> myClass = new Shim<MyClass>();
        Delegate exceptionFunction = () => new ArgumentException("Test");
        myClass.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2"))
               .Throws(exceptionFunction);

        MySubClass instance = new MySubClass();
        try
        {
            instance.MyMethodWithParameters("Test1", "Test2");
            Assert.Fail("Exception not thrown");
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Test", ex.Message);
        }
    }

    [TestMethod]
    public void MySubClass_MyMethodWithTwoParameters_KO_ThowsWithDelegate_WithCallback()
    {
        bool callbackCalled = false;

        Shim<MyClass> myClass = new Shim<MyClass>();
        Delegate exceptionFunction = () => new ArgumentException("Test");
        myClass.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2"))
               .Throws(exceptionFunction)
               .Callback((string s1, string s2) =>
               {
                   Assert.AreEqual("Test1", s1);
                   Assert.AreEqual("Test2", s2);
                   callbackCalled = true;
               });

        MySubClass instance = new MySubClass();
        try
        {
            instance.MyMethodWithParameters("Test1", "Test2");
            Assert.Fail("Exception not thrown");
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Test", ex.Message);
        }
        Assert.IsTrue(callbackCalled);
    }

    [TestMethod]
    public void MySubClass_MyMethodWithTwoParameters_KO_ThowsWithAction_WithoutCallback()
    {
        Shim<MyClass> myClass = new Shim<MyClass>();
        myClass.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2"))
               .Throws(() => new ArgumentException("Test"));

        MySubClass instance = new MySubClass();
        try
        {
            instance.MyMethodWithParameters("Test1", "Test2");
            Assert.Fail("Exception not thrown");
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Test", ex.Message);
        }
    }

    [TestMethod]
    public void MySubClass_MyMethodWithTwoParameters_KO_ThowsWithAction_WithCallback()
    {
        bool callbackCalled = false;

        Shim<MyClass> myClass = new Shim<MyClass>();
        myClass.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2"))
               .Throws(() => new ArgumentException("Test"))
               .Callback((string s1, string s2) =>
               {
                   Assert.AreEqual("Test1", s1);
                   Assert.AreEqual("Test2", s2);
                   callbackCalled = true;
               });

        MySubClass instance = new MySubClass();
        try
        {
            instance.MyMethodWithParameters("Test1", "Test2");
            Assert.Fail("Exception not thrown");
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Test", ex.Message);
        }
        Assert.IsTrue(callbackCalled);
    }

    #endregion

    #region Three parameters

    [TestMethod]
    public void MySubClass_MyMethodWithThreeParameters_OK_WithCallback()
    {
        bool callbackCalled = false;

        Shim<MyClass> myClass = new Shim<MyClass>();
        myClass.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2", "Test3"))
               .Callback((string s1, string s2, string s3) =>
               {
                   Assert.AreEqual("Test1", s1);
                   Assert.AreEqual("Test2", s2);
                   Assert.AreEqual("Test3", s3);
                   callbackCalled = true;
               });

        MySubClass instance = new MySubClass();
        instance.MyMethodWithParameters("Test1", "Test2", "Test3");
        Assert.IsTrue(callbackCalled);
    }

    [TestMethod]
    public void MySubClass_MyMethodWithThreeParameters_KO_Throws_WithoutCallback()
    {
        Shim<MyClass> myClass = new Shim<MyClass>();
        myClass.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2", "Test3"))
               .Throws<ArgumentException>();

        MySubClass instance = new MySubClass();
        Assert.ThrowsException<ArgumentException>(() => instance.MyMethodWithParameters("Test1", "Test2", "Test3"));
    }

    [TestMethod]
    public void MySubClass_MyMethodWithThreeParameters_KO_Throws_WithCallback()
    {
        bool callbackCalled = false;

        Shim<MyClass> myClass = new Shim<MyClass>();
        myClass.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2", "Test3"))
               .Throws<ArgumentException>()
               .Callback((string s1, string s2, string s3) =>
               {
                   Assert.AreEqual("Test1", s1);
                   Assert.AreEqual("Test2", s2);
                   Assert.AreEqual("Test3", s3);
                   callbackCalled = true;
               });

        MySubClass instance = new MySubClass();
        Assert.ThrowsException<ArgumentException>(() => instance.MyMethodWithParameters("Test1", "Test2", "Test3"));
        Assert.IsTrue(callbackCalled);
    }

    [TestMethod]
    public void MySubClass_MyMethodWithThreeParameters_KO_ThrowsWithException_WithoutCallback()
    {
        Shim<MyClass> myClass = new Shim<MyClass>();
        myClass.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2", "Test3"))
               .Throws(new ArgumentException("Test"));

        MySubClass instance = new MySubClass();
        try
        {
            instance.MyMethodWithParameters("Test1", "Test2", "Test3");
            Assert.Fail("Exception not thrown");
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Test", ex.Message);
        }
    }

    [TestMethod]
    public void MySubClass_MyMethodWithThreeParameters_KO_ThrowsWithException_WithCallback()
    {
        bool callbackCalled = false;

        Shim<MyClass> myClass = new Shim<MyClass>();
        myClass.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2", "Test3"))
               .Throws(new ArgumentException("Test"))
               .Callback((string s1, string s2, string s3) =>
               {
                   Assert.AreEqual("Test1", s1);
                   Assert.AreEqual("Test2", s2);
                   Assert.AreEqual("Test3", s3);
                   callbackCalled = true;
               });

        MySubClass instance = new MySubClass();
        try
        {
            instance.MyMethodWithParameters("Test1", "Test2", "Test3");
            Assert.Fail("Exception not thrown");
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Test", ex.Message);
        }
        Assert.IsTrue(callbackCalled);
    }

    [TestMethod]
    public void MySubClass_MyMethodWithThreeParameters_KO_ThowsWithDelegate_WithoutCallback()
    {
        Shim<MyClass> myClass = new Shim<MyClass>();
        Delegate exceptionFunction = () => new ArgumentException("Test");
        myClass.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2", "Test3"))
               .Throws(exceptionFunction);

        MySubClass instance = new MySubClass();
        try
        {
            instance.MyMethodWithParameters("Test1", "Test2", "Test3");
            Assert.Fail("Exception not thrown");
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Test", ex.Message);
        }
    }

    [TestMethod]
    public void MySubClass_MyMethodWithThreeParameters_KO_ThowsWithDelegate_WithCallback()
    {
        bool callbackCalled = false;

        Shim<MyClass> myClass = new Shim<MyClass>();
        Delegate exceptionFunction = () => new ArgumentException("Test");
        myClass.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2", "Test3"))
               .Throws(exceptionFunction)
               .Callback((string s1, string s2, string s3) =>
               {
                   Assert.AreEqual("Test1", s1);
                   Assert.AreEqual("Test2", s2);
                   Assert.AreEqual("Test3", s3);
                   callbackCalled = true;
               });

        MySubClass instance = new MySubClass();
        try
        {
            instance.MyMethodWithParameters("Test1", "Test2", "Test3");
            Assert.Fail("Exception not thrown");
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Test", ex.Message);
        }
        Assert.IsTrue(callbackCalled);
    }

    [TestMethod]
    public void MySubClass_MyMethodWithThreeParameters_KO_ThowsWithAction_WithoutCallback()
    {
        Shim<MyClass> myClass = new Shim<MyClass>();
        myClass.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2", "Test3"))
               .Throws(() => new ArgumentException("Test"));

        MySubClass instance = new MySubClass();
        try
        {
            instance.MyMethodWithParameters("Test1", "Test2", "Test3");
            Assert.Fail("Exception not thrown");
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Test", ex.Message);
        }
    }

    [TestMethod]
    public void MySubClass_MyMethodWithThreeParameters_KO_ThowsWithAction_WithCallback()
    {
        bool callbackCalled = false;

        Shim<MyClass> myClass = new Shim<MyClass>();
        myClass.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2", "Test3"))
               .Throws(() => new ArgumentException("Test"))
               .Callback((string s1, string s2, string s3) =>
               {
                   Assert.AreEqual("Test1", s1);
                   Assert.AreEqual("Test2", s2);
                   Assert.AreEqual("Test3", s3);
                   callbackCalled = true;
               });

        MySubClass instance = new MySubClass();
        try
        {
            instance.MyMethodWithParameters("Test1", "Test2", "Test3");
            Assert.Fail("Exception not thrown");
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Test", ex.Message);
        }
        Assert.IsTrue(callbackCalled);
    }

    #endregion

    #region Four parameters

    [TestMethod]
    public void MySubClass_MyMethodWithFourParameters_OK_WithCallback()
    {
        bool callbackCalled = false;

        Shim<MyClass> myClass = new Shim<MyClass>();
        myClass.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4"))
               .Callback((string s1, string s2, string s3, string s4) =>
               {
                   Assert.AreEqual("Test1", s1);
                   Assert.AreEqual("Test2", s2);
                   Assert.AreEqual("Test3", s3);
                   Assert.AreEqual("Test4", s4);
                   callbackCalled = true;
               });

        MySubClass instance = new MySubClass();
        instance.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4");
        Assert.IsTrue(callbackCalled);
    }

    [TestMethod]
    public void MySubClass_MyMethodWithFourParameters_KO_Throws_WithoutCallback()
    {
        Shim<MyClass> myClass = new Shim<MyClass>();
        myClass.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4"))
               .Throws<ArgumentException>();

        MySubClass instance = new MySubClass();
        Assert.ThrowsException<ArgumentException>(() => instance.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4"));
    }

    [TestMethod]
    public void MySubClass_MyMethodWithFourParameters_KO_Throws_WithCallback()
    {
        bool callbackCalled = false;

        Shim<MyClass> myClass = new Shim<MyClass>();
        myClass.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4"))
               .Throws<ArgumentException>()
               .Callback((string s1, string s2, string s3, string s4) =>
               {
                   Assert.AreEqual("Test1", s1);
                   Assert.AreEqual("Test2", s2);
                   Assert.AreEqual("Test3", s3);
                   Assert.AreEqual("Test4", s4);
                   callbackCalled = true;
               });

        MySubClass instance = new MySubClass();
        Assert.ThrowsException<ArgumentException>(() => instance.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4"));
        Assert.IsTrue(callbackCalled);
    }

    [TestMethod]
    public void MySubClass_MyMethodWithFourParameters_KO_ThrowsWithException_WithoutCallback()
    {
        Shim<MyClass> myClass = new Shim<MyClass>();
        myClass.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4"))
               .Throws(new ArgumentException("Test"));

        MySubClass instance = new MySubClass();
        try
        {
            instance.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4");
            Assert.Fail("Exception not thrown");
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Test", ex.Message);
        }
    }

    [TestMethod]
    public void MySubClass_MyMethodWithFourParameters_KO_ThrowsWithException_WithCallback()
    {
        bool callbackCalled = false;

        Shim<MyClass> myClass = new Shim<MyClass>();
        myClass.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4"))
               .Throws(new ArgumentException("Test"))
               .Callback((string s1, string s2, string s3, string s4) =>
               {
                   Assert.AreEqual("Test1", s1);
                   Assert.AreEqual("Test2", s2);
                   Assert.AreEqual("Test3", s3);
                   Assert.AreEqual("Test4", s4);
                   callbackCalled = true;
               });

        MySubClass instance = new MySubClass();
        try
        {
            instance.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4");
            Assert.Fail("Exception not thrown");
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Test", ex.Message);
        }
        Assert.IsTrue(callbackCalled);
    }

    [TestMethod]
    public void MySubClass_MyMethodWithFourParameters_KO_ThowsWithDelegate_WithoutCallback()
    {
        Shim<MyClass> myClass = new Shim<MyClass>();
        Delegate exceptionFunction = () => new ArgumentException("Test");
        myClass.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4"))
               .Throws(exceptionFunction);

        MySubClass instance = new MySubClass();
        try
        {
            instance.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4");
            Assert.Fail("Exception not thrown");
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Test", ex.Message);
        }
    }

    [TestMethod]
    public void MySubClass_MyMethodWithFourParameters_KO_ThowsWithDelegate_WithCallback()
    {
        bool callbackCalled = false;

        Shim<MyClass> myClass = new Shim<MyClass>();
        Delegate exceptionFunction = () => new ArgumentException("Test");
        myClass.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4"))
               .Throws(exceptionFunction)
               .Callback((string s1, string s2, string s3, string s4) =>
               {
                   Assert.AreEqual("Test1", s1);
                   Assert.AreEqual("Test2", s2);
                   Assert.AreEqual("Test3", s3);
                   Assert.AreEqual("Test4", s4);
                   callbackCalled = true;
               });

        MySubClass instance = new MySubClass();
        try
        {
            instance.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4");
            Assert.Fail("Exception not thrown");
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Test", ex.Message);
        }
        Assert.IsTrue(callbackCalled);
    }

    [TestMethod]
    public void MySubClass_MyMethodWithFourParameters_KO_ThowsWithAction_WithoutCallback()
    {
        Shim<MyClass> myClass = new Shim<MyClass>();
        myClass.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4"))
               .Throws(() => new ArgumentException("Test"));

        MySubClass instance = new MySubClass();
        try
        {
            instance.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4");
            Assert.Fail("Exception not thrown");
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Test", ex.Message);
        }
    }

    [TestMethod]
    public void MySubClass_MyMethodWithFourParameters_KO_ThowsWithAction_WithCallback()
    {
        bool callbackCalled = false;

        Shim<MyClass> myClass = new Shim<MyClass>();
        myClass.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4"))
               .Throws(() => new ArgumentException("Test"))
               .Callback((string s1, string s2, string s3, string s4) =>
               {
                   Assert.AreEqual("Test1", s1);
                   Assert.AreEqual("Test2", s2);
                   Assert.AreEqual("Test3", s3);
                   Assert.AreEqual("Test4", s4);
                   callbackCalled = true;
               });

        MySubClass instance = new MySubClass();
        try
        {
            instance.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4");
            Assert.Fail("Exception not thrown");
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Test", ex.Message);
        }
        Assert.IsTrue(callbackCalled);
    }

    #endregion

    #region Five parameters

    [TestMethod]
    public void MySubClass_MyMethodWithFiveParameters_OK_WithCallback()
    {
        bool callbackCalled = false;

        Shim<MyClass> myClass = new Shim<MyClass>();
        myClass.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4", "Test5"))
               .Callback((string s1, string s2, string s3, string s4, string s5) =>
               {
                   Assert.AreEqual("Test1", s1);
                   Assert.AreEqual("Test2", s2);
                   Assert.AreEqual("Test3", s3);
                   Assert.AreEqual("Test4", s4);
                   Assert.AreEqual("Test5", s5);
                   callbackCalled = true;
               });

        MySubClass instance = new MySubClass();
        instance.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4", "Test5");
        Assert.IsTrue(callbackCalled);
    }

    [TestMethod]
    public void MySubClass_MyMethodWithFiveParameters_KO_Throws_WithoutCallback()
    {
        Shim<MyClass> myClass = new Shim<MyClass>();
        myClass.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4", "Test5"))
               .Throws<ArgumentException>();

        MySubClass instance = new MySubClass();
        Assert.ThrowsException<ArgumentException>(() => instance.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4", "Test5"));
    }

    [TestMethod]
    public void MySubClass_MyMethodWithFiveParameters_KO_Throws_WithCallback()
    {
        bool callbackCalled = false;

        Shim<MyClass> myClass = new Shim<MyClass>();
        myClass.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4", "Test5"))
               .Throws<ArgumentException>()
               .Callback((string s1, string s2, string s3, string s4, string s5) =>
               {
                   Assert.AreEqual("Test1", s1);
                   Assert.AreEqual("Test2", s2);
                   Assert.AreEqual("Test3", s3);
                   Assert.AreEqual("Test4", s4);
                   Assert.AreEqual("Test5", s5);
                   callbackCalled = true;
               });

        MySubClass instance = new MySubClass();
        Assert.ThrowsException<ArgumentException>(() => instance.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4", "Test5"));
        Assert.IsTrue(callbackCalled);
    }

    [TestMethod]
    public void MySubClass_MyMethodWithFiveParameters_KO_ThrowsWithException_WithoutCallback()
    {
        Shim<MyClass> myClass = new Shim<MyClass>();
        myClass.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4", "Test5"))
               .Throws(new ArgumentException("Test"));

        MySubClass instance = new MySubClass();
        try
        {
            instance.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4", "Test5");
            Assert.Fail("Exception not thrown");
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Test", ex.Message);
        }
    }

    [TestMethod]
    public void MySubClass_MyMethodWithFiveParameters_KO_ThrowsWithException_WithCallback()
    {
        bool callbackCalled = false;

        Shim<MyClass> myClass = new Shim<MyClass>();
        myClass.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4", "Test5"))
               .Throws(new ArgumentException("Test"))
               .Callback((string s1, string s2, string s3, string s4, string s5) =>
               {
                   Assert.AreEqual("Test1", s1);
                   Assert.AreEqual("Test2", s2);
                   Assert.AreEqual("Test3", s3);
                   Assert.AreEqual("Test4", s4);
                   Assert.AreEqual("Test5", s5);
                   callbackCalled = true;
               });

        MySubClass instance = new MySubClass();
        try
        {
            instance.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4", "Test5");
            Assert.Fail("Exception not thrown");
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Test", ex.Message);
        }
        Assert.IsTrue(callbackCalled);
    }

    [TestMethod]
    public void MySubClass_MyMethodWithFiveParameters_KO_ThowsWithDelegate_WithoutCallback()
    {
        Shim<MyClass> myClass = new Shim<MyClass>();
        Delegate exceptionFunction = () => new ArgumentException("Test");
        myClass.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4", "Test5"))
               .Throws(exceptionFunction);

        MySubClass instance = new MySubClass();
        try
        {
            instance.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4", "Test5");
            Assert.Fail("Exception not thrown");
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Test", ex.Message);
        }
    }

    [TestMethod]
    public void MySubClass_MyMethodWithFiveParameters_KO_ThowsWithDelegate_WithCallback()
    {
        bool callbackCalled = false;

        Shim<MyClass> myClass = new Shim<MyClass>();
        Delegate exceptionFunction = () => new ArgumentException("Test");
        myClass.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4", "Test5"))
               .Throws(exceptionFunction)
               .Callback((string s1, string s2, string s3, string s4, string s5) =>
               {
                   Assert.AreEqual("Test1", s1);
                   Assert.AreEqual("Test2", s2);
                   Assert.AreEqual("Test3", s3);
                   Assert.AreEqual("Test4", s4);
                   Assert.AreEqual("Test5", s5);
                   callbackCalled = true;
               });

        MySubClass instance = new MySubClass();
        try
        {
            instance.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4", "Test5");
            Assert.Fail("Exception not thrown");
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Test", ex.Message);
        }
        Assert.IsTrue(callbackCalled);
    }

    [TestMethod]
    public void MySubClass_MyMethodWithFiveParameters_KO_ThowsWithAction_WithoutCallback()
    {
        Shim<MyClass> myClass = new Shim<MyClass>();
        myClass.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4", "Test5"))
               .Throws(() => new ArgumentException("Test"));

        MySubClass instance = new MySubClass();
        try
        {
            instance.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4", "Test5");
            Assert.Fail("Exception not thrown");
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Test", ex.Message);
        }
    }

    [TestMethod]
    public void MySubClass_MyMethodWithFiveParameters_KO_ThowsWithAction_WithCallback()
    {
        bool callbackCalled = false;

        Shim<MyClass> myClass = new Shim<MyClass>();
        myClass.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4", "Test5"))
               .Throws(() => new ArgumentException("Test"))
               .Callback((string s1, string s2, string s3, string s4, string s5) =>
               {
                   Assert.AreEqual("Test1", s1);
                   Assert.AreEqual("Test2", s2);
                   Assert.AreEqual("Test3", s3);
                   Assert.AreEqual("Test4", s4);
                   Assert.AreEqual("Test5", s5);
                   callbackCalled = true;
               });

        MySubClass instance = new MySubClass();
        try
        {
            instance.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4", "Test5");
            Assert.Fail("Exception not thrown");
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Test", ex.Message);
        }
        Assert.IsTrue(callbackCalled);
    }

    #endregion

    #region Six parameters

    [TestMethod]
    public void MySubClass_MyMethodWithSixParameters_OK_WithCallback()
    {
        bool callbackCalled = false;

        Shim<MyClass> myClass = new Shim<MyClass>();
        myClass.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4", "Test5", "Test6"))
               .Callback((string s1, string s2, string s3, string s4, string s5, string s6) =>
               {
                   Assert.AreEqual("Test1", s1);
                   Assert.AreEqual("Test2", s2);
                   Assert.AreEqual("Test3", s3);
                   Assert.AreEqual("Test4", s4);
                   Assert.AreEqual("Test5", s5);
                   Assert.AreEqual("Test6", s6);
                   callbackCalled = true;
               });

        MySubClass instance = new MySubClass();
        instance.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4", "Test5", "Test6");
        Assert.IsTrue(callbackCalled);
    }

    [TestMethod]
    public void MySubClass_MyMethodWithSixParameters_KO_Throws_WithoutCallback()
    {
        Shim<MyClass> myClass = new Shim<MyClass>();
        myClass.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4", "Test5", "Test6"))
               .Throws<ArgumentException>();

        MySubClass instance = new MySubClass();
        Assert.ThrowsException<ArgumentException>(() => instance.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4", "Test5", "Test6"));
    }

    [TestMethod]
    public void MySubClass_MyMethodWithSixParameters_KO_Throws_WithCallback()
    {
        bool callbackCalled = false;

        Shim<MyClass> myClass = new Shim<MyClass>();
        myClass.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4", "Test5", "Test6"))
               .Throws<ArgumentException>()
               .Callback((string s1, string s2, string s3, string s4, string s5, string s6) =>
               {
                   Assert.AreEqual("Test1", s1);
                   Assert.AreEqual("Test2", s2);
                   Assert.AreEqual("Test3", s3);
                   Assert.AreEqual("Test4", s4);
                   Assert.AreEqual("Test5", s5);
                   Assert.AreEqual("Test6", s6);
                   callbackCalled = true;
               });

        MySubClass instance = new MySubClass();
        Assert.ThrowsException<ArgumentException>(() => instance.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4", "Test5", "Test6"));
        Assert.IsTrue(callbackCalled);
    }

    [TestMethod]
    public void MySubClass_MyMethodWithSixParameters_KO_ThrowsWithException_WithoutCallback()
    {
        Shim<MyClass> myClass = new Shim<MyClass>();
        myClass.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4", "Test5", "Test6"))
               .Throws(new ArgumentException("Test"));

        MySubClass instance = new MySubClass();
        try
        {
            instance.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4", "Test5", "Test6");
            Assert.Fail("Exception not thrown");
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Test", ex.Message);
        }
    }

    [TestMethod]
    public void MySubClass_MyMethodWithSixParameters_KO_ThrowsWithException_WithCallback()
    {
        bool callbackCalled = false;

        Shim<MyClass> myClass = new Shim<MyClass>();
        myClass.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4", "Test5", "Test6"))
               .Throws(new ArgumentException("Test"))
               .Callback((string s1, string s2, string s3, string s4, string s5, string s6) =>
               {
                   Assert.AreEqual("Test1", s1);
                   Assert.AreEqual("Test2", s2);
                   Assert.AreEqual("Test3", s3);
                   Assert.AreEqual("Test4", s4);
                   Assert.AreEqual("Test5", s5);
                   Assert.AreEqual("Test6", s6);
                   callbackCalled = true;
               });

        MySubClass instance = new MySubClass();
        try
        {
            instance.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4", "Test5", "Test6");
            Assert.Fail("Exception not thrown");
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Test", ex.Message);
        }
        Assert.IsTrue(callbackCalled);
    }

    [TestMethod]
    public void MySubClass_MyMethodWithSixParameters_KO_ThowsWithDelegate_WithoutCallback()
    {
        Shim<MyClass> myClass = new Shim<MyClass>();
        Delegate exceptionFunction = () => new ArgumentException("Test");
        myClass.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4", "Test5", "Test6"))
               .Throws(exceptionFunction);

        MySubClass instance = new MySubClass();
        try
        {
            instance.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4", "Test5", "Test6");
            Assert.Fail("Exception not thrown");
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Test", ex.Message);
        }
    }

    [TestMethod]
    public void MySubClass_MyMethodWithSixParameters_KO_ThowsWithDelegate_WithCallback()
    {
        bool callbackCalled = false;

        Shim<MyClass> myClass = new Shim<MyClass>();
        Delegate exceptionFunction = () => new ArgumentException("Test");
        myClass.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4", "Test5", "Test6"))
               .Throws(exceptionFunction)
               .Callback((string s1, string s2, string s3, string s4, string s5, string s6) =>
               {
                   Assert.AreEqual("Test1", s1);
                   Assert.AreEqual("Test2", s2);
                   Assert.AreEqual("Test3", s3);
                   Assert.AreEqual("Test4", s4);
                   Assert.AreEqual("Test5", s5);
                   Assert.AreEqual("Test6", s6);
                   callbackCalled = true;
               });

        MySubClass instance = new MySubClass();
        try
        {
            instance.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4", "Test5", "Test6");
            Assert.Fail("Exception not thrown");
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Test", ex.Message);
        }
        Assert.IsTrue(callbackCalled);
    }

    [TestMethod]
    public void MySubClass_MyMethodWithSixParameters_KO_ThowsWithAction_WithoutCallback()
    {
        Shim<MyClass> myClass = new Shim<MyClass>();
        myClass.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4", "Test5", "Test6"))
               .Throws(() => new ArgumentException("Test"));

        MySubClass instance = new MySubClass();
        try
        {
            instance.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4", "Test5", "Test6");
            Assert.Fail("Exception not thrown");
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Test", ex.Message);
        }
    }

    [TestMethod]
    public void MySubClass_MyMethodWithSixParameters_KO_ThowsWithAction_WithCallback()
    {
        bool callbackCalled = false;

        Shim<MyClass> myClass = new Shim<MyClass>();
        myClass.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4", "Test5", "Test6"))
               .Throws(() => new ArgumentException("Test"))
               .Callback((string s1, string s2, string s3, string s4, string s5, string s6) =>
               {
                   Assert.AreEqual("Test1", s1);
                   Assert.AreEqual("Test2", s2);
                   Assert.AreEqual("Test3", s3);
                   Assert.AreEqual("Test4", s4);
                   Assert.AreEqual("Test5", s5);
                   Assert.AreEqual("Test6", s6);
                   callbackCalled = true;
               });

        MySubClass instance = new MySubClass();
        try
        {
            instance.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4", "Test5", "Test6");
            Assert.Fail("Exception not thrown");
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Test", ex.Message);
        }
        Assert.IsTrue(callbackCalled);
    }

    #endregion

    #endregion

    #region MyProperty Get

    [TestMethod]
    public void MySubClass_MyPropertyString_Get()
    {
        Shim<MyClass> shim = new Shim<MyClass>();
        shim.SetupGet(mock => mock.MyPropertyString).Returns("Test");
        MySubClass instance = new MySubClass();
        Assert.AreEqual("Test", instance.MyPropertyString);
    }

    [TestMethod]
    public void MySubClass_MyPropertyInt_Get()
    {
        Shim<MyClass> shim = new Shim<MyClass>();
        shim.SetupGet(mock => mock.MyPropertyInt).Returns(42);
        MySubClass instance = new MySubClass();
        Assert.AreEqual(42, instance.MyPropertyInt);
    }

    [TestMethod]
    public void MySubClass_MyPropertyBool_Get()
    {
        Shim<MyClass> shim = new Shim<MyClass>();
        shim.SetupGet(mock => mock.MyPropertyBool).Returns(true);
        MySubClass instance = new MySubClass();
        Assert.IsTrue(instance.MyPropertyBool);
    }

    [TestMethod]
    public void MySubClass_MyPropertyDouble_Get()
    {
        Shim<MyClass> shim = new Shim<MyClass>();
        shim.SetupGet(mock => mock.MyPropertyDouble).Returns(42.42);
        MySubClass instance = new MySubClass();
        Assert.AreEqual(42.42, instance.MyPropertyDouble);
    }

    [TestMethod]
    public void MySubClass_MyPropertyFloat_Get()
    {
        Shim<MyClass> shim = new Shim<MyClass>();
        shim.SetupGet(mock => mock.MyPropertyFloat).Returns(42.42f);
        MySubClass instance = new MySubClass();
        Assert.AreEqual(42.42f, instance.MyPropertyFloat);
    }

    [TestMethod]
    public void MySubClass_MyPropertyDecimal_Get()
    {
        Shim<MyClass> shim = new Shim<MyClass>();
        shim.SetupGet(mock => mock.MyPropertyDecimal).Returns(42.42m);
        MySubClass instance = new MySubClass();
        Assert.AreEqual(42.42m, instance.MyPropertyDecimal);
    }

    [TestMethod]
    public void MySubClass_MyPropertyDateTime_Get()
    {
        DateTime dateTime = DateTime.Now;
        Shim<MyClass> shim = new Shim<MyClass>();
        shim.SetupGet(mock => mock.MyPropertyDateTime).Returns(dateTime);
        MySubClass instance = new MySubClass();
        Assert.AreEqual(dateTime, instance.MyPropertyDateTime);
    }

    [TestMethod]
    public void MySubClass_MyPropertyGuid_Get()
    {
        Guid guid = Guid.NewGuid();
        Shim<MyClass> shim = new Shim<MyClass>();
        shim.SetupGet(mock => mock.MyPropertyGuid).Returns(guid);
        MySubClass instance = new MySubClass();
        Assert.AreEqual(guid, instance.MyPropertyGuid);
    }

    [TestMethod]
    public void MySubClass_MyPropertyChar_Get()
    {
        Shim<MyClass> shim = new Shim<MyClass>();
        shim.SetupGet(mock => mock.MyPropertyChar).Returns('c');
        MySubClass instance = new MySubClass();
        Assert.AreEqual('c', instance.MyPropertyChar);
    }

    [TestMethod]
    public void MySubClass_MyPropertyByte_Get()
    {
        Shim<MyClass> shim = new Shim<MyClass>();
        shim.SetupGet(mock => mock.MyPropertyByte).Returns(42);
        MySubClass instance = new MySubClass();
        Assert.AreEqual(42, instance.MyPropertyByte);
    }

    [TestMethod]
    public void MySubClass_MyPropertyLong_Get()
    {
        Shim<MyClass> shim = new Shim<MyClass>();
        shim.SetupGet(mock => mock.MyPropertyLong).Returns(42);
        MySubClass instance = new MySubClass();
        Assert.AreEqual(42, instance.MyPropertyLong);
    }

    [TestMethod]
    public void MySubClass_MyPropertyShort_Get()
    {
        Shim<MyClass> shim = new Shim<MyClass>();
        shim.SetupGet(mock => mock.MyPropertyShort).Returns(42);
        MySubClass instance = new MySubClass();
        Assert.AreEqual(42, instance.MyPropertyShort);
    }

    #endregion
}