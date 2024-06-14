using HarmonyLib;
using Shims.TestContext;
using System;
using System.Runtime.CompilerServices;

namespace Shims.NET8.Tests;

[TestClass]
public class MyChildClass_Test : UnitTestBase
{
    #region MyChildMethodWithReturn

    [TestMethod]
    public void MyChildClass_MyChildMethodWithReturn_OK_WithCallback()
    {
        bool callbackCalled = false;

        Shim<MyClass> myClass = new Shim<MyClass>();
        myClass.Setup(x => x.MyMethodWithReturn())
               .Returns("Hello Mock!")
               .Callback(() =>
               {
                   callbackCalled = true;
               });

        MyChildClass instance = new MyChildClass();
        string result = instance.MyChildMethodWithReturn();
        Assert.AreEqual("Hello Mock!", result);
        Assert.IsTrue(callbackCalled);
    }

    [TestMethod]
    public void MyChildClass_MyChildMethodWithReturn_OK_WithoutCallback()
    {
        Shim<MyClass> myClass = new Shim<MyClass>();
        myClass.Setup(x => x.MyMethodWithReturn())
               .Returns("Hello Mock!");

        MyChildClass instance = new MyChildClass();
        string result = instance.MyChildMethodWithReturn();

        Assert.AreEqual("Hello Mock!", result);
    }

    [TestMethod]
    public void MyChildClass_MyChildMethodWithReturn_KO_Throws_WithCallback()
    {
        bool callbackCalled = false;

        Shim<MyClass> myClass = new Shim<MyClass>();
        myClass.Setup(x => x.MyMethodWithReturn())
               .Throws<ArgumentException>()
               .Callback(() =>
               {
                   callbackCalled = true;
               });

        MyChildClass instance = new MyChildClass();
        Assert.ThrowsException<ArgumentException>(() => instance.MyChildMethodWithReturn());
        Assert.IsTrue(callbackCalled);
    }

    [TestMethod]
    public void MyChildClass_MyChildMethodWithReturn_KO_Throws_WithoutCallback()
    {
        Shim<MyClass> myClass = new Shim<MyClass>();
        myClass.Setup(x => x.MyMethodWithReturn())
               .Throws<ArgumentException>();

        MyChildClass instance = new MyChildClass();
        Assert.ThrowsException<ArgumentException>(() => instance.MyChildMethodWithReturn());
    }

    [TestMethod]
    public void MyChildClass_MyChildMethodWithReturn_KO_ThrowsWithException_WithCallback()
    {
        bool callbackCalled = false;

        Shim<MyClass> myClass = new Shim<MyClass>();
        myClass.Setup(x => x.MyMethodWithReturn())
               .Throws(new ArgumentException("Test"))
               .Callback(() =>
               {
                   callbackCalled = true;
               });

        MyChildClass instance = new MyChildClass();
        try
        {
            instance.MyChildMethodWithReturn();
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Test", ex.Message);
        }
        Assert.IsTrue(callbackCalled);
    }

    [TestMethod]
    public void MyChildClass_MyChildMethodWithReturn_KO_ThrowsWithException_WithoutCallback()
    {
        Shim<MyClass> myClass = new Shim<MyClass>();
        myClass.Setup(x => x.MyMethodWithReturn())
               .Throws(new ArgumentException("Test"));

        MyChildClass instance = new MyChildClass();
        try
        {
            instance.MyChildMethodWithReturn();
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Test", ex.Message);
        }
    }

    [TestMethod]
    public void MyChildClass_MyChildMethodWithReturn_KO_ThowsWithDelegate_WithCallback()
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

