namespace SignalR
{
    public static class SD
    {
        static SD()
        {
            DealthyHallowRace = new Dictionary<string, int>();
            DealthyHallowRace.Add(Cloak,0);
            DealthyHallowRace.Add(Stone, 0);
            DealthyHallowRace.Add(Wand, 0);
        }
        public const string Wand = "wand";
        public const string Stone = "Stone";
        public const string Cloak = "Cloak";
        public static Dictionary<string, int> DealthyHallowRace;

    }
}
