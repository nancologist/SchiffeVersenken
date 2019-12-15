using System;
namespace SchiffeVersenken
{
    public class PlayGround
    {
        public PlayGround()
        {
        }

        public static void TestArrayEqauls()
        {
            int[] arr = { 1, 2 };
            Console.WriteLine(arr.Equals(new int[] {1,2}));
        }
    }
}
