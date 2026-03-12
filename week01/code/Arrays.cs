public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        return []; // replace this return statement with your own
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.
    }
}


public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // Step 1: Create a new array of type double with the size equal to length.
        // Step 2: Use a loop to go through each position in the array.
        // Step 3: For each index i, calculate the multiple of the number.
        //         The formula will be: number * (i + 1).
        //         This ensures the first value is the number itself.
        // Step 4: Store the calculated value in the array at index i.
        // Step 5: After filling all positions, return the array.

        double[] result = new double[length];

        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }

        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.
    /// Example:
    /// {1,2,3,4,5,6,7,8,9} rotated by 3 becomes
    /// {7,8,9,1,2,3,4,5,6}
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // Step 1: Determine how many elements need to move from the end of the list
        //         to the front. This number is given by 'amount'.
        // Step 2: Use GetRange to copy the last 'amount' elements from the list.
        // Step 3: Remove those elements from the end of the original list
        //         using RemoveRange.
        // Step 4: Insert the copied elements at the beginning of the list
        //         using InsertRange.
        // Step 5: The original list is now rotated to the right.

        int startIndex = data.Count - amount;

        List<int> endPortion = data.GetRange(startIndex, amount);

        data.RemoveRange(startIndex, amount);

        data.InsertRange(0, endPortion);
    }
}