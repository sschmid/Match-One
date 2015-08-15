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

    public static Entity CreateRandomPiece(this Pool pool, int x, int y) {
        return pool.CreateEntity()
            .IsGameBoardElement(true)
            .AddPosition(x, y)
            .IsMovable(true)
            .IsInteractive(true)
            .AddResource(_pieces[Random.Range(0, _pieces.Length)]);
    }

    public static Entity CreateBlocker(this Pool pool, int x, int y) {
        return pool.CreateEntity()
            .IsGameBoardElement(true)
            .AddPosition(x, y)
            .AddResource(Res.Blocker);
    }
}

