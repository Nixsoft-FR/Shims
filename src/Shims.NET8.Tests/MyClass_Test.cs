using Shims.TestContext;
using System.Runtime.CompilerServices;

namespace Shims.NET8.Tests;

[TestClass]
public class MyClass_Test : UnitTestBase
{
    #region MyMethodWithReturn

    [TestMethod]
    public void MyClass_MyMethodWithReturn_OK_WithCallback()
    {
        bool callbackCalled = false;

        Shim<MyClass> myClass = new Shim<MyClass>();
        myClass.Setup(x => x.MyMethodWithReturn())
                .Returns("Hello Mock!")
                .Callback(() =>
                {
                    callbackCalled = true;
                });

        MyClass instance = new MyClass();
        string result = instance.MyMethodWithReturn();
        Assert.AreEqual("Hello Mock!", result);
        Assert.IsTrue(callbackCalled);
    }

    [TestMethod]
    public void MyClass_MyMethodWithReturn_OK_WithoutCallback()
    {
        Shim<MyClass> shim = new Shim<MyClass>();
        shim.Setup(x => x.MyMethodWithReturn())
            .Returns("Hello Mock!");

        MyClass instance = new MyClass();
        string result = instance.MyMethodWithReturn();

        Assert.AreEqual("Hello Mock!", result);
    }

    [TestMethod]
    public void MyClass_MyMethodWithReturn_KO_Throws_WithCallback()
    {
        bool callbackCalled = false;

        Shim<MyClass> myClass = new Shim<MyClass>();
        myClass.Setup(x => x.MyMethodWithReturn())
                .Throws<ArgumentException>()
                .Callback(() =>
                {
                    callbackCalled = true;
                });

        MyClass instance = new MyClass();
        Assert.ThrowsException<ArgumentException>(() => instance.MyMethodWithReturn());
        Assert.IsTrue(callbackCalled);
    }

    [TestMethod]
    public void MyClass_MyMethodWithReturn_KO_Throws_WithoutCallback()
    {
        Shim<MyClass> shim = new Shim<MyClass>();
        shim.Setup(x => x.MyMethodWithReturn())
            .Throws<ArgumentException>();

        MyClass instance = new MyClass();
        Assert.ThrowsException<ArgumentException>(() => instance.MyMethodWithReturn());

    }

    [TestMethod]
    public void MyClass_MyMethodWithReturn_KO_ThrowsWithException_WithCallback()
    {
        bool callbackCalled = false;

        Shim<MyClass> myClass = new Shim<MyClass>();
        myClass.Setup(x => x.MyMethodWithReturn())
                .Throws(new ArgumentException("Test"))
                .Callback(() =>
                {
                    callbackCalled = true;
                });

        MyClass instance = new MyClass();
        try
        {
            instance.MyMethodWithReturn();
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Test", ex.Message);
        }
        Assert.IsTrue(callbackCalled);
    }

    [TestMethod]
    public void MyClass_MyMethodWithReturn_KO_ThrowsWithException_WithoutCallback()
    {
        Shim<MyClass> shim = new Shim<MyClass>();
        shim.Setup(x => x.MyMethodWithReturn())
            .Throws(new ArgumentException("Test"));

        MyClass instance = new MyClass();
        try
        {
            instance.MyMethodWithReturn();
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Test", ex.Message);
        }
    }

    [TestMethod]
    public void MyClass_MyMethodWithReturn_KO_ThowsWithDelegate_WithCallback()
    {
        bool callbackCalled = false;

        Shim<MyClass> shim = new Shim<MyClass>();
        Delegate exceptionFunction = () => new ArgumentException("Test");
        shim.Setup(x => x.MyMethodWithReturn())
            .Throws(exceptionFunction)
            .Callback(() =>
            {
                callbackCalled = true;
            });

        MyClass instance = new MyClass();
        try { instance.MyMethodWithReturn(); }
        catch (ArgumentException ex) { Assert.AreEqual("Test", ex.Message); }
        Assert.IsTrue(callbackCalled);
    }

    [TestMethod]
    public void MyClass_MyMethodWithReturn_KO_ThowsWithDelegate_WithoutCallback()
    {
        Shim<MyClass> shim = new Shim<MyClass>();
        Delegate exceptionFunction = () => new ArgumentException(
            "Test");
        shim.Setup(x => x.MyMethodWithReturn())
            .Throws(exceptionFunction);
        MyClass instance = new MyClass();
        try { instance.MyMethodWithReturn(); }
        catch (ArgumentException ex) { Assert.AreEqual("Test", ex.Message); }
    }


    [TestMethod]
    public void MyClass_MyMethodWithReturn_KO_ThowsWithAction_WithCallback()
    {
        bool callbackCalled = false;

        Shim<MyClass> shim = new Shim<MyClass>();
        shim.Setup(x => x.MyMethodWithReturn())
            .Throws(() => new ArgumentException("Test"))
            .Callback(() =>
            {
                callbackCalled = true;
            });

        MyClass instance = new MyClass();
        try { instance.MyMethodWithReturn(); }
        catch (ArgumentException ex) { Assert.AreEqual("Test", ex.Message); }

        Assert.IsTrue(callbackCalled);
    }

    [TestMethod]

    public void MyClass_MyMethodWithReturn_KO_ThowsWithAction_WithoutCallback()
    {
        Shim<MyClass> shim = new Shim<MyClass>();
        shim.Setup(x => x.MyMethodWithReturn())
            .Throws(() => new ArgumentException("Test"));

        MyClass instance = new MyClass();
        try { instance.MyMethodWithReturn(); }
        catch (ArgumentException ex) { Assert.AreEqual("Test", ex.Message); }
    }

    #endregion

    #region MyMethod

    [TestMethod]
    public void MyClass_MyMethod_OK_WithCallback()
    {
        bool callbackCalled = false;

        Shim<MyClass> shim = new Shim<MyClass>();
        shim.Setup(mock => mock.MyMethod())
            .Callback(() =>
            {
                callbackCalled = true;
            });

        MyClass instance = new MyClass();
        instance.MyMethod();
        Assert.IsTrue(callbackCalled);
    }

