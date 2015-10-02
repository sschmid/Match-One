public static class ComponentIds {
    public const int Destroy = 0;
    public const int GameBoardCache = 1;
    public const int GameBoard = 2;
    public const int GameBoardElement = 3;
    public const int Input = 4;
    public const int Interactive = 5;
    public const int Movable = 6;
    public const int Position = 7;
    public const int Resource = 8;
    public const int Score = 9;
    public const int View = 10;

    public const int TotalComponents = 11;

    static readonly string[] _components = {
        "Destroy",
        "GameBoardCache",
        "GameBoard",
        "GameBoardElement",
        "Input",
        "Interactive",
        "Movable",
        "Position",
        "Resource",
        "Score",
        "View"
    };

    public static string IdToString(int componentId) {
        return _components[componentId];
    }
}