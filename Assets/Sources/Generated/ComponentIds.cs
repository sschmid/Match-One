using System.Collections.Generic;

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

    static readonly Dictionary<int, string> components = new Dictionary<int, string> {
        { 0, "Destroy" },
        { 1, "GameBoardCache" },
        { 2, "GameBoard" },
        { 3, "GameBoardElement" },
        { 4, "Input" },
        { 5, "Interactive" },
        { 6, "Movable" },
        { 7, "Position" },
        { 8, "Resource" },
        { 9, "Score" },
        { 10, "View" }
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