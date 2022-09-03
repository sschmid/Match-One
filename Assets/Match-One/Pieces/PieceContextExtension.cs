using UnityEngine;

public static class PieceContextExtension
{
    public static GameEntity CreateRandomPiece(this GameContext context, int x, int y)
    {
        var entity = context.CreateEntity();
        entity.AddPiece(Rand.game.Int(10));
        entity.AddPosition(new Vector2Int(x, y));
        entity.isMovable = true;
        entity.isInteractive = true;
        entity.AddAsset("Piece");
        return entity;
    }

    public static GameEntity CreateBlocker(this GameContext context, int x, int y)
    {
        var entity = context.CreateEntity();
        entity.AddPiece(-1);
        entity.AddPosition(new Vector2Int(x, y));
        entity.AddAsset("Blocker");
        return entity;
    }
}
