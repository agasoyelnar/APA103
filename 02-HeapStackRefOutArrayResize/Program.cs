class Program
{
    static void Main()
    {
        int[] arr = { 1, 2, 3 };

        int[] result = CustomArrResize(arr, 4, 5, 6);

        for (int i = 0; i < result.Length; i++)
        {
            Console.WriteLine(result[i]);
        }
    }

    static int[] CustomArrResize(int[] arr, params int[] nums)
    {
        int[] result = new int[arr.Length + nums.Length];

        int index = 0;

        for (int i = 0; i < arr.Length; i++)
        {
            result[index] = arr[i];
            index++;
        }

        for (int i = 0; i < nums.Length; i++)
        {
            result[index] = nums[i];
            index++;
        }

        return result;
    }
}