        MyChildClass instance = new MyChildClass();
        try
        {
            instance.MyChildMethodWithReturn();
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Test", ex.Message);
        }
        Assert.IsTrue(callbackCalled);
    }

    [TestMethod]
    public void MyChildClass_MyChildMethodWithReturn_KO_ThowsWithDelegate_WithoutCallback()
    {
        Shim<MyClass> myClass = new Shim<MyClass>();
        Delegate exceptionFunction = () => new ArgumentException("Test");
        myClass.Setup(x => x.MyMethodWithReturn())
               .Throws(exceptionFunction);

        MyChildClass instance = new MyChildClass();
        try
        {
            instance.MyChildMethodWithReturn();
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Test", ex.Message);
        }
    }

    [TestMethod]
    public void MyChildClass_MyChildMethodWithReturn_KO_ThowsWithAction_WithCallback()
    {
        bool callbackCalled = false;

        Shim<MyClass> myClass = new Shim<MyClass>();
        myClass.Setup(x => x.MyMethodWithReturn())
               .Throws(() => new ArgumentException("Test"))
               .Callback(() =>
               {
                   callbackCalled = true;
               });

        MyChildClass instance = new MyChildClass();
        try
        {
            instance.MyChildMethodWithReturn();
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Test", ex.Message);
        }

        Assert.IsTrue(callbackCalled);
    }

    [TestMethod]
    public void MyChildClass_MyChildMethodWithReturn_KO_ThowsWithAction_WithoutCallback()
    {
        Shim<MyClass> myClass = new Shim<MyClass>();
        myClass.Setup(x => x.MyMethodWithReturn())
               .Throws(() => new ArgumentException("Test"));

        MyChildClass instance = new MyChildClass();
        try
        {
            instance.MyChildMethodWithReturn();
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Test", ex.Message);
        }
    }

    #endregion

    #region MyChildMethod

    [TestMethod]
    public void MyChildClass_MyChildMethod_OK_WithCallback()
    {
        bool callbackCalled = false;

        Shim<MyClass> myClass = new Shim<MyClass>();
        myClass.Setup(mock => mock.MyMethod())
               .Callback(() =>
               {
                   callbackCalled = true;
               });

        MyChildClass instance = new MyChildClass();
        instance.MyChildMethod();
        Assert.IsTrue(callbackCalled);
    }

    [TestMethod]
    public void MyChildClass_MyChildMethod_KO_Throws_WithoutCallback()
    {
        Shim<MyClass> myClass = new Shim<MyClass>();
        myClass.Setup(mock => mock.MyMethod())
               .Throws<ArgumentException>();

        MyChildClass instance = new MyChildClass();
        Assert.ThrowsException<ArgumentException>(() => instance.MyChildMethod());
    }

    [TestMethod]
    public void MyChildClass_MyChildMethod_KO_Throws_WithCallback()
    {
        bool callbackCalled = false;

        Shim<MyClass> myClass = new Shim<MyClass>();
        myClass.Setup(mock => mock.MyMethod())
               .Throws<ArgumentException>()
               .Callback(() =>
               {
                   callbackCalled = true;
               });

        MyChildClass instance = new MyChildClass();
        Assert.ThrowsException<ArgumentException>(() => instance.MyChildMethod());
        Assert.IsTrue(callbackCalled);
    }

    [TestMethod]
    public void MyChildClass_MyChildMethod_KO_ThrowsWithException_WithoutCallback()
    {
        Shim<MyClass> myClass = new Shim<MyClass>();
        myClass.Setup(mock => mock.MyMethod())
               .Throws(new ArgumentException("Test"));

        MyChildClass instance = new MyChildClass();
        try
        {
            instance.MyChildMethod();
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Test", ex.Message);
        }
    }

    [TestMethod]
    public void MyChildClass_MyChildMethod_KO_ThrowsWithException_WithCallback()
    {
        bool callbackCalled = false;

        Shim<MyClass> myClass = new Shim<MyClass>();
        myClass.Setup(mock => mock.MyMethod())
               .Throws(new ArgumentException("Test"))
               .Callback(() =>
               {
                   callbackCalled = true;
               });

        MyChildClass instance = new MyChildClass();
        try
        {
            instance.MyChildMethod();
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Test", ex.Message);
        }
        Assert.IsTrue(callbackCalled);
    }

    [TestMethod]
    public void MyChildClass_MyChildMethod_KO_ThowsWithDelegate_WithoutCallback()
    {
        Shim<MyClass> myClass = new Shim<MyClass>();
        Delegate exceptionFunction = () => new ArgumentException("Test");
        myClass.Setup(mock => mock.MyMethod())
               .Throws(exceptionFunction);

        MyChildClass instance = new MyChildClass();
        try
        {
            instance.MyChildMethod();
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Test", ex.Message);
        }
    }

    [TestMethod]
    public void MyChildClass_MyChildMethod_KO_ThowsWithDelegate_WithCallback()
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

        MyChildClass instance = new MyChildClass();
        try
        {
            instance.MyChildMethod();
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Test", ex.Message);
        }
        Assert.IsTrue(callbackCalled);
    }

    [TestMethod]
    public void MyChildClass_MyChildMethod_KO_ThowsWithAction_WithoutCallback()
    {
        Shim<MyClass> myClass = new Shim<MyClass>();
        myClass.Setup(mock => mock.MyMethod())
               .Throws(() => new ArgumentException("Test"));

        MyChildClass instance = new MyChildClass();
        try
        {
            instance.MyChildMethod();
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Test", ex.Message);
        }
    }

    [TestMethod]
    public void MyChildClass_MyChildMethod_KO_ThowsWithAction_WithCallback()
    {
        bool callbackCalled = false;

        Shim<MyClass> myClass = new Shim<MyClass>();
        myClass.Setup(mock => mock.MyMethod())
               .Throws(() => new ArgumentException("Test"))
               .Callback(() =>
               {
                   callbackCalled = true;
               });

        MyChildClass instance = new MyChildClass();
        try
        {
            instance.MyChildMethod();
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Test", ex.Message);
        }
        Assert.IsTrue(callbackCalled);
    }

    #endregion

    #region MyChildMethodWithParameter

    [TestMethod]
    public void MyChildClass_MyChildMethodWithParameter_OK_WithCallback()
    {
        bool callbackCalled = false;

        Shim<MyClass> myClass = new Shim<MyClass>();
        myClass.Setup(mock => mock.MyMethodWithParameter("Test"))
               .Callback((string s) =>
               {
                   Assert.AreEqual("Test", s);
                   callbackCalled = true;
               });

        MyChildClass instance = new MyChildClass();
        instance.MyChildMethodWithParameter("Test");
        Assert.IsTrue(callbackCalled);
    }

    [TestMethod]
    public void MyChildClass_MyChildMethodWithParameter_KO_Throws_WithoutCallback()
    {
        Shim<MyClass> myClass = new Shim<MyClass>();
        myClass.Setup(mock => mock.MyMethodWithParameter("Test"))
               .Throws<ArgumentException>();

        MyChildClass instance = new MyChildClass();
        Assert.ThrowsException<ArgumentException>(() => instance.MyChildMethodWithParameter("Test"));
    }

    [TestMethod]
    public void MyChildClass_MyChildMethodWithParameter_KO_Throws_WithCallback()
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

        MyChildClass instance = new MyChildClass();
        Assert.ThrowsException<ArgumentException>(() => instance.MyChildMethodWithParameter("Test"));
        Assert.IsTrue(callbackCalled);
    }

    [TestMethod]
    public void MyChildClass_MyChildMethodWithParameter_KO_ThrowsWithException_WithoutCallback()
    {
        Shim<MyClass> myClass = new Shim<MyClass>();
        myClass.Setup(mock => mock.MyMethodWithParameter("Test"))
               .Throws(new ArgumentException("Test"));

        MyChildClass instance = new MyChildClass();
        try
        {
            instance.MyChildMethodWithParameter("Test");
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Test", ex.Message);
        }
    }

    [TestMethod]
    public void MyChildClass_MyChildMethodWithParameter_KO_ThrowsWithException_WithCallback()
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

        MyChildClass instance = new MyChildClass();
        try
        {
            instance.MyChildMethodWithParameter("Test");
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Test", ex.Message);
        }
        Assert.IsTrue(callbackCalled);
    }

    [TestMethod]
    public void MyChildClass_MyChildMethodWithParameter_KO_ThowsWithDelegate_WithoutCallback()
    {
        Shim<MyClass> myClass = new Shim<MyClass>();
        Delegate exceptionFunction = () => new ArgumentException("Test");
        myClass.Setup(mock => mock.MyMethodWithParameter("Test"))
               .Throws(exceptionFunction);

        MyChildClass instance = new MyChildClass();
        try
        {
            instance.MyChildMethodWithParameter("Test");
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Test", ex.Message);
        }
    }

    [TestMethod]
    public void MyChildClass_MyChildMethodWithParameter_KO_ThowsWithDelegate_WithCallback()
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

        MyChildClass instance = new MyChildClass();
        try
        {
            instance.MyChildMethodWithParameter("Test");
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Test", ex.Message);
        }
        Assert.IsTrue(callbackCalled);
    }

    [TestMethod]
    public void MyChildClass_MyChildMethodWithParameter_KO_ThowsWithAction_WithoutCallback()
    {
        Shim<MyClass> myClass = new Shim<MyClass>();
        myClass.Setup(mock => mock.MyMethodWithParameter("Test"))
               .Throws(() => new ArgumentException("Test"));

        MyChildClass instance = new MyChildClass();
        try
        {
            instance.MyChildMethodWithParameter("Test");
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Test", ex.Message);
        }
    }

    [TestMethod]
    public void MyChildClass_MyChildMethodWithParameter_KO_ThowsWithAction_WithCallback()
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

        MyChildClass instance = new MyChildClass();
        try
        {
            instance.MyChildMethodWithParameter("Test");
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Test", ex.Message);
        }
        Assert.IsTrue(callbackCalled);
    }

    #endregion

    #region MyChildMethodWithParameters

    #region Two parameters

    [TestMethod]
    public void MyChildClass_MyChildMethodWithTwoParameters_OK_WithCallback()
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

        MyChildClass instance = new MyChildClass();
        instance.MyChildMethodWithParameters("Test1", "Test2");
        Assert.IsTrue(callbackCalled);
    }

    [TestMethod]
    public void MyChildClass_MyChildMethodWithTwoParameters_KO_Throws_WithoutCallback()
    {
        Shim<MyClass> myClass = new Shim<MyClass>();
        myClass.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2"))
               .Throws<ArgumentException>();

        MyChildClass instance = new MyChildClass();
        Assert.ThrowsException<ArgumentException>(() => instance.MyChildMethodWithParameters("Test1", "Test2"));
    }

    [TestMethod]
    public void MyChildClass_MyChildMethodWithTwoParameters_KO_Throws_WithCallback()
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

        MyChildClass instance = new MyChildClass();
        Assert.ThrowsException<ArgumentException>(() => instance.MyChildMethodWithParameters("Test1", "Test2"));
        Assert.IsTrue(callbackCalled);
    }

    [TestMethod]
    public void MyChildClass_MyChildMethodWithTwoParameters_KO_ThrowsWithException_WithoutCallback()
    {
        Shim<MyClass> myClass = new Shim<MyClass>();
        myClass.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2"))
               .Throws(new ArgumentException("Test"));

        MyChildClass instance = new MyChildClass();
        try
        {
            instance.MyChildMethodWithParameters("Test1", "Test2");
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Test", ex.Message);
        }
    }

    [TestMethod]
    public void MyChildClass_MyChildMethodWithTwoParameters_KO_ThrowsWithException_WithCallback()
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

        MyChildClass instance = new MyChildClass();
        try
        {
            instance.MyChildMethodWithParameters("Test1", "Test2");
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Test", ex.Message);
        }
        Assert.IsTrue(callbackCalled);
    }

    [TestMethod]
    public void MyChildClass_MyChildMethodWithTwoParameters_KO_ThowsWithDelegate_WithoutCallback()
    {
        Shim<MyClass> myClass = new Shim<MyClass>();
        Delegate exceptionFunction = () => new ArgumentException("Test");
        myClass.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2"))
               .Throws(exceptionFunction);

        MyChildClass instance = new MyChildClass();
        try
        {
            instance.MyChildMethodWithParameters("Test1", "Test2");
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Test", ex.Message);
        }
    }

    [TestMethod]
    public void MyChildClass_MyChildMethodWithTwoParameters_KO_ThowsWithDelegate_WithCallback()
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

        MyChildClass instance = new MyChildClass();
        try
        {
            instance.MyChildMethodWithParameters("Test1", "Test2");
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Test", ex.Message);
        }
        Assert.IsTrue(callbackCalled);
    }

    [TestMethod]
    public void MyChildClass_MyChildMethodWithTwoParameters_KO_ThowsWithAction_WithoutCallback()
    {
        Shim<MyClass> myClass = new Shim<MyClass>();
        myClass.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2"))
               .Throws(() => new ArgumentException("Test"));

        MyChildClass instance = new MyChildClass();
        try
        {
            instance.MyChildMethodWithParameters("Test1", "Test2");
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Test", ex.Message);
        }
    }

    [TestMethod]
    public void MyChildClass_MyChildMethodWithTwoParameters_KO_ThowsWithAction_WithCallback()
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

        MyChildClass instance = new MyChildClass();
        try
        {
            instance.MyChildMethodWithParameters("Test1", "Test2");
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
    public void MyChildClass_MyChildMethodWithThreeParameters_OK_WithCallback()
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

        MyChildClass instance = new MyChildClass();
        instance.MyChildMethodWithParameters("Test1", "Test2", "Test3");
        Assert.IsTrue(callbackCalled);
    }

    [TestMethod]
    public void MyChildClass_MyChildMethodWithThreeParameters_KO_Throws_WithoutCallback()
    {
        Shim<MyClass> myClass = new Shim<MyClass>();
        myClass.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2", "Test3"))
               .Throws<ArgumentException>();

        MyChildClass instance = new MyChildClass();
        Assert.ThrowsException<ArgumentException>(() => instance.MyChildMethodWithParameters("Test1", "Test2", "Test3"));
    }

    [TestMethod]
    public void MyChildClass_MyChildMethodWithThreeParameters_KO_Throws_WithCallback()
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

        MyChildClass instance = new MyChildClass();
        Assert.ThrowsException<ArgumentException>(() => instance.MyChildMethodWithParameters("Test1", "Test2", "Test3"));
        Assert.IsTrue(callbackCalled);
    }

    [TestMethod]
    public void MyChildClass_MyChildMethodWithThreeParameters_KO_ThrowsWithException_WithoutCallback()
    {
        Shim<MyClass> myClass = new Shim<MyClass>();
        myClass.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2", "Test3"))
               .Throws(new ArgumentException("Test"));

        MyChildClass instance = new MyChildClass();
        try
        {
            instance.MyChildMethodWithParameters("Test1", "Test2", "Test3");
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Test", ex.Message);
        }
    }

    [TestMethod]
    public void MyChildClass_MyChildMethodWithThreeParameters_KO_ThrowsWithException_WithCallback()
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

        MyChildClass instance = new MyChildClass();
        try
        {
            instance.MyChildMethodWithParameters("Test1", "Test2", "Test3");
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Test", ex.Message);
        }
        Assert.IsTrue(callbackCalled);
    }

    [TestMethod]
    public void MyChildClass_MyChildMethodWithThreeParameters_KO_ThowsWithDelegate_WithoutCallback()
    {
        Shim<MyClass> myClass = new Shim<MyClass>();
        Delegate exceptionFunction = () => new ArgumentException("Test");
        myClass.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2", "Test3"))
               .Throws(exceptionFunction);

        MyChildClass instance = new MyChildClass();
        try
        {
            instance.MyChildMethodWithParameters("Test1", "Test2", "Test3");
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Test", ex.Message);
        }
    }

    [TestMethod]
    public void MyChildClass_MyChildMethodWithThreeParameters_KO_ThowsWithDelegate_WithCallback()
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

        MyChildClass instance = new MyChildClass();
        try
        {
            instance.MyChildMethodWithParameters("Test1", "Test2", "Test3");
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Test", ex.Message);
        }
        Assert.IsTrue(callbackCalled);
    }

    [TestMethod]
    public void MyChildClass_MyChildMethodWithThreeParameters_KO_ThowsWithAction_WithoutCallback()
    {
        Shim<MyClass> myClass = new Shim<MyClass>();
        myClass.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2", "Test3"))
               .Throws(() => new ArgumentException("Test"));

        MyChildClass instance = new MyChildClass();
        try
        {
            instance.MyChildMethodWithParameters("Test1", "Test2", "Test3");
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Test", ex.Message);
        }
    }

    [TestMethod]
    public void MyChildClass_MyChildMethodWithThreeParameters_KO_ThowsWithAction_WithCallback()
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

        MyChildClass instance = new MyChildClass();
        try
        {
            instance.MyChildMethodWithParameters("Test1", "Test2", "Test3");
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
    public void MyChildClass_MyChildMethodWithFourParameters_OK_WithCallback()
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

        MyChildClass instance = new MyChildClass();
        instance.MyChildMethodWithParameters("Test1", "Test2", "Test3", "Test4");
        Assert.IsTrue(callbackCalled);
    }

    [TestMethod]
    public void MyChildClass_MyChildMethodWithFourParameters_KO_Throws_WithoutCallback()
    {
        Shim<MyClass> myClass = new Shim<MyClass>();
        myClass.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4"))
               .Throws<ArgumentException>();

        MyChildClass instance = new MyChildClass();
        Assert.ThrowsException<ArgumentException>(() => instance.MyChildMethodWithParameters("Test1", "Test2", "Test3", "Test4"));
    }

    [TestMethod]
    public void MyChildClass_MyChildMethodWithFourParameters_KO_Throws_WithCallback()
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

        MyChildClass instance = new MyChildClass();
        Assert.ThrowsException<ArgumentException>(() => instance.MyChildMethodWithParameters("Test1", "Test2", "Test3", "Test4"));
        Assert.IsTrue(callbackCalled);
    }

    [TestMethod]
    public void MyChildClass_MyChildMethodWithFourParameters_KO_ThrowsWithException_WithoutCallback()
    {
        Shim<MyClass> myClass = new Shim<MyClass>();
        myClass.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4"))
               .Throws(new ArgumentException("Test"));

        MyChildClass instance = new MyChildClass();
        try
        {
            instance.MyChildMethodWithParameters("Test1", "Test2", "Test3", "Test4");
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Test", ex.Message);
        }
    }

    [TestMethod]
    public void MyChildClass_MyChildMethodWithFourParameters_KO_ThrowsWithException_WithCallback()
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

        MyChildClass instance = new MyChildClass();
        try
        {
            instance.MyChildMethodWithParameters("Test1", "Test2", "Test3", "Test4");
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Test", ex.Message);
        }
        Assert.IsTrue(callbackCalled);
    }

    [TestMethod]
    public void MyChildClass_MyChildMethodWithFourParameters_KO_ThowsWithDelegate_WithoutCallback()
    {
        Shim<MyClass> myClass = new Shim<MyClass>();
        Delegate exceptionFunction = () => new ArgumentException("Test");
        myClass.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4"))
               .Throws(exceptionFunction);

        MyChildClass instance = new MyChildClass();
        try
        {
            instance.MyChildMethodWithParameters("Test1", "Test2", "Test3", "Test4");
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Test", ex.Message);
        }
    }

    [TestMethod]
    public void MyChildClass_MyChildMethodWithFourParameters_KO_ThowsWithDelegate_WithCallback()
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

        MyChildClass instance = new MyChildClass();
        try
        {
            instance.MyChildMethodWithParameters("Test1", "Test2", "Test3", "Test4");
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Test", ex.Message);
        }
        Assert.IsTrue(callbackCalled);
    }

    [TestMethod]
    public void MyChildClass_MyChildMethodWithFourParameters_KO_ThowsWithAction_WithoutCallback()
    {
        Shim<MyClass> myClass = new Shim<MyClass>();
        myClass.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4"))
               .Throws(() => new ArgumentException("Test"));

        MyChildClass instance = new MyChildClass();
        try
        {
            instance.MyChildMethodWithParameters("Test1", "Test2", "Test3", "Test4");
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Test", ex.Message);
        }
    }

    [TestMethod]
    public void MyChildClass_MyChildMethodWithFourParameters_KO_ThowsWithAction_WithCallback()
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

        MyChildClass instance = new MyChildClass();
        try
        {
            instance.MyChildMethodWithParameters("Test1", "Test2", "Test3", "Test4");
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
    public void MyChildClass_MyChildMethodWithFiveParameters_OK_WithCallback()
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

        MyChildClass instance = new MyChildClass();
        instance.MyChildMethodWithParameters("Test1", "Test2", "Test3", "Test4", "Test5");
        Assert.IsTrue(callbackCalled);
    }

    [TestMethod]
    public void MyChildClass_MyChildMethodWithFiveParameters_KO_Throws_WithoutCallback()
    {
        Shim<MyClass> myClass = new Shim<MyClass>();
        myClass.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4", "Test5"))
               .Throws<ArgumentException>();

        MyChildClass instance = new MyChildClass();
        Assert.ThrowsException<ArgumentException>(() => instance.MyChildMethodWithParameters("Test1", "Test2", "Test3", "Test4", "Test5"));
    }

    [TestMethod]
    public void MyChildClass_MyChildMethodWithFiveParameters_KO_Throws_WithCallback()
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

        MyChildClass instance = new MyChildClass();
        Assert.ThrowsException<ArgumentException>(() => instance.MyChildMethodWithParameters("Test1", "Test2", "Test3", "Test4", "Test5"));
        Assert.IsTrue(callbackCalled);
    }

    [TestMethod]
    public void MyChildClass_MyChildMethodWithFiveParameters_KO_ThrowsWithException_WithoutCallback()
    {
        Shim<MyClass> myClass = new Shim<MyClass>();
        myClass.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4", "Test5"))
               .Throws(new ArgumentException("Test"));

        MyChildClass instance = new MyChildClass();
        try
        {
            instance.MyChildMethodWithParameters("Test1", "Test2", "Test3", "Test4", "Test5");
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Test", ex.Message);
        }
    }

    [TestMethod]
    public void MyChildClass_MyChildMethodWithFiveParameters_KO_ThrowsWithException_WithCallback()
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

        MyChildClass instance = new MyChildClass();
        try
        {
            instance.MyChildMethodWithParameters("Test1", "Test2", "Test3", "Test4", "Test5");
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Test", ex.Message);
        }
        Assert.IsTrue(callbackCalled);
    }

    [TestMethod]
    public void MyChildClass_MyChildMethodWithFiveParameters_KO_ThowsWithDelegate_WithoutCallback()
    {
        Shim<MyClass> myClass = new Shim<MyClass>();
        Delegate exceptionFunction = () => new ArgumentException("Test");
        myClass.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4", "Test5"))
               .Throws(exceptionFunction);

        MyChildClass instance = new MyChildClass();
        try
        {
            instance.MyChildMethodWithParameters("Test1", "Test2", "Test3", "Test4", "Test5");
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Test", ex.Message);
        }
    }

    [TestMethod]
    public void MyChildClass_MyChildMethodWithFiveParameters_KO_ThowsWithDelegate_WithCallback()
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

        MyChildClass instance = new MyChildClass();
        try
        {
            instance.MyChildMethodWithParameters("Test1", "Test2", "Test3", "Test4", "Test5");
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Test", ex.Message);
        }
        Assert.IsTrue(callbackCalled);
    }

    [TestMethod]
    public void MyChildClass_MyChildMethodWithFiveParameters_KO_ThowsWithAction_WithoutCallback()
    {
        Shim<MyClass> myClass = new Shim<MyClass>();
        myClass.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4", "Test5"))
               .Throws(() => new ArgumentException("Test"));

        MyChildClass instance = new MyChildClass();
        try
        {
            instance.MyChildMethodWithParameters("Test1", "Test2", "Test3", "Test4", "Test5");
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Test", ex.Message);
        }
    }

    [TestMethod]
    public void MyChildClass_MyChildMethodWithFiveParameters_KO_ThowsWithAction_WithCallback()
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

        MyChildClass instance = new MyChildClass();
        try
        {
            instance.MyChildMethodWithParameters("Test1", "Test2", "Test3", "Test4", "Test5");
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
    public void MyChildClass_MyChildMethodWithSixParameters_OK_WithCallback()
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

        MyChildClass instance = new MyChildClass();
        instance.MyChildMethodWithParameters("Test1", "Test2", "Test3", "Test4", "Test5", "Test6");
        Assert.IsTrue(callbackCalled);
    }

    [TestMethod]
    public void MyChildClass_MyChildMethodWithSixParameters_KO_Throws_WithoutCallback()
    {
        Shim<MyClass> myClass = new Shim<MyClass>();
        myClass.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4", "Test5", "Test6"))
               .Throws<ArgumentException>();

        MyChildClass instance = new MyChildClass();
        Assert.ThrowsException<ArgumentException>(() => instance.MyChildMethodWithParameters("Test1", "Test2", "Test3", "Test4", "Test5", "Test6"));
    }

    [TestMethod]
    public void MyChildClass_MyChildMethodWithSixParameters_KO_Throws_WithCallback()
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

        MyChildClass instance = new MyChildClass();
        Assert.ThrowsException<ArgumentException>(() => instance.MyChildMethodWithParameters("Test1", "Test2", "Test3", "Test4", "Test5", "Test6"));
        Assert.IsTrue(callbackCalled);
    }

    [TestMethod]
    public void MyChildClass_MyChildMethodWithSixParameters_KO_ThrowsWithException_WithoutCallback()
    {
        Shim<MyClass> myClass = new Shim<MyClass>();
        myClass.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4", "Test5", "Test6"))
               .Throws(new ArgumentException("Test"));

        MyChildClass instance = new MyChildClass();
        try
        {
            instance.MyChildMethodWithParameters("Test1", "Test2", "Test3", "Test4", "Test5", "Test6");
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Test", ex.Message);
        }
    }

    [TestMethod]
    public void MyChildClass_MyChildMethodWithSixParameters_KO_ThrowsWithException_WithCallback()
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

        MyChildClass instance = new MyChildClass();
        try
        {
            instance.MyChildMethodWithParameters("Test1", "Test2", "Test3", "Test4", "Test5", "Test6");
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Test", ex.Message);
        }
        Assert.IsTrue(callbackCalled);
    }

    [TestMethod]
    public void MyChildClass_MyChildMethodWithSixParameters_KO_ThowsWithDelegate_WithoutCallback()
    {
        Shim<MyClass> myClass = new Shim<MyClass>();
        Delegate exceptionFunction = () => new ArgumentException("Test");
        myClass.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4", "Test5", "Test6"))
               .Throws(exceptionFunction);

        MyChildClass instance = new MyChildClass();
        try
        {
            instance.MyChildMethodWithParameters("Test1", "Test2", "Test3", "Test4", "Test5", "Test6");
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Test", ex.Message);
        }
    }

    [TestMethod]
    public void MyChildClass_MyChildMethodWithSixParameters_KO_ThowsWithDelegate_WithCallback()
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

        MyChildClass instance = new MyChildClass();
        try
        {
            instance.MyChildMethodWithParameters("Test1", "Test2", "Test3", "Test4", "Test5", "Test6");
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Test", ex.Message);
        }
        Assert.IsTrue(callbackCalled);
    }

    [TestMethod]
    public void MyChildClass_MyChildMethodWithSixParameters_KO_ThowsWithAction_WithoutCallback()
    {
        Shim<MyClass> myClass = new Shim<MyClass>();
        myClass.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4", "Test5", "Test6"))
               .Throws(() => new ArgumentException("Test"));

        MyChildClass instance = new MyChildClass();
        try
        {
            instance.MyChildMethodWithParameters("Test1", "Test2", "Test3", "Test4", "Test5", "Test6");
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Test", ex.Message);
        }
    }

    [TestMethod]
    public void MyChildClass_MyChildMethodWithSixParameters_KO_ThowsWithAction_WithCallback()
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

        MyChildClass instance = new MyChildClass();
        try
        {
            instance.MyChildMethodWithParameters("Test1", "Test2", "Test3", "Test4", "Test5", "Test6");
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Test", ex.Message);
        }
        Assert.IsTrue(callbackCalled);
    }

    #endregion

    #region MyProperty Get

    [TestMethod]
    public void MyChildClass_MyPropertyString_Get()
    {
        Shim<MyClass> shim = new Shim<MyClass>();
        shim.SetupGet(mock => mock.MyPropertyString).Returns("Test");
        MyChildClass instance = new MyChildClass();
        Assert.AreEqual("Test", instance.MyPropertyString);
    }

    [TestMethod]
    public void MyChildClass_MyPropertyInt_Get()
    {
        Shim<MyClass> shim = new Shim<MyClass>();
        shim.SetupGet(mock => mock.MyPropertyInt).Returns(42);
        MyChildClass instance = new MyChildClass();
        Assert.AreEqual(42, instance.MyPropertyInt);
    }

    [TestMethod]
    public void MyChildClass_MyPropertyBool_Get()
    {
        Shim<MyClass> shim = new Shim<MyClass>();
        shim.SetupGet(mock => mock.MyPropertyBool).Returns(true);
        MyChildClass instance = new MyChildClass();
        Assert.IsTrue(instance.MyPropertyBool);
    }

    [TestMethod]
    public void MyChildClass_MyPropertyDouble_Get()
    {
        Shim<MyClass> shim = new Shim<MyClass>();
        shim.SetupGet(mock => mock.MyPropertyDouble).Returns(42.42);
        MyChildClass instance = new MyChildClass();
        Assert.AreEqual(42.42, instance.MyPropertyDouble);
    }

    [TestMethod]
    public void MyChildClass_MyPropertyFloat_Get()
    {
        Shim<MyClass> shim = new Shim<MyClass>();
        shim.SetupGet(mock => mock.MyPropertyFloat).Returns(42.42f);
        MyChildClass instance = new MyChildClass();
        Assert.AreEqual(42.42f, instance.MyPropertyFloat);
    }

    [TestMethod]
    public void MyChildClass_MyPropertyDecimal_Get()
    {
        Shim<MyClass> shim = new Shim<MyClass>();
        shim.SetupGet(mock => mock.MyPropertyDecimal).Returns(42.42m);
        MyChildClass instance = new MyChildClass();
        Assert.AreEqual(42.42m, instance.MyPropertyDecimal);
    }

    [TestMethod]
    public void MyChildClass_MyPropertyDateTime_Get()
    {
        DateTime dateTime = DateTime.Now;
        Shim<MyClass> shim = new Shim<MyClass>();
        shim.SetupGet(mock => mock.MyPropertyDateTime).Returns(dateTime);
        MyChildClass instance = new MyChildClass();
        Assert.AreEqual(dateTime, instance.MyPropertyDateTime);
    }

    [TestMethod]
    public void MyChildClass_MyPropertyGuid_Get()
    {
        Guid guid = Guid.NewGuid();
        Shim<MyClass> shim = new Shim<MyClass>();
        shim.SetupGet(mock => mock.MyPropertyGuid).Returns(guid);
        MyChildClass instance = new MyChildClass();
        Assert.AreEqual(guid, instance.MyPropertyGuid);
    }

    [TestMethod]
    public void MyChildClass_MyPropertyChar_Get()
    {
        Shim<MyClass> shim = new Shim<MyClass>();
        shim.SetupGet(mock => mock.MyPropertyChar).Returns('c');
        MyChildClass instance = new MyChildClass();
        Assert.AreEqual('c', instance.MyPropertyChar);
    }

    [TestMethod]
    public void MyChildClass_MyPropertyByte_Get()
    {
        Shim<MyClass> shim = new Shim<MyClass>();
        shim.SetupGet(mock => mock.MyPropertyByte).Returns(42);
        MyChildClass instance = new MyChildClass();
        Assert.AreEqual(42, instance.MyPropertyByte);
    }

    [TestMethod]
    public void MyChildClass_MyPropertyLong_Get()
    {
        Shim<MyClass> shim = new Shim<MyClass>();
        shim.SetupGet(mock => mock.MyPropertyLong).Returns(42);
        MyChildClass instance = new MyChildClass();
        Assert.AreEqual(42, instance.MyPropertyLong);
    }

    [TestMethod]
    public void MyChildClass_MyPropertyShort_Get()
    {
        Shim<MyClass> shim = new Shim<MyClass>();
        shim.SetupGet(mock => mock.MyPropertyShort).Returns(42);
        MyChildClass instance = new MyChildClass();
        Assert.AreEqual(42, instance.MyPropertyShort);
    }

    #endregion


    #endregion
}