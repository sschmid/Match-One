using System;

public struct IntVector2 : IEquatable<IntVector2> {

    public int x;
    public int y;

    public IntVector2(int x, int y) {
        this.x = x;
        this.y = y;
    }

    public bool Equals(IntVector2 other) {
        return other.x == x && other.y == y;
    }

    public override bool Equals(object obj) {
        if (obj == null || obj.GetType() != GetType() || obj.GetHashCode() != GetHashCode()) {
            return false;
        }

        var other = (IntVector2)obj;
        return other.x == x && other.y == y;
    }

    public override int GetHashCode() {
        return (x << 8) + y;
    }
}
