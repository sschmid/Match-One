using Entitas;

public class CreateGameBoardCacheSystem : ISystem, ISetPool {
    Pool _pool;
    Group _gameBoardElements;
    Group _destroyedGameBoardElements;

    public void SetPool(Pool pool) {
        _pool = pool;

        var gameBoard = pool.GetGroup(Matcher.GameBoard);
        gameBoard.OnEntityAdded += onGameBoardAdded;
        gameBoard.OnEntityUpdated += onGameBoardUpdated;

        _gameBoardElements = pool.GetGroup(Matcher.AllOf(Matcher.GameBoardElement, Matcher.Position));
        _gameBoardElements.OnEntityAdded += onGameBoardElementAdded;
        _gameBoardElements.OnEntityUpdated += onGameBoardElementUpdated;

        _destroyedGameBoardElements = pool.GetGroup(Matcher.AllOf(Matcher.GameBoardElement, Matcher.Position, Matcher.Destroy));
        _destroyedGameBoardElements.OnEntityAdded += onGameBoardElementDestroyed;
    }

    void onGameBoardAdded(Group group, Entity entity, int index, IComponent component) {
        createNewGameBoardCache((GameBoardComponent)component);
    }

    void onGameBoardUpdated(Group group, Entity entity, int index, IComponent previousComponent, IComponent newComponent) {
        createNewGameBoardCache((GameBoardComponent)newComponent);
    }

    void createNewGameBoardCache(GameBoardComponent gameBoard) {

        UnityEngine.Debug.Log("Create GameBoard Cache");

        var grid = new Entity[gameBoard.columns, gameBoard.rows];
        foreach (var e in _gameBoardElements.GetEntities()) {
            var pos = e.position;
            grid[pos.x, pos.y] = e;
        }
        _pool.ReplaceGameBoardCache(grid);
    }

    void onGameBoardElementAdded(Group group, Entity entity, int index, IComponent component) {
        var grid = _pool.gameBoardCache.grid;
        var pos = entity.position;
        grid[pos.x, pos.y] = entity;
        _pool.ReplaceGameBoardCache(grid);
    }

    void onGameBoardElementUpdated(Group group, Entity entity, int index, IComponent previousComponent, IComponent newComponent) {
        var prevPos = previousComponent as PositionComponent;
        var newPos = (PositionComponent)newComponent;
        var grid = _pool.gameBoardCache.grid;
        grid[prevPos.x, prevPos.y] = null;
        grid[newPos.x, newPos.y] = entity;
        _pool.ReplaceGameBoardCache(grid);
    }

    void onGameBoardElementDestroyed(Group group, Entity entity, int index, IComponent component) {
        var grid = _pool.gameBoardCache.grid;
        var pos = entity.position;
        grid[pos.x, pos.y] = null;
        _pool.ReplaceGameBoardCache(grid);
    }
}

