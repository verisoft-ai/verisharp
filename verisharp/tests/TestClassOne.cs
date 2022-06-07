using NUnit.Framework;
namespace Verisoft.Core;

[TestFixture]
public class TestClassOne : NUnitBaseTest
{

    [Test]
    public void Test11() => TestContext.Progress.WriteLine("TestClassOne:Test11");

    [Test]
    public void Test12() => TestContext.Progress.WriteLine("TestClassOne:Test12");

}