    [TestMethod]
    public void MyClass_MyMethod_KO_Throws_WithoutCallback()
    {
        Shim<MyClass> shim = new Shim<MyClass>();
        shim.Setup(mock => mock.MyMethod())
            .Throws<ArgumentException>();

        MyClass instance = new MyClass();
        Assert.ThrowsException<ArgumentException>(() => instance.MyMethod());
    }

    [TestMethod]
    public void MyClass_MyMethod_KO_Throws_WithCallback()
    {
        bool callbackCalled = false;

        Shim<MyClass> shim = new Shim<MyClass>();
        shim.Setup(mock => mock.MyMethod())
            .Throws<ArgumentException>()
            .Callback(() =>
            {
                callbackCalled = true;
            });
        MyClass instance = new MyClass();
        Assert.ThrowsException<ArgumentException>(() => instance.MyMethod());
        Assert.IsTrue(callbackCalled);
    }

    [TestMethod]
    public void MyClass_MyMethod_KO_ThrowsWithException_WithoutCallback()
    {
        Shim<MyClass> shim = new Shim<MyClass>();
        shim.Setup(mock => mock.MyMethod())
            .Throws(new ArgumentException("Test"));
        MyClass instance = new MyClass();
        try { 
            instance.MyMethod();
            Assert.Fail("Exception not thrown");
        }
        catch (ArgumentException ex) { Assert.AreEqual("Test", ex.Message); }
    }

    [TestMethod]
    public void MyClass_MyMethod_KO_ThrowsWithException_WithCallback()
    {
        bool callbackCalled = false;

        Shim<MyClass> shim = new Shim<MyClass>();
        shim.Setup(mock => mock.MyMethod())
            .Throws(new ArgumentException("Test"))
            .Callback(() =>
            {
                callbackCalled = true;
            });
        MyClass instance = new MyClass();
        try
        {
            instance.MyMethod();
            Assert.Fail("Exception not thrown");
        }
        catch (ArgumentException ex) { Assert.AreEqual("Test", ex.Message); }
        Assert.IsTrue(callbackCalled);
    }

    [TestMethod]
    public void MyClass_MyMethod_KO_ThowsWithDelegate_WithoutCallback()
    {
        Shim<MyClass> shim = new Shim<MyClass>();
        Delegate exceptionFunction = () => new ArgumentException("Test");
        shim.Setup(mock => mock.MyMethod())
            .Throws(exceptionFunction);
        MyClass instance = new MyClass();
        try
        {
            instance.MyMethod();
            Assert.Fail("Exception not thrown");
        }
        catch (ArgumentException ex) { Assert.AreEqual("Test", ex.Message); }
    }

    [TestMethod]
    public void MyClass_MyMethod_KO_ThowsWithDelegate_WithCallback()
    {
        bool callbackCalled = false;

        Shim<MyClass> shim = new Shim<MyClass>();
        Delegate exceptionFunction = () => new ArgumentException("Test");
        shim.Setup(mock => mock.MyMethod())
            .Throws(exceptionFunction)
            .Callback(() =>
            {
                callbackCalled = true;
            });
        MyClass instance = new MyClass();
        try
        {
            instance.MyMethod();
            Assert.Fail("Exception not thrown");
        }
        catch (ArgumentException ex) { Assert.AreEqual("Test", ex.Message); }
        Assert.IsTrue(callbackCalled);
    }

    [TestMethod]
    public void MyClass_MyMethod_KO_ThowsWithAction_WithoutCallback()
    {
        Shim<MyClass> shim = new
            Shim<MyClass>();
        shim.Setup(mock => mock.MyMethod())
            .Throws(() => new ArgumentException("Test"));
        MyClass instance = new MyClass();
        try
        {
            instance.MyMethod();
            Assert.Fail("Exception not thrown");
        }
        catch (ArgumentException ex) { Assert.AreEqual("Test", ex.Message); }
    }

    [TestMethod]
    public void MyClass_MyMethod_KO_ThowsWithAction_WithCallback()
    {
        bool callbackCalled = false;

        Shim<MyClass> shim = new Shim<MyClass>();
        shim.Setup(mock => mock.MyMethod())
            .Throws(() => new ArgumentException("Test"))
            .Callback(() =>
            {
                callbackCalled = true;
            });
        MyClass instance = new MyClass();

        try
        {
            instance.MyMethod();
            Assert.Fail("Exception not thrown");
        }
        catch (ArgumentException ex) { Assert.AreEqual("Test", ex.Message); }
        Assert.IsTrue(callbackCalled);

    }

    #endregion

    #region MyMethodWithParameter

    [TestMethod]
    public void MyClass_MyMethodWithParameter_OK_WithCallback()
    {
        bool callbackCalled = false;

        Shim<MyClass> shim = new Shim<MyClass>();
        shim.Setup(mock => mock.MyMethodWithParameter("Test"))
            .Callback((string s) =>
            {
                Assert.AreEqual("Test", s);
                callbackCalled = true;
            });

        MyClass instance = new MyClass();
        instance.MyMethodWithParameter("Test");
        Assert.IsTrue(callbackCalled);
    }

    [TestMethod]
    public void MyClass_MyMethodWithParameter_KO_Throws_WithoutCallback()
    {
        Shim<MyClass> shim = new Shim<MyClass>();
        shim.Setup(mock => mock.MyMethodWithParameter("Test"))
            .Throws<ArgumentException>();

        MyClass instance = new MyClass();
        Assert.ThrowsException<ArgumentException>(() => instance.MyMethodWithParameter("Test"));
    }

    [TestMethod]
    public void MyClass_MyMethodWithParameter_KO_Throws_WithCallback()
    {
        bool callbackCalled = false;

        Shim<MyClass> shim = new Shim<MyClass>();
        shim.Setup(mock => mock.MyMethodWithParameter("Test"))
            .Throws<ArgumentException>()
            .Callback((string s) =>
            {
                Assert.AreEqual("Test", s);
                callbackCalled = true;
            });
        MyClass instance = new MyClass();
        Assert.ThrowsException<ArgumentException>(() => instance.MyMethodWithParameter("Test"));
        Assert.IsTrue(callbackCalled);
    }

