using Entitas;
using UnityEngine;

public static class ContextExtensions {

    static readonly string[] _pieces = {
        Res.Piece0,
        Res.Piece1,
        Res.Piece2,
        Res.Piece3,
        Res.Piece4,
        Res.Piece5
    };

    public static Entity CreateRandomPiece(this Context context, int x, int y) {
        return context.CreateEntity()
            .IsGameBoardElement(true)
            .AddPosition(x, y)
            .IsMovable(true)
            .IsInteractive(true)
            .AddAsset(_pieces[Random.Range(0, _pieces.Length)]);
    }

    public static Entity CreateBlocker(this Context context, int x, int y) {
        return context.CreateEntity()
            .IsGameBoardElement(true)
            .AddPosition(x, y)
            .AddAsset(Res.Blocker);
    }
}
