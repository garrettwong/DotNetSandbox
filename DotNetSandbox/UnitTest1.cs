namespace DotNetSandbox;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        Assert.False(1 == 2);
    }

    [Fact]
    public void Test2()
    {
        Assert.True(1 == 1);
    }
}
