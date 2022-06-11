namespace ChessBoard
{
    internal class BoardPosition
    {
        public int PositionWidth { get; set; }
        public int PositionHeight { get; set; }
        

        public BoardPosition(int positionWidth, int positionHeight)
        {
            PositionWidth = positionWidth;
            PositionHeight = positionHeight;
            
        }

        public void SetPosition(int width, int height)
        {
            PositionWidth = width;
            PositionHeight = height;
        }

        public override string ToString()
        {
            return $"{PositionWidth} , {PositionHeight}";
        }
    }
}
