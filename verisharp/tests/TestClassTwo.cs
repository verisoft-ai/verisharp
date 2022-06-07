using NUnit.Framework;
namespace Verisoft.Core;

[TestFixture]
public class TestClassTwo : NUnitBaseTest
{

    [Test]
    public void Test21() => TestContext.Progress.WriteLine("TestClassTwo:Test21");

    [Test]
    public void Test22() => TestContext.Progress.WriteLine("TestClassTwo:Test22");

}