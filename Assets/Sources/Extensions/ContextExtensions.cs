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

    public static GameEntity CreateGameBoard(this GameContext context) {
        var entity = context.CreateEntity();
        entity.AddGameBoard(8, 9);

        return entity;
    }

    public static GameEntity CreateRandomPiece(this GameContext context, int x, int y) {
        var entity = context.CreateEntity();
        entity.isGameBoardElement = true;
        entity.isMovable = true;
        entity.isInteractive = true;
        entity.AddPosition(new IntVector2(x, y));
        entity.AddAsset(_pieces[Random.Range(0, _pieces.Length)]);

        return entity;
    }

    public static GameEntity CreateBlocker(this GameContext context, int x, int y) {
        var entity = context.CreateEntity();
        entity.isGameBoardElement = true;
        entity.AddPosition(new IntVector2(x, y));
        entity.AddAsset(Res.Blocker);
        return entity;
    }
}
