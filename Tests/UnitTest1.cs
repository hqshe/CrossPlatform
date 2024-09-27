using CrossplatLab;

namespace Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test_MediumInput1()
        {

            int n = 5;
            int k = 3;
            int pos = 10;


            string result = Program.FindSequence(n, k, pos);


            Assert.Equal("cde", result);
        }

        [Fact]
        public void Test_MediumInput2()
        {

            int n = 6;
            int k = 4;
            int pos = 5;


            string result = Program.FindSequence(n, k, pos);


            Assert.Equal("abdf", result);
        }

        [Fact]
        public void Test_LargeInput()
        {

            int n = 10;
            int k = 5;
            int pos = 120;


            string result = Program.FindSequence(n, k, pos);


            Assert.Equal("aegij", result);
        }

        [Fact]
        public void Test_EdgeCase1()
        {

            int n = 3;
            int k = 2;
            int pos = 3;


            string result = Program.FindSequence(n, k, pos);


            Assert.Equal("bc", result);
        }

        [Fact]
        public void Test_EdgeCase2()
        {

            int n = 4;
            int k = 3;
            int pos = 4;


            string result = Program.FindSequence(n, k, pos);


            Assert.Equal("bcd", result);
        }
    }
}