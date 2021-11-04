using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayGameApp
{
    public class Play
    {
        private static Random random = new Random();
        private GuessChecker guessChecker;
        private List<GuessModel> guessModels = new List<GuessModel>();
        public Play() : this(GenerateSecretCode()) { }

        public Play(string secretCode)
        {
            SecretCode = secretCode;
            guessChecker = new GuessChecker(SecretCode);
        }
        private static string GenerateSecretCode(int length = 4)
        {
            var builder = new StringBuilder(length);
            for (var j = 0; j < length; j++)
                builder.Append(random.Next(1, 6));
            return builder.ToString();
        }
        public string SecretCode { get; set; }
        public bool IsCompleted { get; private set; }
        public string GuessSecretCode(string guessCode)
        {
            var guessModel = new GuessModel
            {
                ChancesCompleted = guessModels.Count + 1,
                GuessCode = guessCode,
                Response = guessChecker.Check(guessCode)
            };
            guessModels.Add(guessModel);

            if (guessModel.Response == "++++")
            {
                IsCompleted = true;
                return $"Congratulations, you have won!\n(in only {guessModel.ChancesCompleted} attempts)";
            }

            if (guessModel.ChancesCompleted > 9)
            {
                IsCompleted = true;
                return $"Sorry, you lose.\n(the secret code was \"{SecretCode}\")";
            }

            return guessModel.Response;
        }
    }
}