    [TestMethod]
    public void MyClass_MyMethodWithParameter_KO_ThrowsWithException_WithoutCallback()
    {
        Shim<MyClass> shim = new Shim<MyClass>();
        shim.Setup(mock => mock.MyMethodWithParameter("Test"))
            .Throws(new ArgumentException("Test"));
        MyClass instance = new MyClass();
        try
        {
            instance.MyMethodWithParameter("Test");
            Assert.Fail("Exception not thrown");
        }
        catch (ArgumentException ex) { Assert.AreEqual("Test", ex.Message); }

    }

    [TestMethod]
    public void MyClass_MyMethodWithParameter_KO_ThrowsWithException_WithCallback()
    {
        bool callbackCalled = false;

        Shim<MyClass> shim = new Shim<MyClass>();
        shim.Setup(mock => mock.MyMethodWithParameter("Test"))
            .Throws(new ArgumentException("Test"))
            .Callback((string s) =>
            {
                Assert.AreEqual("Test", s);
                callbackCalled = true;
            });
        MyClass instance = new MyClass();
        try
        {
            instance.MyMethodWithParameter("Test");
            Assert.Fail("Exception not thrown");
        }
        catch (ArgumentException ex) { Assert.AreEqual("Test", ex.Message); }
        Assert.IsTrue(callbackCalled);
    }

    [TestMethod]
    public void MyClass_MyMethodWithParameter_KO_ThowsWithDelegate_WithoutCallback()
    {
        Shim<MyClass> shim = new Shim<MyClass>();
        Delegate exceptionFunction = () => new ArgumentException("Test");
        shim.Setup(mock => mock.MyMethodWithParameter("Test"))
            .Throws(exceptionFunction);
        MyClass instance = new MyClass();
        try
        {
            instance.MyMethodWithParameter("Test");
            Assert.Fail("Exception not thrown");
        }
        catch (ArgumentException ex) { Assert.AreEqual("Test", ex.Message); }
    }

    [TestMethod]
    public void MyClass_MyMethodWithParameter_KO_ThowsWithDelegate_WithCallback()
    {
        bool callbackCalled = false;

        Shim<MyClass> shim = new Shim<MyClass>();
        Delegate exceptionFunction = () => new ArgumentException("Test");
        shim.Setup(mock => mock.MyMethodWithParameter("Test"))
            .Throws(exceptionFunction)
            .Callback((string s) =>
            {
                Assert.AreEqual("Test", s);
                callbackCalled = true;
            });
        MyClass instance = new MyClass();
        try
        {
            instance.MyMethodWithParameter("Test");
            Assert.Fail("Exception not thrown");
        }
        catch (ArgumentException ex) { Assert.AreEqual("Test", ex.Message); }
        Assert.IsTrue(callbackCalled);
    }

    [TestMethod]
    public void MyClass_MyMethodWithParameter_KO_ThowsWithAction_WithoutCallback()
    {
        Shim<MyClass> shim = new Shim<MyClass>();
        shim.Setup(mock => mock.MyMethodWithParameter("Test"))
            .Throws(() => new ArgumentException("Test"));
        MyClass instance = new MyClass();
        try
        {
            instance.MyMethodWithParameter("Test");
            Assert.Fail("Exception not thrown");
        }
        catch (ArgumentException ex) { Assert.AreEqual("Test", ex.Message); }
    }

    [TestMethod]
    public void MyClass_MyMethodWithParameter_KO_ThowsWithAction_WithCallback()
    {
        bool callbackCalled = false;

        Shim<MyClass> shim = new Shim<MyClass>();
        shim.Setup(mock => mock.MyMethodWithParameter("Test"))
            .Throws(() => new ArgumentException("Test"))
            .Callback((string s) =>
            {
                Assert.AreEqual("Test", s);
                callbackCalled = true;
            });
        MyClass instance = new MyClass();
        try
        {
            instance.MyMethodWithParameter("Test");
            Assert.Fail("Exception not thrown");
        }
        catch (ArgumentException ex) { Assert.AreEqual("Test", ex.Message); }
        Assert.IsTrue(callbackCalled);
    }

    #endregion

    #region MyMethodWithParameters

    #region Two parameters

    [TestMethod]
    public void MyClass_MyMethodWithTwoParameters_OK_WithCallback()
    {
        bool callbackCalled = false;

        Shim<MyClass> shim = new Shim<MyClass>();
        shim.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2"))
            .Callback((string s1, string s2) =>
            {
                Assert.AreEqual("Test1", s1);
                Assert.AreEqual("Test2", s2);
                callbackCalled = true;
            });

        MyClass instance = new MyClass();
        instance.MyMethodWithParameters("Test1", "Test2");
        Assert.IsTrue(callbackCalled);
    }

    [TestMethod]
    public void MyClass_MyMethodWithTwoParameters_KO_Throws_WithoutCallback()
    {
        Shim<MyClass> shim = new Shim<MyClass>();
        shim.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2"))
            .Throws<ArgumentException>();

        MyClass instance = new MyClass();
        Assert.ThrowsException<ArgumentException>(() => instance.MyMethodWithParameters("Test1", "Test2"));
    }

    [TestMethod]
    public void MyClass_MyMethodWithTwoParameters_KO_Throws_WithCallback()
    {
        bool callbackCalled = false;

        Shim<MyClass> shim = new Shim<MyClass>();
        shim.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2"))
            .Throws<ArgumentException>()
            .Callback((string s1, string s2) =>
            {
                Assert.AreEqual("Test1", s1);
                Assert.AreEqual("Test2", s2);
                callbackCalled = true;
            });
        MyClass instance = new MyClass();
        Assert.ThrowsException<ArgumentException>(() => instance.MyMethodWithParameters("Test1", "Test2"));
        Assert.IsTrue(callbackCalled);
    }

