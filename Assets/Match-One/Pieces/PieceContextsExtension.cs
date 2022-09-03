using Entitas;
using UnityEngine;

public partial class Contexts
{
    public const string Piece = "Piece";

    [Entitas.CodeGeneration.Attributes.PostConstructor]
    public void InitializePieceEntityIndices()
    {
        game.AddEntityIndex(new PrimaryEntityIndex<GameEntity, Vector2Int>(
            Piece,
            game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Piece, GameMatcher.Position)
                .NoneOf(GameMatcher.Destroyed)
            ),
            (e, c) => (c as PositionComponent)?.value ?? e.position.value));
    }
}

public static class ContextsExtensions
{
    public static GameEntity GetPieceWithPosition(this GameContext context, Vector2Int value)
    {
        return ((PrimaryEntityIndex<GameEntity, Vector2Int>)context.GetEntityIndex(Contexts.Piece)).GetEntity(value);
    }
}
