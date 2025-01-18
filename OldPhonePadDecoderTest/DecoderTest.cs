using OldPhonePadDecoder;

namespace OldPhonePadDecoderTest
{
    public class DecoderTest
    {
        [Fact]
        public void Test_Return_E()
        {
            var result = PadDecoder.OldPhonePad("33#");
            Assert.Equal("E", result);
        }

        [Fact]
        public void Test_Return_B()
        {
            var result = PadDecoder.OldPhonePad("227*#");
            Assert.Equal("B", result);
        }

        [Fact]
        public void Test_Return_Hello()
        {
            var result = PadDecoder.OldPhonePad("4433555 555666#");
            Assert.Equal("HELLO", result);
        }

        [Fact]
        public void Test_Return_Turing()
        {
            var result = PadDecoder.OldPhonePad("8 88777444666*664#");
            Assert.Equal("TURING", result);
        }
    }
}