    [TestMethod]
    public void MyClass_MyMethodWithTwoParameters_KO_ThrowsWithException_WithoutCallback()
    {
        Shim<MyClass> shim = new Shim<MyClass>();
        shim.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2"))
            .Throws(new ArgumentException("Test"));
        MyClass instance = new MyClass();
        try
        {
            instance.MyMethodWithParameters("Test1", "Test2");
            Assert.Fail("Exception not thrown");
        }
        catch (ArgumentException ex) { Assert.AreEqual("Test", ex.Message); }
    }
    [TestMethod]
    public void MyClass_MyMethodWithTwoParameters_KO_ThrowsWithException_WithCallback()
    {
        bool callbackCalled = false;

        Shim<MyClass> shim = new Shim<MyClass>();
        shim.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2"))
            .Throws(new ArgumentException("Test"))
            .Callback((string s1, string s2) =>
            {
                Assert.AreEqual("Test1", s1);
                Assert.AreEqual("Test2", s2);
                callbackCalled = true;
            });
        MyClass instance = new MyClass();
        try
        {
            instance.MyMethodWithParameters("Test1", "Test2");
            Assert.Fail("Exception not thrown");
        }
        catch (ArgumentException ex) { Assert.AreEqual("Test", ex.Message); }
        Assert.IsTrue(callbackCalled);
    }

    [TestMethod]
    public void MyClass_MyMethodWithTwoParameters_KO_ThowsWithDelegate_WithoutCallback()
    {
        Shim<MyClass> shim = new
            Shim<MyClass>();
        Delegate exceptionFunction = () => new ArgumentException("Test");
        shim.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2"))
            .Throws(exceptionFunction);
        MyClass instance = new MyClass();
        try
        {
            instance.MyMethodWithParameters("Test1", "Test2");
            Assert.Fail("Exception not thrown");
        }
        catch (ArgumentException ex) { Assert.AreEqual("Test", ex.Message); }
    }
    [TestMethod]
    public void MyClass_MyMethodWithTwoParameters_KO_ThowsWithDelegate_WithCallback()
    {
        bool callbackCalled = false;

        Shim<MyClass> shim = new Shim<MyClass>();
        Delegate exceptionFunction = () => new ArgumentException("Test");
        shim.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2"))
            .Throws(exceptionFunction)
            .Callback((string s1, string s2) =>
            {
                Assert.AreEqual("Test1", s1);
                Assert.AreEqual("Test2", s2);
                callbackCalled = true;
            });
        MyClass instance = new MyClass();
        try
        {
            instance.MyMethodWithParameters("Test1", "Test2");
            Assert.Fail("Exception not thrown");
        }
        catch (ArgumentException ex) { Assert.AreEqual("Test", ex.Message); }
        Assert.IsTrue(callbackCalled);
    }

    [TestMethod]
    public void MyClass_MyMethodWithTwoParameters_KO_ThowsWithAction_WithoutCallback()
    {
        Shim<MyClass> shim = new
            Shim<MyClass>();
        shim.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2"))
            .Throws(() => new ArgumentException("Test"));
        MyClass instance = new MyClass();
        try
        {
            instance.MyMethodWithParameters("Test1", "Test2");
            Assert.Fail("Exception not thrown");
        }
        catch (ArgumentException ex) { Assert.AreEqual("Test", ex.Message); }
    }

    [TestMethod]
    public void MyClass_MyMethodWithTwoParameters_KO_ThowsWithAction_WithCallback()
    {
        bool callbackCalled = false;

        Shim<MyClass> shim = new Shim<MyClass>();
        shim.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2"))
            .Throws(() => new ArgumentException("Test"))
            .Callback((string s1, string s2) =>
            {
                Assert.AreEqual("Test1", s1);
                Assert.AreEqual("Test2", s2);
                callbackCalled = true;
            });
        MyClass instance = new MyClass();
        try
        {
            instance.MyMethodWithParameters("Test1", "Test2");
            Assert.Fail("Exception not thrown");
        }
        catch (ArgumentException ex) { Assert.AreEqual("Test", ex.Message); }
        Assert.IsTrue(callbackCalled);
    }


    #endregion

    #region Three parameters

    [TestMethod]
    public void MyClass_MyMethodWithThreeParameters_OK_WithCallback()
    {
        bool callbackCalled = false;

        Shim<MyClass> shim = new Shim<MyClass>();
        shim.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2", "Test3"))
            .Callback((string s1, string s2, string s3) =>
            {
                Assert.AreEqual("Test1", s1);
                Assert.AreEqual("Test2", s2);
                Assert.AreEqual("Test3", s3);
                callbackCalled = true;
            });

        MyClass instance = new MyClass();
        instance.MyMethodWithParameters("Test1", "Test2", "Test3");
        Assert.IsTrue(callbackCalled);
    }

    [TestMethod]
    public void MyClass_MyMethodWithThreeParameters_KO_Throws_WithoutCallback()
    {
        Shim<MyClass> shim = new Shim<MyClass>();
        shim.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2", "Test3"))
            .Throws<ArgumentException>();

        MyClass instance = new MyClass();
        Assert.ThrowsException<ArgumentException>(() => instance.MyMethodWithParameters("Test1", "Test2", "Test3"));
    }

    [TestMethod]
    public void MyClass_MyMethodWithThreeParameters_KO_Throws_WithCallback()
    {
        bool callbackCalled = false;

        Shim<MyClass> shim = new Shim<MyClass>();
        shim.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2", "Test3"))
            .Throws<ArgumentException>()
            .Callback((string s1, string s2, string s3) =>
            {
                Assert.AreEqual("Test1", s1);
                Assert.AreEqual("Test2", s2);
                Assert.AreEqual("Test3", s3);
                callbackCalled = true;
            });
        MyClass instance = new MyClass();
        Assert.ThrowsException<ArgumentException>(() => instance.MyMethodWithParameters("Test1", "Test2", "Test3"));
        Assert.IsTrue(callbackCalled);
    }

