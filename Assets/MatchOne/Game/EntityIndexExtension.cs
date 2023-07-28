using Entitas;
using MatchOne.Game;
using UnityEngine;

namespace MatchOne
{
    public static class EntityIndexExtension
    {
        public const string MatchOnePiecePosition = "MatchOnePiecePosition";

        public static GameContext AddCustomEntityIndexes(this GameContext gameContext)
        {
            gameContext.AddEntityIndex(new PrimaryEntityIndex<Game.Entity, Vector2Int>(
                MatchOnePiecePosition,
                gameContext.GetGroup(Matcher
                    .AllOf(MatchOneGamePieceMatcher.Piece, MatchOneGamePositionMatcher.Position)
                    .NoneOf(MatchOneGameDestroyedMatcher.Destroyed)),
                (e, c) => (c as PositionComponent)?.Value ?? e.GetPosition().Value));

            return gameContext;
        }

        public static Game.Entity GetPieceWithPosition(this GameContext context, Vector2Int value)
        {
            return ((PrimaryEntityIndex<Game.Entity, Vector2Int>)context.GetEntityIndex(MatchOnePiecePosition)).GetEntity(value);
        }
    }
}
