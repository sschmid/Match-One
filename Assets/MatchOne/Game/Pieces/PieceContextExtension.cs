using UnityEngine;

namespace MatchOne
{
    public static class PieceContextExtension
    {
        public static Game.Entity CreateRandomPiece(this GameContext context, int x, int y)
        {
            return context.CreateEntity()
                .AddPiece(Rand.Game.Int(10))
                .AddPosition(new Vector2Int(x, y))
                .AddMovable()
                .AddInteractive()
                .AddAsset("Piece");
        }

        public static Game.Entity CreateBlocker(this GameContext context, int x, int y)
        {
            return context.CreateEntity()
                .AddPiece(-1)
                .AddPosition(new Vector2Int(x, y))
                .AddAsset("Blocker");
        }
    }
}
