using System.Collections.Generic;
using Entitas;

public static class EntityIndexPoolExtensions {

    public const string PositionKey = "Position";
    const int shiftX = 8;

    public static void AddEntityIndices(this Contexts pools) {
        var positionIndex = new EntityIndex<int>(
            pools.game.GetGroup(GameMatcher.Position),
            (e, c) => {
                var positionComponent = c as PositionComponent;
                return positionComponent != null
                    ? (positionComponent.x << shiftX) + positionComponent.y
                    : (e.position.x << shiftX) + e.position.y;
            }
        );

        pools.game.AddEntityIndex(PositionKey, positionIndex);
    }

    public static HashSet<Entity> GetEntitiesWithPosition(this Context pool, int x, int y) {
        var index = (EntityIndex<int>)pool.GetEntityIndex(PositionKey);
        return index.GetEntities((x << shiftX) + y);
    }
}