    [TestMethod]
    public void MyClass_MyMethodWithThreeParameters_KO_ThrowsWithException_WithoutCallback()
    {
        Shim<MyClass> shim = new Shim<MyClass>();
        shim.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2", "Test3"))
            .Throws(new ArgumentException("Test"));
        MyClass instance = new MyClass();
        try
        {
            instance.MyMethodWithParameters("Test1", "Test2", "Test3");
            Assert.Fail("Exception not thrown");
        }
        catch (ArgumentException ex) { Assert.AreEqual("Test", ex.Message); }
    }

    [TestMethod]
    public void MyClass_MyMethodWithThreeParameters_KO_ThrowsWithException_WithCallback()
    {
        bool callbackCalled = false;

        Shim<MyClass> shim = new Shim<MyClass>();
        shim.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2", "Test3"))
            .Throws(new ArgumentException("Test"))
            .Callback((string s1, string s2, string s3) =>
            {
                Assert.AreEqual("Test1", s1);
                Assert.AreEqual("Test2", s2);
                Assert.AreEqual("Test3", s3);
                callbackCalled = true;
            });
        MyClass instance = new MyClass();
        try
        {
            instance.MyMethodWithParameters("Test1", "Test2", "Test3");
            Assert.Fail("Exception not thrown");
        }
        catch (ArgumentException ex) { Assert.AreEqual("Test", ex.Message); }
        Assert.IsTrue(callbackCalled);
    }

    [TestMethod]
    public void MyClass_MyMethodWithThreeParameters_KO_ThowsWithDelegate_WithoutCallback()
    {
        Shim<MyClass> shim = new Shim<MyClass>();
        Delegate exceptionFunction = () => new ArgumentException("Test");
        shim.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2", "Test3"))
                .Throws(exceptionFunction);
        MyClass instance = new MyClass();
        try
        {
            instance.MyMethodWithParameters("Test1", "Test2", "Test3");
            Assert.Fail("Exception not thrown");
        }
        catch (ArgumentException ex) { Assert.AreEqual("Test", ex.Message); }
    }

    [TestMethod]
    public void MyClass_MyMethodWithThreeParameters_KO_ThowsWithDelegate_WithCallback()
    {
        bool callbackCalled = false;

        Shim<MyClass> shim = new Shim<MyClass>();
        Delegate exceptionFunction = () => new ArgumentException("Test");
        shim.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2", "Test3"))
            .Throws(exceptionFunction)
            .Callback((string s1, string s2, string s3) =>
            {
                Assert.AreEqual("Test1", s1);
                Assert.AreEqual("Test2", s2);
                Assert.AreEqual("Test3", s3);
                callbackCalled = true;
            });
        MyClass instance = new MyClass();
        try
        {
            instance.MyMethodWithParameters("Test1", "Test2", "Test3");
            Assert.Fail("Exception not thrown");
        }
        catch (ArgumentException ex) { Assert.AreEqual("Test", ex.Message); }
        Assert.IsTrue(callbackCalled);
    }

    [TestMethod]
    public void MyClass_MyMethodWithThreeParameters_KO_ThowsWithAction_WithoutCallback()
    {
        Shim<MyClass> shim = new Shim<MyClass>();
        shim.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2", "Test3"))
            .Throws(() => new ArgumentException("Test"));
        MyClass instance = new MyClass();
        try
        {
            instance.MyMethodWithParameters("Test1", "Test2", "Test3");
            Assert.Fail("Exception not thrown");
        }
        catch (ArgumentException ex) { Assert.AreEqual("Test", ex.Message); }
    }

    [TestMethod]
    public void MyClass_MyMethodWithThreeParameters_KO_ThowsWithAction_WithCallback()
    {
        bool callbackCalled = false;

        Shim<MyClass> shim = new Shim<MyClass>();
        shim.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2", "Test3"))
            .Throws(() => new ArgumentException("Test"))
            .Callback((string s1, string s2, string s3) =>
            {
                Assert.AreEqual("Test1", s1);
                Assert.AreEqual("Test2", s2);
                Assert.AreEqual("Test3", s3);
                callbackCalled = true;
            });
        MyClass instance = new MyClass();
        try
        {
            instance.MyMethodWithParameters("Test1", "Test2", "Test3");
            Assert.Fail("Exception not thrown");
        }
        catch (ArgumentException ex) { Assert.AreEqual("Test", ex.Message); }
        Assert.IsTrue(callbackCalled);
    }

    #endregion

    #region Four parameters

    [TestMethod]
    public void MyClass_MyMethodWithFourParameters_OK_WithCallback()
    {
        bool callbackCalled = false;

        Shim<MyClass> shim = new Shim<MyClass>();
        shim.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4"))
            .Callback((string s1, string s2, string s3, string s4) =>
            {
                Assert.AreEqual("Test1", s1);
                Assert.AreEqual("Test2", s2);
                Assert.AreEqual("Test3", s3);
                Assert.AreEqual("Test4", s4);
                callbackCalled = true;
            });

        MyClass instance = new MyClass();
        instance.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4");
        Assert.IsTrue(callbackCalled);
    }

