using Entitas;
using UnityEngine;

public static class PoolExtensions {

    static readonly string[] _pieces = {
        Res.Piece0,
        Res.Piece1,
        Res.Piece2,
        Res.Piece3,
        Res.Piece4,
        Res.Piece5
    };

    public static Entity CretaeRanomPiece(this Pool pool, int x, int y) {
        var e = pool.CreateEntity();
        e.isGameBoardElement = true;
        e.AddPosition(x, y);
        e.AddResource(_pieces[Random.Range(0, _pieces.Length)]);
        return e;
    }
}

