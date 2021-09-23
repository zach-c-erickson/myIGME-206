using System;

namespace NumberSort
{

    // Class: Program
    // Authors: David Schuh, Zachary Erickson
    // Purpose: Unit Test 1 Question 2
    // Restrictions: None
    class Program
    {
        // the definition of the delegate function data type
        delegate string sortingFunction(string[] a);


        // Method: Main
        // Pupose: Prompt user for number and difficulty of math questions
        //         and create a math quiz for them
        // Restrictions: None

        static void Main(string[] args)
        {
            // declare the unsorted and sorted arrays
            string[] aUnsorted;
            string[] aSorted;

        // declare the delegate variable which will point to the function to be called
        sortingFunction findHiLow;         

        // a label to allow us to easily loop back to the start if there are input issues
        start:
            Console.WriteLine("Enter a sentence");

            // read the space-separated string of numbers
            string sentence = Console.ReadLine();

            // split the string into the an array of strings which are the individual numbers
            string[] sentenceArray = sentence.Split(' ');

            // initialize the size of the unsorted array to 0
            int nUnsortedLength = 0;



            // iterate through the array of strings
            foreach (string word in sentenceArray)
            {
                // if the length of this string is 0 (ie. they typed 2 spaces in a row)
                if (word.Length == 0)
                {
                    // skip it
                    continue;
                }

                // check to see if the sentence included an integer
                if (Int32.TryParse(word, out int result) == true)
                {
                    Console.WriteLine("Please do not include integers in the sentence");
                    goto start;
                }

                // increment array length
                ++nUnsortedLength;

            }

            // now we know how many unsorted strings there are
            // allocate the size of the unsorted array
            aUnsorted = new string[nUnsortedLength];

            // reset nUnsortedLength back to 0 to use as the index to store the strings in the unsorted array
            nUnsortedLength = 0;
            foreach (string word in sentenceArray)
            {
                // set word to be returned
                string newWord = null;

                // still skip the blank strings
                if (word.Length == 0)
                {
                    continue;
                }

                // if the last character in the word is punctuation, change
                // the word so there is no punctuation
                if(Char.IsPunctuation(word, word.Length - 1))
                {
                    newWord = word.Substring(0,word.Length-1);
                }

                // otherwise, keep the word as is
                else
                {
                    newWord = word;
                }


                // store the value into the array
                aUnsorted[nUnsortedLength] = newWord;

                // increment the array index
                nUnsortedLength++;
            }

            // allocate the size of the sorted array
            aSorted = new string[nUnsortedLength];

            // prompt for <a>scending or <d>escending
            Console.Write("Ascending or Descending? ");
            string sDirection = Console.ReadLine();

            if (sDirection.ToLower().StartsWith("a"))
            {
                findHiLow = new sortingFunction(FindLowestValue);
            }
            else
            {
                findHiLow = new sortingFunction(FindHighestValue);
            }

            // start the sorted length at 0 to use as sorted index element
            int nSortedLength = 0;

            // while there are unsorted values to sort
            while (aUnsorted.Length > 0)
            {
                // store the lowest or highest unsorted value as the next sorted value
                aSorted[nSortedLength] = findHiLow(aUnsorted);

                // remove the current sorted value
                RemoveUnsortedValue(aSorted[nSortedLength], ref aUnsorted);

                // increment the number of values in the sorted array
                ++nSortedLength;
            }

            // write the sorted array of strings
            Console.WriteLine("The sorted list is: ");
            foreach (string thisWord in aSorted)
            {
                Console.Write($"{thisWord} ");
            }

            Console.WriteLine();
        }

        // Method: FindLowestValue
        // Purpose: find the lowest value in the array of strings
        // Restrictions: None
        static string FindLowestValue(string[] array)
        {
            // define return value
            string returnVal;

            // initialize to the first element in the array
            // (we must initialize to an array element)
            returnVal = array[0];

            // loop through the array
            foreach (string thisWord in array)
            {
                // if the current value is less than the saved lowest value
                if (thisWord.CompareTo(returnVal) <0)
                {
                    // save this as the lowest value
                    returnVal = thisWord;
                }
            }

            // return the lowest value
            return (returnVal);
        }


        // Method: FindHighestValue
        // Purpose: find the highest value in the array of strings
        // Restrictions: None
        static string FindHighestValue(string[] array)
        {
            // define return value
            string returnVal;

            // initialize to the first element in the array
            // (we must initialize to an array element)
            returnVal = array[0];

            // loop through the array
            foreach (string thisWord in array)
            {
                // if the current value is greater than the saved highest value
                if (thisWord.CompareTo(returnVal) > 0)
                {
                    // save this as the highest value
                    returnVal = thisWord;
                }
            }

            // return the highest value
            return (returnVal);
        }


        // remove the first instance of a value from an array
        static void RemoveUnsortedValue(string removeValue, ref string[] array)
        {
            // allocate a new array to hold 1 less value than the source array
            string[] newArray = new string[array.Length - 1];

            // we need a separate counter to index into the new array, 
            // since we are skipping a value in the source array
            int dest = 0;

            // the same value may occur multiple times in the array, so skip subsequent occurrences
            bool bAlreadyRemoved = false;

            // iterate through the source array
            foreach (string word in array)
            {
                // if this is the word to be removed and we didn't remove it yet
                if (word == removeValue && !bAlreadyRemoved)
                {
                    // set the flag that it was removed
                    bAlreadyRemoved = true;

                    // and skip it (ie. do not add it to the new array)
                    continue;
                }

                // insert the source string into the new array
                newArray[dest] = word;

                // increment the new array index to insert the next string
                ++dest;
            }

            // set the ref array equal to the new array, which has the target string removed
            // this changes the variable in the calling function (aUnsorted in this case)
            array = newArray;
        }
    }
}

