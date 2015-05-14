using Entitas;

using System.Collections.Generic;

public static class GameComponentIds {
    public const int GameBoardCache = 0;
    public const int GameBoard = 1;
    public const int GameBoardElement = 2;
    public const int Position = 3;
    public const int Resource = 4;
    public const int View = 5;

    public const int TotalComponents = 6;

    static readonly Dictionary<int, string> components = new Dictionary<int, string> {
        { 0, "GameBoardCache" },
        { 1, "GameBoard" },
        { 2, "GameBoardElement" },
        { 3, "Position" },
        { 4, "Resource" },
        { 5, "View" }
    };

    public static string IdToString(int componentId) {
        return components[componentId];
    }
}

public partial class GameMatcher : AllOfMatcher {
    public GameMatcher(int index) : base(new [] { index }) {
    }

    public override string ToString() {
        return GameComponentIds.IdToString(indices[0]);
    }
}