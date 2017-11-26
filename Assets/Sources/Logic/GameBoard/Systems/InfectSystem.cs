using System.Collections.Generic;
using System.Linq;
using Entitas;

// Ethan:
// TODO: As in an auto-linker game like Collapse:
// Optionally destroy all contiguous colors that match the color.
// Reacts after a cell is destroyed but before any cell has fallen.
//
// This new feature tests how quickly I can edit gameplay in an entity-component-system.
public sealed class InfectSystem : ReactiveSystem<GameEntity> {

    readonly GameContext _context;
    readonly IntVector2[] _adjacents;

    public InfectSystem(Contexts contexts) : base(contexts.game) {
        _context = contexts.game;
        _adjacents = new IntVector2[] {
            new IntVector2(-1, 0),
            new IntVector2(0, -1),
            new IntVector2(0, 1),
            new IntVector2(1, 0)
        };
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) {
        return context.CreateCollector(GameMatcher.GameBoardElement.Removed());
    }

    protected override bool Filter(GameEntity entity) {
        return true;
    }

    protected override void Execute(List<GameEntity> entities) {
        if (entities == null || entities.Count == 0) {
            return;
        }
        for (int index = 0, end = entities.Count; index < end; ++index) {
            GameEntity entity = entities[index];
            List<GameEntity> groupMates = new List<GameEntity>();
            findLikeNeighbors(entity, groupMates);
            destroyAll(groupMates);
        }
    }

    // TODO
    // Depth-first search orthogonal neighbors with an equal asset.
    private void findLikeNeighbors(GameEntity source, List<GameEntity> groupMates)
    {
        if (!source.hasAsset) {
            return;
        }
        string sourceName = source.asset.name;
        Stack<GameEntity> frontiers = new Stack<GameEntity>();
        frontiers.Push(source);
        HashSet<GameEntity> visited = new HashSet<GameEntity>();
        while (frontiers.Count > 0) {
            GameEntity frontier = frontiers.Pop();
            if (visited.Contains(frontier)) {
                continue;
            }
            visited.Add(frontier);
            for (int adjacentIndex = 0, adjacentEnd = _adjacents.Length; adjacentIndex < adjacentEnd; ++adjacentIndex) {
                IntVector2 adjacent = frontier.position.value + _adjacents[adjacentIndex];
                GameEntity[] likeNeighbors = _context.GetEntitiesWithPosition(adjacent)
                    .Where(e => e.isMovable
                        && e.hasAsset
                        && e.asset.name == sourceName
                    ).ToArray();
                for (int neighborIndex = 0, neighborEnd = likeNeighbors.Length; neighborIndex < neighborEnd; ++neighborIndex) {
                    GameEntity likeNeighbor = likeNeighbors[neighborIndex];
                    if (groupMates.Contains(likeNeighbor)) {
                        continue;
                    }
                    groupMates.Add(likeNeighbor);
                    frontiers.Push(likeNeighbor);
                }
            }
        }
    }

    private void destroyAll(List<GameEntity> doomedEntities)
    {
        for (int index = 0, end = doomedEntities.Count; index < end; ++index)
        {
            GameEntity entity = doomedEntities[index];
            entity.isDestroyed = true;
        }
    }
}
