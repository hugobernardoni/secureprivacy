using BinaryStringAnalyzer;
using Xunit;

namespace Test
{
    public class BinaryStringAnalyzerTests
    {
        [Theory]
        [InlineData("1100", true)]     
        [InlineData("1010", true)]     
        [InlineData("000111", false)]   
        [InlineData("110011", false)]    
        [InlineData("0101", false)]     
        [InlineData("1111", false)]    
        [InlineData("0000", false)]     
        [InlineData("", true)]          
        public void TestIsGoodBinaryString(string binaryString, bool expectedResult)
        {
            bool actualResult = BinaryStringAnalyzer.BinaryStringAnalyzer.IsGoodBinaryString(binaryString);

            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData("111000", true)]      
        [InlineData("11111100", false)]     
        [InlineData("00000011", false)]    
        [InlineData("11110000", true)]     
        [InlineData("110100001", false)]    
        [InlineData("00111000", false)]     
        [InlineData("11111111111111110000", false)] 
        [InlineData("111111000000000000", false)]   
        public void TestIsGoodBinaryStringComplexCases(string binaryString, bool expectedResult)
        {
            bool actualResult = BinaryStringAnalyzer.BinaryStringAnalyzer.IsGoodBinaryString(binaryString);

            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData("0", false)]  
        [InlineData("1", false)] 
        public void TestIsGoodBinaryStringSingleCharacter(string binaryString, bool expectedResult)
        {
            bool actualResult = BinaryStringAnalyzer.BinaryStringAnalyzer.IsGoodBinaryString(binaryString);

            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData("test", false)]
        [InlineData("01test", false)]
        public void TestIsGoodBinaryStringWhithoutZeroOrOneCharacter(string binaryString, bool expectedResult)
        {
            bool actualResult = BinaryStringAnalyzer.BinaryStringAnalyzer.IsGoodBinaryString(binaryString);

            Assert.Equal(expectedResult, actualResult);
        }
    }
}
