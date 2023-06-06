namespace CRUDTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            MyMath mm = new MyMath();
            int n = 10;
            int y = 5;
            int e = 15;

            int result = mm.Add(y,n);

            Assert.Equal(e, result);

        }
    }
}