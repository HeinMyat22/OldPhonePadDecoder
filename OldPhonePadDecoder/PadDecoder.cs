using OldPhonePadService.Interfaces;
using OldPhonePadService.Services;

namespace OldPhonePadDecoder
{
    public static class PadDecoder
    {
        private static IPhoneKeyMapping _keyMap = new PhoneKeyMapping();

        public static string OldPhonePad(string input)
        {
            try
            {
                var result = _keyMap.ConvertKeyToText(input);
                return result;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