    [TestMethod]
    public void MyClass_MyMethodWithFourParameters_KO_Throws_WithoutCallback()
    {
        Shim<MyClass> shim = new Shim<MyClass>();
        shim.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4"))
            .Throws<ArgumentException>();

        MyClass instance = new MyClass();
        Assert.ThrowsException<ArgumentException>(() => instance.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4"));
    }

    [TestMethod]
    public void MyClass_MyMethodWithFourParameters_KO_Throws_WithCallback()
    {
        bool callbackCalled = false;

        Shim<MyClass> shim = new Shim<MyClass>();
        shim.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4"))
            .Throws<ArgumentException>()
            .Callback((string s1, string s2, string s3, string s4) =>
            {
                Assert.AreEqual("Test1", s1);
                Assert.AreEqual("Test2", s2);
                Assert.AreEqual("Test3", s3);
                Assert.AreEqual("Test4", s4);
                callbackCalled = true;
            });
        MyClass instance = new MyClass();
        Assert.ThrowsException<ArgumentException>(() => instance.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4"));
        Assert.IsTrue(callbackCalled);
    }

    [TestMethod]
    public void MyClass_MyMethodWithFourParameters_KO_ThrowsWithException_WithoutCallback()
    {
        Shim<MyClass> shim = new Shim<MyClass>();
        shim.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4"))
            .Throws(new ArgumentException("Test"));
        MyClass instance = new MyClass();
        try
        {
            instance.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4");
            Assert.Fail("Exception not thrown");
        }
        catch (ArgumentException ex) { Assert.AreEqual("Test", ex.Message); }
    }

    [TestMethod]
    public void MyClass_MyMethodWithFourParameters_KO_ThrowsWithException_WithCallback()
    {
        bool callbackCalled = false;

        Shim<MyClass> shim = new Shim<MyClass>();
        shim.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4"))
            .Throws(new ArgumentException("Test"))
            .Callback((string s1, string s2, string s3, string s4) =>
            {
                Assert.AreEqual("Test1", s1);
                Assert.AreEqual("Test2", s2);
                Assert.AreEqual("Test3", s3);
                Assert.AreEqual("Test4", s4);
                callbackCalled = true;
            });
        MyClass instance = new MyClass();
        try
        {
            instance.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4");
            Assert.Fail("Exception not thrown");
        }
        catch (ArgumentException ex) { Assert.AreEqual("Test", ex.Message); }
        Assert.IsTrue(callbackCalled);
    }

    [TestMethod]
    public void MyClass_MyMethodWithFourParameters_KO_ThowsWithDelegate_WithoutCallback()
    {
        Shim<MyClass> shim = new Shim<MyClass>();
        Delegate exceptionFunction = () => new ArgumentException("Test");
        shim.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4"))
            .Throws(exceptionFunction);
        MyClass instance = new MyClass();
        try
        {
            instance.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4");
            Assert.Fail("Exception not thrown");
        }
        catch (ArgumentException ex) { Assert.AreEqual("Test", ex.Message); }
    }

    [TestMethod]
    public void MyClass_MyMethodWithFourParameters_KO_ThowsWithDelegate_WithCallback()
    {
        bool callbackCalled = false;

        Shim<MyClass> shim = new Shim<MyClass>();
        Delegate exceptionFunction = () => new ArgumentException("Test");
        shim.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4"))
            .Throws(exceptionFunction)
            .Callback((string s1, string s2, string s3, string s4) =>
            {
                Assert.AreEqual("Test1", s1);
                Assert.AreEqual("Test2", s2);
                Assert.AreEqual("Test3", s3);
                Assert.AreEqual("Test4", s4);
                callbackCalled = true;
            });
        MyClass instance = new MyClass();
        try
        {
            instance.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4");
            Assert.Fail("Exception not thrown");
        }
        catch (ArgumentException ex) { Assert.AreEqual("Test", ex.Message); }
        Assert.IsTrue(callbackCalled);
    }

    [TestMethod]
    public void MyClass_MyMethodWithFourParameters_KO_ThowsWithAction_WithoutCallback()
    {
        Shim<MyClass> shim = new Shim<MyClass>();
        shim.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4"))
            .Throws(() => new ArgumentException("Test"));
        MyClass instance = new MyClass();
        try
        {
            instance.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4");
            Assert.Fail("Exception not thrown");
        }
        catch (ArgumentException ex) { Assert.AreEqual("Test", ex.Message); }
    }

    [TestMethod]
    public void MyClass_MyMethodWithFourParameters_KO_ThowsWithAction_WithCallback()
    {
        bool callbackCalled = false;

        Shim<MyClass> shim = new Shim<MyClass>();
        shim.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4"))
            .Throws(() => new ArgumentException("Test"))
            .Callback((string s1, string s2, string s3, string s4) =>
            {
                Assert.AreEqual("Test1", s1);
                Assert.AreEqual("Test2", s2);
                Assert.AreEqual("Test3", s3);
                Assert.AreEqual("Test4", s4);
                callbackCalled = true;
            });
        MyClass instance = new MyClass();
        try
        {
            instance.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4");
            Assert.Fail("Exception not thrown");
        }
        catch (ArgumentException ex) { Assert.AreEqual("Test", ex.Message); }
        Assert.IsTrue(callbackCalled);
    }

    #endregion

    #region Five parameters

    [TestMethod]
    public void MyClass_MyMethodWithFiveParameters_OK_WithCallback()
    {
        bool callbackCalled = false;

        Shim<MyClass> shim = new Shim<MyClass>();
        shim.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4", "Test5"))
            .Callback((string s1, string s2, string s3, string s4, string s5) =>
            {
                Assert.AreEqual("Test1", s1);
                Assert.AreEqual("Test2", s2);
                Assert.AreEqual("Test3", s3);
                Assert.AreEqual("Test4", s4);
                Assert.AreEqual("Test5", s5);
                callbackCalled = true;
            });

        MyClass instance = new MyClass();
        instance.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4", "Test5");
        Assert.IsTrue(callbackCalled);
    }

    [TestMethod]
    public void MyClass_MyMethodWithFiveParameters_KO_Throws_WithoutCallback()
    {
        Shim<MyClass> shim = new Shim<MyClass>();
        shim.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4", "Test5"))
            .Throws<ArgumentException>();

        MyClass instance = new MyClass();
        Assert.ThrowsException<ArgumentException>(() => instance.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4", "Test5"));
    }

    [TestMethod]
    public void MyClass_MyMethodWithFiveParameters_KO_Throws_WithCallback()
    {
        bool callbackCalled = false;

        Shim<MyClass> shim = new Shim<MyClass>();
        shim.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4", "Test5"))
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
        MyClass instance = new MyClass();
        Assert.ThrowsException<ArgumentException>(() => instance.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4", "Test5"));
        Assert.IsTrue(callbackCalled);
    }

    [TestMethod]
    public void MyClass_MyMethodWithFiveParameters_KO_ThrowsWithException_WithoutCallback()
    {
        Shim<MyClass> shim = new Shim<MyClass>();
        shim.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4", "Test5"))
            .Throws(new ArgumentException("Test"));
        MyClass instance = new MyClass();
        try
        {
            instance.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4", "Test5");
            Assert.Fail("Exception not thrown");
        }
        catch (ArgumentException ex) { Assert.AreEqual("Test", ex.Message); }
    }

    [TestMethod]
    public void MyClass_MyMethodWithFiveParameters_KO_ThrowsWithException_WithCallback()
    {
        bool callbackCalled = false;

        Shim<MyClass> shim = new Shim<MyClass>();
        shim.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4", "Test5"))
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
        MyClass instance = new MyClass();
        try
        {
            instance.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4", "Test5");
            Assert.Fail("Exception not thrown");
        }
        catch (ArgumentException ex) { Assert.AreEqual("Test", ex.Message); }
        Assert.IsTrue(callbackCalled);
    }

    [TestMethod]
    public void MyClass_MyMethodWithFiveParameters_KO_ThowsWithDelegate_WithoutCallback()
    {
        Shim<MyClass> shim = new Shim<MyClass>();
        Delegate exceptionFunction = () => new ArgumentException("Test");
        shim.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4", "Test5"))
            .Throws(exceptionFunction);
        MyClass instance = new MyClass();
        try
        {
            instance.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4", "Test5");
            Assert.Fail("Exception not thrown");
        }
        catch (ArgumentException ex) { Assert.AreEqual("Test", ex.Message); }
    }

    [TestMethod]
    public void MyClass_MyMethodWithFiveParameters_KO_ThowsWithDelegate_WithCallback()
    {
        bool callbackCalled = false;

        Shim<MyClass> shim = new Shim<MyClass>();
        Delegate exceptionFunction = () => new ArgumentException("Test");
        shim.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4", "Test5"))
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
        MyClass instance = new MyClass();
        try
        {
            instance.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4", "Test5");
            Assert.Fail("Exception not thrown");
        }
        catch (ArgumentException ex) { Assert.AreEqual("Test", ex.Message); }
        Assert.IsTrue(callbackCalled);
    }

    [TestMethod]
    public void MyClass_MyMethodWithFiveParameters_KO_ThowsWithAction_WithoutCallback()
    {
        Shim<MyClass> shim = new Shim<MyClass>();
        shim.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4", "Test5"))
            .Throws(() => new ArgumentException("Test"));
        MyClass instance = new MyClass();
        try
        {
            instance.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4", "Test5");
            Assert.Fail("Exception not thrown");
        }
        catch (ArgumentException ex) { Assert.AreEqual("Test", ex.Message); }
    }

    [TestMethod]
    public void MyClass_MyMethodWithFiveParameters_KO_ThowsWithAction_WithCallback()
    {
        bool callbackCalled = false;

        Shim<MyClass> shim = new Shim<MyClass>();
        shim.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4", "Test5"))
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
        MyClass instance = new MyClass();
        try
        {
            instance.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4", "Test5");
            Assert.Fail("Exception not thrown");
        }
        catch (ArgumentException ex) { Assert.AreEqual("Test", ex.Message); }
        Assert.IsTrue(callbackCalled);
    }

    #endregion

    #region Six parameters

    [TestMethod]
    public void MyClass_MyMethodWithSixParameters_OK_WithCallback()
    {
        bool callbackCalled = false;

        Shim<MyClass> shim = new Shim<MyClass>();
        shim.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4", "Test5", "Test6"))
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

        MyClass instance = new MyClass();
        instance.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4", "Test5", "Test6");
        Assert.IsTrue(callbackCalled);
    }

    [TestMethod]
    public void MyClass_MyMethodWithSixParameters_KO_Throws_WithoutCallback()
    {
        Shim<MyClass> shim = new Shim<MyClass>();
        shim.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4", "Test5", "Test6"))
            .Throws<ArgumentException>();

        MyClass instance = new MyClass();
        Assert.ThrowsException<ArgumentException>(() => instance.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4", "Test5", "Test6"));
    }

    [TestMethod]
    public void MyClass_MyMethodWithSixParameters_KO_Throws_WithCallback()
    {
        bool callbackCalled = false;

        Shim<MyClass> shim = new Shim<MyClass>();
        shim.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4", "Test5", "Test6"))
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
        MyClass instance = new MyClass();
        Assert.ThrowsException<ArgumentException>(() => instance.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4", "Test5", "Test6"));
        Assert.IsTrue(callbackCalled);
    }

    [TestMethod]
    public void MyClass_MyMethodWithSixParameters_KO_ThrowsWithException_WithoutCallback()
    {
        Shim<MyClass> shim = new Shim<MyClass>();
        shim.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4", "Test5", "Test6"))
            .Throws(new ArgumentException("Test"));
        MyClass instance = new MyClass();
        try
        {
            instance.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4", "Test5", "Test6");
            Assert.Fail("Exception not thrown");
        }
        catch (ArgumentException ex) { Assert.AreEqual("Test", ex.Message); }
    }

    [TestMethod]
    public void MyClass_MyMethodWithSixParameters_KO_ThrowsWithException_WithCallback()
    {
        bool callbackCalled = false;

        Shim<MyClass> shim = new Shim<MyClass>();
        shim.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4", "Test5", "Test6"))
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
        MyClass instance = new MyClass();
        try
        {
            instance.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4", "Test5", "Test6");
            Assert.Fail("Exception not thrown");
        }
        catch (ArgumentException ex) { Assert.AreEqual("Test", ex.Message); }
        Assert.IsTrue(callbackCalled);
    }

    [TestMethod]
    public void MyClass_MyMethodWithSixParameters_KO_ThowsWithDelegate_WithoutCallback()
    {
        Shim<MyClass> shim = new Shim<MyClass>();
        Delegate exceptionFunction = () => new ArgumentException("Test");
        shim.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4", "Test5", "Test6"))
            .Throws(exceptionFunction);
        MyClass instance = new MyClass();
        try
        {
            instance.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4", "Test5", "Test6");
            Assert.Fail("Exception not thrown");
        }
        catch (ArgumentException ex) { Assert.AreEqual("Test", ex.Message); }
    }

    [TestMethod]
    public void MyClass_MyMethodWithSixParameters_KO_ThowsWithDelegate_WithCallback()
    {
        bool callbackCalled = false;

        Shim<MyClass> shim = new Shim<MyClass>();
        Delegate exceptionFunction = () => new ArgumentException("Test");
        shim.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4", "Test5", "Test6"))
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
        MyClass instance = new MyClass();
        try
        {
            instance.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4", "Test5", "Test6");
            Assert.Fail("Exception not thrown");
        }
        catch (ArgumentException ex) { Assert.AreEqual("Test", ex.Message); }
        Assert.IsTrue(callbackCalled);
    }

    [TestMethod]
    public void MyClass_MyMethodWithSixParameters_KO_ThowsWithAction_WithoutCallback()
    {
        Shim<MyClass> shim = new Shim<MyClass>();
        shim.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4", "Test5", "Test6"))
            .Throws(() => new ArgumentException("Test"));
        MyClass instance = new MyClass();
        try
        {
            instance.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4", "Test5", "Test6");
            Assert.Fail("Exception not thrown");
        }
        catch (ArgumentException ex) { Assert.AreEqual("Test", ex.Message); }
    }

    [TestMethod]
    public void MyClass_MyMethodWithSixParameters_KO_ThowsWithAction_WithCallback()
    {
        bool callbackCalled = false;

        Shim<MyClass> shim = new Shim<MyClass>();
        shim.Setup(mock => mock.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4", "Test5", "Test6"))
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
        MyClass instance = new MyClass();
        try
        {
            instance.MyMethodWithParameters("Test1", "Test2", "Test3", "Test4", "Test5", "Test6");
            Assert.Fail("Exception not thrown");
        }
        catch (ArgumentException ex) { Assert.AreEqual("Test", ex.Message); }
        Assert.IsTrue(callbackCalled);
    }

    #endregion

    #endregion

    #region MyProperty Get

    [TestMethod]
    public void MyClass_MyPropertyString_Get()
    {
        Shim<MyClass> shim = new Shim<MyClass>();
        shim.SetupGet(mock => mock.MyPropertyString).Returns("Test");
        MyClass instance = new MyClass();
        Assert.AreEqual("Test", instance.MyPropertyString);
    }

    [TestMethod]
    public void MyClass_MyPropertyInt_Get()
    {
        Shim<MyClass> shim = new Shim<MyClass>();
        shim.SetupGet(mock => mock.MyPropertyInt).Returns(42);
        MyClass instance = new MyClass();
        Assert.AreEqual(42, instance.MyPropertyInt);
    }

    [TestMethod]
    public void MyClass_MyPropertyBool_Get()
    {
        Shim<MyClass> shim = new Shim<MyClass>();
        shim.SetupGet(mock => mock.MyPropertyBool).Returns(true);
        MyClass instance = new MyClass();
        Assert.IsTrue(instance.MyPropertyBool);
    }

    [TestMethod]
    public void MyClass_MyPropertyDouble_Get()
    {
        Shim<MyClass> shim = new Shim<MyClass>();
        shim.SetupGet(mock => mock.MyPropertyDouble).Returns(42.42);
        MyClass instance = new MyClass();
        Assert.AreEqual(42.42, instance.MyPropertyDouble);
    }

    [TestMethod]
    public void MyClass_MyPropertyFloat_Get()
    {
        Shim<MyClass> shim = new Shim<MyClass>();
        shim.SetupGet(mock => mock.MyPropertyFloat).Returns(42.42f);
        MyClass instance = new MyClass();
        Assert.AreEqual(42.42f, instance.MyPropertyFloat);
    }

    [TestMethod]
    public void MyClass_MyPropertyDecimal_Get()
    {
        Shim<MyClass> shim = new Shim<MyClass>();
        shim.SetupGet(mock => mock.MyPropertyDecimal).Returns(42.42m);
        MyClass instance = new MyClass();
        Assert.AreEqual(42.42m, instance.MyPropertyDecimal);
    }

    [TestMethod]
    public void MyClass_MyPropertyDateTime_Get()
    {
        DateTime dateTime = DateTime.Now;
        Shim<MyClass> shim = new Shim<MyClass>();
        shim.SetupGet(mock => mock.MyPropertyDateTime).Returns(dateTime);
        MyClass instance = new MyClass();
        Assert.AreEqual(dateTime, instance.MyPropertyDateTime);
    }

    [TestMethod]
    public void MyClass_MyPropertyGuid_Get()
    {
        Guid guid = Guid.NewGuid();
        Shim<MyClass> shim = new Shim<MyClass>();
        shim.SetupGet(mock => mock.MyPropertyGuid).Returns(guid);
        MyClass instance = new MyClass();
        Assert.AreEqual(guid, instance.MyPropertyGuid);
    }

    [TestMethod]
    public void MyClass_MyPropertyChar_Get()
    {
        Shim<MyClass> shim = new Shim<MyClass>();
        shim.SetupGet(mock => mock.MyPropertyChar).Returns('c');
        MyClass instance = new MyClass();
        Assert.AreEqual('c', instance.MyPropertyChar);
    }

    [TestMethod]
    public void MyClass_MyPropertyByte_Get()
    {
        Shim<MyClass> shim = new Shim<MyClass>();
        shim.SetupGet(mock => mock.MyPropertyByte).Returns(42);
        MyClass instance = new MyClass();
        Assert.AreEqual(42, instance.MyPropertyByte);
    }

    [TestMethod]
    public void MyClass_MyPropertyLong_Get()
    {
        Shim<MyClass> shim = new Shim<MyClass>();
        shim.SetupGet(mock => mock.MyPropertyLong).Returns(42);
        MyClass instance = new MyClass();
        Assert.AreEqual(42, instance.MyPropertyLong);
    }

    [TestMethod]
    public void MyClass_MyPropertyShort_Get()
    {
        Shim<MyClass> shim = new Shim<MyClass>();
        shim.SetupGet(mock => mock.MyPropertyShort).Returns(42);
        MyClass instance = new MyClass();
        Assert.AreEqual(42, instance.MyPropertyShort);
    }


    #endregion
}