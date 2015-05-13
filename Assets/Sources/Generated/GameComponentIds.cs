using Entitas;

using System.Collections.Generic;

public static class GameComponentIds {
    public const int Resource = 0;
    public const int View = 1;

    public const int TotalComponents = 2;

    static readonly Dictionary<int, string> components = new Dictionary<int, string> {
        { 0, "Resource" },
        { 1, "View" }
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