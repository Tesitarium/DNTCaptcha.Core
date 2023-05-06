using System;

namespace DNTCaptcha.Core;

/// <summary>
///     SumOfTwoNumbersToWords Provider
/// </summary>
public class SumOfTwoNumbersToWordsProvider : ICaptchaTextProvider
{
    private readonly IRandomNumberProvider _randomNumberProvider;
    private readonly HumanReadableIntegerProvider _humanReadableIntegerProvider;

    /// <summary>
    ///     SumOfTwoNumbersToWords Provider
    /// </summary>
    public SumOfTwoNumbersToWordsProvider(
        IRandomNumberProvider randomNumberProvider,
        HumanReadableIntegerProvider humanReadableIntegerProvider
    )
    {
        _randomNumberProvider = randomNumberProvider ?? throw new ArgumentNullException(nameof(randomNumberProvider));
        _humanReadableIntegerProvider = humanReadableIntegerProvider;
    }

    /// <summary>
    ///     display a numeric value using the equivalent text
    /// </summary>
    /// <param name="number">input number</param>
    /// <param name="language">local language</param>
    /// <returns>the equivalent text</returns>
    public string GetText(long number, Language language)
    {
        var randomNumber = number > 1 ? _randomNumberProvider.NextNumber(1, (int)Math.Min(number - 1, 9)) : 0;
        return $"{_humanReadableIntegerProvider.NumberToText(number - randomNumber, language)} + {_humanReadableIntegerProvider.NumberToText(randomNumber, language)}";
    }
}