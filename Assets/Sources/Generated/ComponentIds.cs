using System.Collections.Generic;

public static class ComponentIds {
    public const int Blocker = 0;
    public const int Destroy = 1;
    public const int GameBoardCache = 2;
    public const int GameBoard = 3;
    public const int GameBoardElement = 4;
    public const int Input = 5;
    public const int Interactive = 6;
    public const int Piece = 7;
    public const int Position = 8;
    public const int Resource = 9;
    public const int Score = 10;
    public const int View = 11;

    public const int TotalComponents = 12;

    static readonly Dictionary<int, string> components = new Dictionary<int, string> {
        { 0, "Blocker" },
        { 1, "Destroy" },
        { 2, "GameBoardCache" },
        { 3, "GameBoard" },
        { 4, "GameBoardElement" },
        { 5, "Input" },
        { 6, "Interactive" },
        { 7, "Piece" },
        { 8, "Position" },
        { 9, "Resource" },
        { 10, "Score" },
        { 11, "View" }
    };

    public static string IdToString(int componentId) {
        return components[componentId];
    }
}

namespace Entitas {
    public partial class Matcher : AllOfMatcher {
        public Matcher(int index) : base(new [] { index }) {
        }

        public override string ToString() {
            return ComponentIds.IdToString(indices[0]);
        }
    }
}