main();

void main()
{
    Console.Clear();

    int strMaxLength = 3;

    string[] strArray = new string[ReadInt("number of strings in the array")];

    for (int i = 0; i < strArray.Length; i++)
    {
        System.Console.Write($"Enter string {i}: ");
        strArray[i] = Console.ReadLine();
    }

    System.Console.WriteLine();

    string[] shortStrArray = GetShortStrings(strArray, strMaxLength);

    if (shortStrArray.Length > 0)
        System.Console.WriteLine($"Array with strings shorter than or equal to {strMaxLength} symbols:"
                                + Environment.NewLine 
                                + ArrayToString(shortStrArray, ", ", true));
    else
        System.Console.WriteLine($"There are no strings with the length less than or equal to {strMaxLength} in the array.");

}

/// <summary>
/// Selects elements of strArray whose length is less than or equal to strMaxLength 
/// </summary>
/// <param name="strArray">Array for search</param>
/// <param name="strMaxLength">Maximum length of the element to be selected</param>
/// <returns>New array of stirngs</returns>
string[] GetShortStrings(string[] strArray, int strMaxLength)
{
    int[] indexArrary = new int[strArray.Length];
    int count = 0;

    for (int i = 0; i < strArray.Length; i++)
        if (strArray[i].Length <= strMaxLength)
        {
            indexArrary[count] = i;
            count++;
        }

    string[] resArray = new string[count];

    for (int i = 0; i < count; i++)
        resArray[i] = strArray[indexArrary[i]];

    return resArray;
}

#region Auxiliary methods

/// <summary>
/// Requests the user to enter an integer number. Repeats until the correct number is entered. 
/// </summary>
/// <param name="argument">Text to be shown in the request</param>
/// <returns>Entered integer number</returns>
int ReadInt(string argument)
{
    int parsedNum = 0,
        inputFieldX = 0,
        inputFieldY = 0;

    System.Console.Write($"Enter {argument}: ");
    inputFieldX = Console.CursorLeft;
    inputFieldY = Console.CursorTop;
    while (!int.TryParse(Console.ReadLine(), out parsedNum))
    {
        Console.SetCursorPosition(0, inputFieldY);
        ClearLine();
        System.Console.WriteLine($"Enter {argument}: ");
        System.Console.WriteLine("Input error. This is not an integer number. Try again...");
        Console.SetCursorPosition(inputFieldX, inputFieldY);
    }

    ClearLine();
    
    return parsedNum;
}

/// <summary>
/// Cleans console's line by filling the whole line with spaces
/// </summary>
/// <param name="lineShift">Relative position of the line to be cleaned (0 - current line)</param>
/// <param name="keepCursor">If true keeps cursor position at the same place, if false - places cursor at the begginig of the cleaned line</param>
void ClearLine(int lineShift = 0, bool keepCursor = true)
{
    int currentTop = Console.CursorTop,
        currentLeft = Console.CursorLeft;
    
    Console.SetCursorPosition(0, currentTop + lineShift);
    Console.Write(new string(' ', Console.WindowWidth));

    if (keepCursor)
        Console.SetCursorPosition(currentLeft, currentTop);
    else
        Console.SetCursorPosition(0, currentTop + lineShift);
}

/// <summary>
/// Combines all the elements of the Array into a new string
/// </summary>
/// <typeparam name="T">Type of the Array's elements</typeparam>
/// <param name="array">Array</param>
/// <param name="separator">Symbol or string to separate the array's elements</param>
/// <param name="withBracketsAndQuotes">If true the brackets [] are shown and each element is surrounded by the quotes ""</param>
/// <returns>Strign containing all the elements of the Array formated according to the parameters</returns>
string ArrayToString<T>(T[] array, string separator = " ", bool withBracketsAndQuotes = false)
{
    string result = (withBracketsAndQuotes ? "[" : string.Empty);

    for (int i = 0; i < array.Length - 1; i++)
        result += (withBracketsAndQuotes ? "\"" : "") + array[i] + (withBracketsAndQuotes ? "\"" : "") + separator;

    result += (withBracketsAndQuotes ? "\"" : "") + array[array.Length - 1] + (withBracketsAndQuotes ? "\"]" : "") + Environment.NewLine;

    return result;
}

#endregion