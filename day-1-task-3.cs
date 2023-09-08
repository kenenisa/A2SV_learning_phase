using System.Text.RegularExpressions;
using System;
using System.Collections.Generic;

public class StringManipulator
{
    public static bool IsPalindrome(string str)
    {
        int n = str.Length;

        // handle empty string
        if (n == 0) return false;

        //ignore non-alphanumeric characters
        Regex allowed = new Regex("[^a-z0-9]");
        str = str.ToLower();
        str = allowed.Replace(str, "");

        // two pointer approach O(n)
        int left = 0;
        int right = n - 1;
        while (left < right)
        {
            //check for anomaly
            if (str[left] != str[right])
            {
                return false;
            }
            left++;
            right--;
        }
        return true;
    }
    public static void Main()
    {

        Console.WriteLine(IsPalindrome("abebe"));
        Console.WriteLine(IsPalindrome("aaaa"));
    }
}

////test

using Microsoft.VisualStudio.TestTools.UnitTesting;
using UtilityLibraries;

namespace StringManipulatorTest;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestWordCount()
    {
        // Tests that we expect to return true.
        string[] words = { "abebe", "lalal", "aaaa" };
        string[] values = { false, true, true };
        int testCases = 3;

        for (int i = 0; i < testCases; i++)
        {
            bool result = StringManipulator.IsPalindrome(words[i]);
            Assert.IsTrue(result == values[i],
                   string.Format("Palindrome expected word '{0}' to be {1}, but got {2}",
                                 words[i], values[i], result));
        }
    }
}
