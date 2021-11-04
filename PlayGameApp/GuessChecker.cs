using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayGameApp
{
    public class GuessChecker
    {
        private readonly string _secretCode;

        public GuessChecker(string secretCode)
        {
            _secretCode = secretCode;
        }
        //a minus (-) sign should be appended for every digit that is correct but in the wrong position
        //a plus (+) sign should be appended for every digit that is both correct and in the correct position
        //a space ( ) should be appended for incorrect digits ,since nothing should be printed

        public string Check(string guessNumber)
        {
            var builder = new StringBuilder(guessNumber.Length);

            for (var i = 0; i < guessNumber.Length; i++)
            {
                var digit = guessNumber[i];
                var res = ' ';

                if (_secretCode.Contains(digit))
                    res = _secretCode[i] == digit
                        ? '+'
                        : '-';

                builder.Append(res);
            }
            return builder.ToString();
        }
    }
}
