using Entitas;

public class FillGameBoardSystem : IStartSystem, IReactiveSystem, ISetPool {

    Pool _pool;
    GameBoardComponent _gameBoard;
    GameBoardCacheComponent _gameBoardCache;

    public IMatcher GetTriggeringMatcher() {
        return GameMatcher.GameBoardElement;
    }

    public GroupEventType GetEventType() {
        return GroupEventType.OnEntityAddedOrRemoved;
    }

    public void SetPool(Pool pool) {
        _pool = pool;
    }

    public void Start() {
        _gameBoard = _pool.gameBoard;
        _gameBoardCache = _pool.gameBoardCache;
        fillGameBoard();
    }

    public void Execute(Entity[] entities) {
        fillGameBoard();
    }

    void fillGameBoard() {

        UnityEngine.Debug.Log("FillGameBoardSystem");

        fall();
        fill();
    }

    void fall() {
        var grid = _gameBoardCache.grid;
        for (int column = 0; column < _gameBoard.columns; column++) {
            for (int row = 1; row < _gameBoard.rows; row++) {
                var e = grid[column, row];
                if (e != null) {
                    moveDown(e, column, row, grid);
                }
            }
        }
    }

    void moveDown(Entity e, int column, int row, Entity[,] grid) {
        var nextRowPos = getNextEmptyRowPosition(column, row, grid);
        if (nextRowPos != row) {
            grid[column, nextRowPos] = e;
            grid[column, row] = null;
            e.ReplacePosition(column, nextRowPos);
        }
    }

    int getNextEmptyRowPosition(int column, int row, Entity[,] grid) {
        var rowBelow = row - 1;
        while (rowBelow >= 0 && grid[column, rowBelow] == null) {
            rowBelow -= 1;
        }

        return rowBelow + 1;
    }

    void fill() {
        var grid = _gameBoardCache.grid;
        for (int column = 0; column < _gameBoard.columns; column++) {
            var nextRowPos = getNextEmptyRowPosition(column, _gameBoard.rows, grid);
            while (nextRowPos != _gameBoard.rows) {
                var e = _pool.CretaeRanomPiece(column, nextRowPos);
                grid[column, nextRowPos] = e;
                nextRowPos = getNextEmptyRowPosition(column, _gameBoard.rows, grid);
            }
        }
    }
}

