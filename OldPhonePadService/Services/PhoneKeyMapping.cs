using OldPhonePadService.Interfaces;
using System.Text;

namespace OldPhonePadService.Services
{
    public class PhoneKeyMapping : IPhoneKeyMapping
    {
        private readonly Dictionary<char, string> _keyDictionary = new()
        {
            { '1', "&'(" },
            { '2', "ABC" },
            { '3', "DEF" },
            { '4', "GHI" },
            { '5', "JKL" },
            { '6', "MNO" },
            { '7', "PQRS" },
            { '8', "TUV" },
            { '9', "WXYZ" },
            { '0', " " },
            { '*', "" },
            { '#', "" }
        };

        public string ConvertKeyToText(string input)
        {
            if (string.IsNullOrEmpty(input) || input[^1] != '#')
                throw new ArgumentException("Invalid input!");

            StringBuilder result = new StringBuilder();
            char lastKey = '\0';
            int count = 0;

            foreach (var chr in input)
            {
                if (chr == '#')
                    break;

                if (_keyDictionary.ContainsKey(chr))
                {
                    if (chr == lastKey)
                    {
                        count++;
                    }
                    else
                    {
                        if (lastKey != '\0' && count > 0)
                        {
                            result.Append(MapKeys(lastKey, count));
                        }
                        lastKey = chr;
                        count = 1;

                        if (chr == '*')
                        {
                            if (result.Length > 0)
                            {
                                result.Length--;
                                lastKey = '\0';
                                count = 0;
                            }

                        }
                    }
                }
                else if (chr == ' ')
                {
                    if (lastKey != '\0' && count > 0)
                    {
                        result.Append(MapKeys(lastKey, count));
                        lastKey = '\0';
                        count = 0;
                    }
                }
            }

            if (lastKey != '\0' && count > 0)
            {
                result.Append(MapKeys(lastKey, count));
            }

            return result.ToString();
        }

        private char MapKeys(char key, int keyCnt)
        {
            if (string.IsNullOrEmpty(key.ToString()) || !_keyDictionary.ContainsKey(key))
                throw new ArgumentException("Invalid key!");

            if (_keyDictionary[key].Length == 0)
                return '\0';

            var retChar = _keyDictionary[key][(keyCnt - 1) % _keyDictionary[key].Length];

            return retChar;
        }
    }
}
