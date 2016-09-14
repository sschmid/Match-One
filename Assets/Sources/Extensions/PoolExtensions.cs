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

    public static void AddEntityIndices(this Pools pools) {
        var positionIndex = new PrimaryEntityIndex<string>(
            pools.core.GetGroup(CoreMatcher.Position),
            (e, c) => {
                var positionComponent = c as PositionComponent;
                return positionComponent != null
                    ? positionComponent.x + "," + positionComponent.y
                    : e.position.x + "," + e.position.y;
            }
        );

        pools.core.AddEntityIndex(CoreComponentIds.Position.ToString(), positionIndex);
    }

    public static Entity GetEntityWithPosition(this Pool pool, int x, int y) {
        var index = (PrimaryEntityIndex<string>)pool.GetEntityIndex(CoreComponentIds.Position.ToString());
        return index.TryGetEntity(x + "," + y);
    }
}
