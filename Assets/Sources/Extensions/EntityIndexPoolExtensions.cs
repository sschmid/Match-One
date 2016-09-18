using System.Collections.Generic;
using Entitas;

public static class EntityIndexPoolExtensions {

    public const string PositionKey = "Position";

    public static void AddEntityIndices(this Pools pools) {
        var positionIndex = new EntityIndex<string>(
            pools.core.GetGroup(CoreMatcher.Position),
            (e, c) => {
                var positionComponent = c as PositionComponent;
                return positionComponent != null
                    ? positionComponent.x + "," + positionComponent.y
                    : e.position.x + "," + e.position.y;
            }
        );

        pools.core.AddEntityIndex(PositionKey, positionIndex);
    }

    public static HashSet<Entity> GetEntitiesWithPosition(this Pool pool, int x, int y) {
        var index = (EntityIndex<string>)pool.GetEntityIndex(PositionKey);
        return index.GetEntities(x + "," + y);
    }
}
