using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Numbers : MonoBehaviour
{
    private string _currentAmount = "0";
    private List<int> _sumOfBoth = new List<int>();
    private readonly string[] _numberRanks = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", };

    public void AddNumbers(string firstNumber, string secondNumber)
    {
        int carryOver = 0;
        int rankSignsCount = 3;
        int signsCounter;
        int minLength = firstNumber.Length < secondNumber.Length ? firstNumber.Length : secondNumber.Length;
        int maxLength = firstNumber.Length > secondNumber.Length ? firstNumber.Length : secondNumber.Length;

        int[] digitsOfFirstNumber = ParseStringToSingleDigits(maxLength, firstNumber);
        int[] digitsOfSecondNumber = ParseStringToSingleDigits(maxLength, secondNumber);
        _sumOfBoth.Clear();

        for (int i = 0; i < maxLength; i++)
        {
            int sum = (digitsOfFirstNumber[i] + digitsOfSecondNumber[i] + carryOver) % 10;
            _sumOfBoth.Add(sum);
            carryOver = digitsOfFirstNumber[i] + digitsOfSecondNumber[i] + carryOver >= 10 ? 1 : 0;

            if(carryOver > 0 && i == maxLength - 1)
                _sumOfBoth.Add(carryOver);
        }

        for (int i = _sumOfBoth.Count - 1; i >= 0; i--)
        {
            _currentAmount += _sumOfBoth[i];
        }
    }

    private int[] ParseStringToSingleDigits(int length, string number)
    {
        int[] digits = new int[length];
        char point = '.';
        char[] numberChars = number.ToCharArray();

        for (int i = 0; i < number.Length; i++)
        {
            foreach (var sign in number)
            {
                foreach (var rank in _numberRanks)
                {
                    

                }
            }
        }
        for (int i = 0; i < numberChars.Length; i++)
        {
            string digit = numberChars[numberChars.Length - 1 - i].ToString();

            if (int.TryParse(digit, out int result))
                digits[i] = result;
        }

        return digits;
    }
}
