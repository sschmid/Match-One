using System.Collections.Generic;
using Entitas;

public static class EntityIndexPoolExtensions {

    public const string PositionKey = "Position";
    const int shiftX = 8;

    public static void AddEntityIndices(this Pools pools) {
        var positionIndex = new EntityIndex<int>(
            pools.core.GetGroup(CoreMatcher.Position),
            (e, c) => {
                var positionComponent = c as PositionComponent;
                return positionComponent != null
                    ? (positionComponent.x << shiftX) + positionComponent.y
                    : (e.position.x << shiftX) + e.position.y;
            }
        );

        pools.core.AddEntityIndex(PositionKey, positionIndex);
    }

    public static HashSet<Entity> GetEntitiesWithPosition(this Pool pool, int x, int y) {
        var index = (EntityIndex<int>)pool.GetEntityIndex(PositionKey);
        return index.GetEntities((x << shiftX) + y);
    }
}
