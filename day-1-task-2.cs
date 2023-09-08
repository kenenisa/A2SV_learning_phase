using System;
using System.Collections.Generic;

public class StringManipulator
{
    public static Dictionary<string, int> FreqCounter(string str)
    {
        Dictionary<string, int> strDict = new Dictionary<string, int>();
        string[] words = str.ToLower().Split(" ");
        foreach (string word in words)
        {
            if (strDict.ContainsKey(word))
            {
                strDict[word] += 1;
            }
            else
            {
                strDict[word] = 1;
            }
        }
        return strDict;
    }
    public static void Main()
    {
        foreach (KeyValuePair<string, int> kvp in FreqCounter("You for runner is running up north these days. This town is where i'd rather you be"))
        {
            Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
        }
    }
}

// test

using Microsoft.VisualStudio.TestTools.UnitTesting;
using UtilityLibraries;

namespace StringLibraryTest;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestWordCount()
    {
        // Tests that we expect to return true.
        string[] words = { "you're", "the", "test", "that", "wants", "to" };
        string[] values = { 1, 1, 2, 1, 1, 1 };
        int testCases = 6;
        Dictionary<string, int> freqValues = FreqCounter("You're the test that Wants to test");
        for (int i = 0; i < testCases; i++)
        {
            Assert.IsTrue(freqValues[words[i]] == values[i],
                   string.Format("Expected for word count '{0}' to be {1}, but got {2}",
                                 words[i], values[i], freqValues[words[i]]));
        }
    }
}
}