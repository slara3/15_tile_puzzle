namespace TileGamePuzzle
{
    class Tile
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool Locked { get; set; }

        public Tile()
        {
            X = Y = 0;
            Locked = false;
        }
    }
}