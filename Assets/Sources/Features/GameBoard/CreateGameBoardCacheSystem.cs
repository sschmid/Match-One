using Entitas;

public class CreateGameBoardCacheSystem : IStartSystem, IReactiveSystem, ISetPool {

    Pool _pool;
    Group _gameBoardElements;

    public IMatcher GetTriggeringMatcher() {
        return Matcher.AllOf(Matcher.GameBoardElement, Matcher.Position);
    }

    public GroupEventType GetEventType() {
        return GroupEventType.OnEntityAddedOrRemoved;
    }

    public void SetPool(Pool pool) {
        _pool = pool;
        _gameBoardElements = _pool.GetGroup(Matcher.AllOf(Matcher.GameBoardElement, Matcher.Position));
    }

    public void Start() {
        updateGrid();
    }

    public void Execute(Entity[] entities) {
        updateGrid();
    }

    void updateGrid() {

        UnityEngine.Debug.Log("Create GameBoard Cache");

        var gameBoard = _pool.gameBoard;
        var grid = new Entity[gameBoard.columns, gameBoard.rows];
        foreach (var e in _gameBoardElements.GetEntities()) {
            var pos = e.position;
            grid[pos.x, pos.y] = e;
        }

        _pool.ReplaceGameBoardCache(grid);
    }
}

