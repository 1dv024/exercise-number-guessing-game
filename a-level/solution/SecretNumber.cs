using System;

namespace _NumberGuessingGameA
{
    public class SecretNumber
    {
        public const int MaxNumberOfGuesses = 7;

        private int _count;
        private int _number;

        public SecretNumber()
        {
            Initialize();
        }

        public void Initialize()
        {
            _count = 0;

            Random random = new Random();
            _number = random.Next(1, 101);
        }

        public bool MakeGuess(int number)
        {
            if (_count >= MaxNumberOfGuesses)
            {
                throw new ApplicationException("Det går inte att gissa fler än sju gånger!");
            }

            if (number < 1 || number > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(number), number,
                    "Det gisssade talet är inte ett värde i det slutna intervallet mellan 1 och 100.");
            }

            ++_count;

            if (number == _number)
            {
                Console.WriteLine("RÄTT GISSAT. Du klarade det på {0} försök.", _count);
                return true;
            }

            Console.WriteLine("{0} är för {1}. Du har {2} gissningar kvar.",
                number, number < _number ? "lågt" : "högt", MaxNumberOfGuesses - _count);

            if (_count == MaxNumberOfGuesses)
            {
                Console.WriteLine("Det hemliga talet är {0}.", _number);
            }

            return false;
        }
    }
}
