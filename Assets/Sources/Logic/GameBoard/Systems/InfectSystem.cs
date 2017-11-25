using System.Collections.Generic;
using Entitas;

// Ethan:
// TODO: As in an auto-linker game like Collapse:
// Optionally destroy all contiguous colors that match the color.
// Reacts after a cell is destroyed but before any cell has fallen.
//
// This new feature tests how quickly I can edit gameplay in an entity-component-system.
public sealed class InfectSystem : ReactiveSystem<GameEntity> {

    readonly GameContext _context;

    public InfectSystem(Contexts contexts) : base(contexts.game) {
        _context = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) {
        return context.CreateCollector(GameMatcher.GameBoardElement.Removed());
    }

    protected override bool Filter(GameEntity entity) {
        return true;
    }

    protected override void Execute(List<GameEntity> entities) {
        // TODO
    }
}
