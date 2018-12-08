using UnityEngine;

public static class PieceContextExtension
{
    public static GameEntity CreateRandomPiece(this GameContext context, int x, int y)
    {
        var entity = context.CreateEntity();
        entity.isPiece = true;
        entity.isMovable = true;
        entity.isInteractive = true;
        entity.AddPosition(new Vector2Int(x, y));
        entity.AddAsset("Piece" + Rand.game.Int(6));
        return entity;
    }

    public static GameEntity CreateBlocker(this GameContext context, int x, int y)
    {
        var entity = context.CreateEntity();
        entity.isPiece = true;
        entity.AddPosition(new Vector2Int(x, y));
        entity.AddAsset("Blocker");
        return entity;
    }
}
