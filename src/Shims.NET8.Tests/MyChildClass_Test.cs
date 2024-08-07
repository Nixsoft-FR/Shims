﻿using Shims.TestContext;

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
            Assert.Fail("Exception not thrown");
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
            Assert.Fail("Exception not thrown");
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
            Assert.Fail("Exception not thrown");
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
            Assert.Fail("Exception not thrown");
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
            Assert.Fail("Exception not thrown");
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
            Assert.Fail("Exception not thrown");
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
            Assert.Fail("Exception not thrown");
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
            Assert.Fail("Exception not thrown");
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
            Assert.Fail("Exception not thrown");
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
            Assert.Fail("Exception not thrown");
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
            Assert.Fail("Exception not thrown");
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
            Assert.Fail("Exception not thrown");
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
            Assert.Fail("Exception not thrown");
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
            Assert.Fail("Exception not thrown");
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
            Assert.Fail("Exception not thrown");
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
            Assert.Fail("Exception not thrown");
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
            Assert.Fail("Exception not thrown");
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
            Assert.Fail("Exception not thrown");
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
            Assert.Fail("Exception not thrown");
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
            Assert.Fail("Exception not thrown");
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
            Assert.Fail("Exception not thrown");
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
            Assert.Fail("Exception not thrown");
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
            Assert.Fail("Exception not thrown");
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
            Assert.Fail("Exception not thrown");
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
            Assert.Fail("Exception not thrown");
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
            Assert.Fail("Exception not thrown");
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
            Assert.Fail("Exception not thrown");
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
            Assert.Fail("Exception not thrown");
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
            Assert.Fail("Exception not thrown");
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
            Assert.Fail("Exception not thrown");
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
            Assert.Fail("Exception not thrown");
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
            Assert.Fail("Exception not thrown");
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
            Assert.Fail("Exception not thrown");
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
            Assert.Fail("Exception not thrown");
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
            Assert.Fail("Exception not thrown");
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
            Assert.Fail("Exception not thrown");
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
            Assert.Fail("Exception not thrown");
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
            Assert.Fail("Exception not thrown");
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
            Assert.Fail("Exception not thrown");
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
            Assert.Fail("Exception not thrown");
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
            Assert.Fail("Exception not thrown");
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
            Assert.Fail("Exception not thrown");
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

    [TestMethod]
    public void MyChildClass_MySpecialPropertyString_Get()
    {
        Shim<MyClass> shim = new Shim<MyClass>();
        shim.SetupGet(mock => mock.MySpecialPropertyString).Returns("Test");
        MyChildClass instance = new MyChildClass();
        Assert.AreEqual("Test", instance.MySpecialPropertyString);
    }

    #endregion

    #region MyProperty Set

    [TestMethod]
    public void MyChildClass_MyPropertyString_Set()
    {
        string value = "Test";
        Shim<MyClass> shim = new Shim<MyClass>();
        shim.SetupSet(mock => mock.MyPropertyString).Callback((string v) => Assert.AreEqual(value, v));
        MyChildClass instance = new MyChildClass();
        instance.MyPropertyString = value;
    }

    [TestMethod]
    public void MyChildClass_MyPropertyInt_Set()
    {
        int value = 42;
        Shim<MyClass> shim = new Shim<MyClass>();
        shim.SetupSet(mock => mock.MyPropertyInt).Callback((int v) => Assert.AreEqual(value, v));
        MyChildClass instance = new MyChildClass();
        instance.MyPropertyInt = value;
    }

    [TestMethod]
    public void MyChildClass_MyPropertyBool_Set()
    {
        bool value = true;
        Shim<MyClass> shim = new Shim<MyClass>();
        shim.SetupSet(mock => mock.MyPropertyBool).Callback((bool v) => Assert.IsTrue(v));
        MyChildClass instance = new MyChildClass();
        instance.MyPropertyBool = value;
    }

    [TestMethod]
    public void MyChildClass_MyPropertyDouble_Set()
    {
        double value = 42.42;
        Shim<MyClass> shim = new Shim<MyClass>();
        shim.SetupSet(mock => mock.MyPropertyDouble).Callback((double v) => Assert.AreEqual(value, v));
        MyChildClass instance = new MyChildClass();
        instance.MyPropertyDouble = value;
    }

    [TestMethod]
    public void MyChildClass_MyPropertyFloat_Set()
    {
        float value = 42.42f;
        Shim<MyClass> shim = new Shim<MyClass>();
        shim.SetupSet(mock => mock.MyPropertyFloat).Callback((float v) => Assert.AreEqual(42.42f, v));
        MyChildClass instance = new MyChildClass();
        instance.MyPropertyFloat = value;
    }

    [TestMethod]
    public void MyChildClass_MyPropertyDecimal_Set()
    {
        decimal value = 42.42m;
        Shim<MyClass> shim = new Shim<MyClass>();
        shim.SetupSet(mock => mock.MyPropertyDecimal).Callback((decimal v) => Assert.AreEqual(value, v));
        MyChildClass instance = new MyChildClass();
        instance.MyPropertyDecimal = value;
    }

    [TestMethod]
    public void MyChildClass_MyPropertyDateTime_Set()
    {
        DateTime value = DateTime.Now;
        Shim<MyClass> shim = new Shim<MyClass>();
        shim.SetupSet(mock => mock.MyPropertyDateTime).Callback((DateTime v) => Assert.AreEqual(value, v));
        MyChildClass instance = new MyChildClass();
        instance.MyPropertyDateTime = value;
    }

    [TestMethod]
    public void MyChildClass_MyPropertyGuid_Set()
    {
        Guid value = Guid.NewGuid();
        Shim<MyClass> shim = new Shim<MyClass>();
        shim.SetupSet(mock => mock.MyPropertyGuid).Callback((Guid v) => Assert.AreEqual(value, v));
        MyChildClass instance = new MyChildClass();
        instance.MyPropertyGuid = value;
    }

    [TestMethod]
    public void MyChildClass_MyPropertyChar_Set()
    {
        char value = 'c';
        Shim<MyClass> shim = new Shim<MyClass>();
        shim.SetupSet(mock => mock.MyPropertyChar).Callback((char v) => Assert.AreEqual(value, v));
        MyChildClass instance = new MyChildClass();
        instance.MyPropertyChar = value;
    }

    [TestMethod]
    public void MyChildClass_MyPropertyByte_Set()
    {
        byte value = 42;
        Shim<MyClass> shim = new Shim<MyClass>();
        shim.SetupSet(mock => mock.MyPropertyByte).Callback((byte v) => Assert.AreEqual(value, v));
        MyChildClass instance = new MyChildClass();
        instance.MyPropertyByte = value;
    }

    [TestMethod]
    public void MyChildClass_MyPropertyLong_Set()
    {
        long value = 42;
        Shim<MyClass> shim = new Shim<MyClass>();
        shim.SetupSet(mock => mock.MyPropertyLong).Callback((long v) => Assert.AreEqual(value, v));
        MyChildClass instance = new MyChildClass();
        instance.MyPropertyLong = value;
    }

    [TestMethod]
    public void MyChildClass_MyPropertyShort_Set()
    {
        short value = 42;
        Shim<MyClass> shim = new Shim<MyClass>();
        shim.SetupSet(mock => mock.MyPropertyShort).Callback((short v) => Assert.AreEqual(value, v));
        MyChildClass instance = new MyChildClass();
        instance.MyPropertyShort = value;
    }

    [TestMethod]
    public void MyChildClass_MySpecialPropertyString_Set()
    {
        string value = "Test";
        Shim<MyClass> shim = new Shim<MyClass>();
        shim.SetupSet(mock => mock.MySpecialPropertyString).Callback((string v) => Assert.AreEqual(value, v));
        MyChildClass instance = new MyChildClass();
        instance.MySpecialPropertyString = value;
    }

    #endregion
}