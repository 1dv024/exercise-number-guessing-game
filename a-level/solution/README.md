# Lösning nivå A

Studera förslaget på lösning i källkodsfilen **SecretNumber.cs**! När du hämtar hem denna fil ska den läggas i samma projektmapp som ```Program.cs```. Filen måste därefter logiskt kopplas till projektet ```NumberGuessingGameA```. Detta gör du genom att i vyn "Solution Explorer" högerklicka på projektnamnet och i dropdown-listan välja menykommandot **Add ► Existing Item...** samt i browser-dialogen leta upp den aktuella filen.

```c#
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
```


