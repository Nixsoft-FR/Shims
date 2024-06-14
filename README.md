# Shims

Shims is a .NET project that allows the creation of unit tests for class methods and properties using shims (mocking).

## Features

- Creation of shims for methods
- Unit tests for property getters
- Handling exceptions and callbacks in tests

## Installation

1. Clone the repository:
    ```bash
    git clone https://github.com/Nixsoft-FR/Shims.git
    ```
2. Open the project in your preferred .NET IDE.

## Usage

### Prerequisites

Ensure your unit test classes inherit from `UnitTestBase` to fully leverage shim features:

```csharp
public class MyTestClass : UnitTestBase
{
    // Your test methods here
}
```

### Creating a Shim for a Method

To create a shim for a method in `MyClass`, you can use the `Shim<MyClass>` class:

```csharp
Shim<MyClass> shim = new Shim<MyClass>();
shim.Setup(mock => mock.MyMethod()).Returns("Hello Shim!");

MyClass instance = new MyClass();
string result = instance.MyMethod();

Assert.AreEqual("Hello Shim!", result);
```

### Testing a Property Getter

To test a property getter in `MyClass`, use `Shim<MyClass>` and `SetupGet`:

```csharp
[TestMethod]
public void MyClass_MyPropertyString_Get()
{
    Shim<MyClass> shim = new Shim<MyClass>();
    shim.SetupGet(mock => mock.MyPropertyString).Returns("Test Value");
    MyClass instance = new MyClass();
    Assert.AreEqual("Test Value", instance.MyPropertyString);
}
```

### Handling Exceptions and Callbacks

You can also handle exceptions and callbacks in your tests:

```csharp
[TestMethod]
public void MyClass_MyMethod_ThrowsException()
{
    Shim<MyClass> shim = new Shim<MyClass>();
    shim.Setup(mock => mock.MyMethod()).Throws<ArgumentException>();

    MyClass instance = new MyClass();
    Assert.ThrowsException<ArgumentException>(() => instance.MyMethod());
}

[TestMethod]
public void MyClass_MyMethod_WithCallback()
{
    bool callbackCalled = false;

    Shim<MyClass> shim = new Shim<MyClass>();
    shim.Setup(mock => mock.MyMethod()).Callback(() => callbackCalled = true);

    MyClass instance = new MyClass();
    instance.MyMethod();

    Assert.IsTrue(callbackCalled);
}
```

## Acknowledgments

Special thanks to the [Harmony.Lib](https://github.com/pardeike/Harmony) library for its use in this project. 

We also want to thank the [Moq](https://github.com/moq/moq4) library, which greatly inspired the syntax used in Shims.

## Contribution

Contributions are welcome! Please submit an issue or a pull request for any suggestions or improvements.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE.txt) file for details.