# Lösning nivå B

Studera förslaget på lösning i källkodsfilen **SecretNumber.cs**! När du hämtar hem denna fil ska den läggas i samma projektmapp som ```Program.cs```. Filen måste därefter logiskt kopplas till projektet ```NumberGuessingGameB```. Detta gör du genom att i vyn "Solution Explorer" högerklicka på projektnamnet och i dropdown-listan välja menykommandot **Add ► Existing Item...** samt i browser-dialogen leta upp den aktuella filen.

```c#
using System;
using System.Linq;

namespace _NumberGuessingGameB
{
    public class SecretNumber
    {
        public const int MaxNumberOfGuesses = 7;

        private int _number;
        private readonly int[] _guessedNumbers;

        public bool CanMakeGuess { get; private set; }

        public int Count { get; private set; }

        public int GuessesLeft
        {
            get { return MaxNumberOfGuesses - Count; }
        }

        // Alternative "Expression bodied method":
        //public int GuessesLeft => MaxNumberOfGuesses - Count;

        public SecretNumber()
        {
            _guessedNumbers = new int[MaxNumberOfGuesses];
            Initialize();
        }

        public void Initialize()
        {
            CanMakeGuess = true;
            Count = 0;
            Array.Clear(_guessedNumbers, 0, _guessedNumbers.Length);

            Random random = new Random();
            _number = random.Next(1, 101);
        }

        public bool MakeGuess(int number)
        {
            if (!CanMakeGuess)
            {
                throw new ApplicationException("Det går inte att gissa.");
            }

            if (number < 1 || number > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(number), number,
                    "Det gisssade talet är inte ett värde i det slutna intervallet mellan 1 och 100.");
            }

            for (int i = 0; i < _guessedNumbers.Length; i++)
            {
                if (number == _guessedNumbers[i])
                {
                    Console.WriteLine("Du har redan gissat på {0}. Gör om gissningen!", number);
                    return false;
                }
            }
            // Alternative LINQ expression:
            //if (_guessedNumbers.Any(t => number == t))
            //{
            //    Console.WriteLine("Du har redan gissat på {0}. Gör om gissningen!", number);
            //    return false;
            //}

            _guessedNumbers[Count++] = number;

            if (number == _number)
            {
                CanMakeGuess = false;
                Console.WriteLine("RÄTT GISSAT. Du klarade det på {0} försök.", Count);
                return true;
            }

            Console.WriteLine("{0} är för {1}. Du har {2} gissningar kvar.",
                number, number < _number ? "lågt" : "högt", GuessesLeft);

            if (Count == MaxNumberOfGuesses)
            {
                CanMakeGuess = false;
                Console.WriteLine("Det hemliga talet är {0}.", _number);
            }

            return false;
        }
    }
}
```


