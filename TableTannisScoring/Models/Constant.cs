using System.Collections.Generic;

namespace TableTennis.Console.Models
{
    public static class Constant
    {
        public static readonly List<int> WinningScore = new List<int> { 11, 21 };
        public const int PointDifferenceToWin = 2;
        public const int TiePoint10 = 10;
        public const int TiePoint20 = 20;
        public const int NumberOfConsicutiveServices = 2;
    }
}