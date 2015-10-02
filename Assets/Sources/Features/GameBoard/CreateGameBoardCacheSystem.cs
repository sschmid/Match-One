using Entitas;
using UnityEngine;

public class CreateGameBoardCacheSystem : ISystem, ISetPool {
    Pool _pool;

    public void SetPool(Pool pool) {
        _pool = pool;

        var gameBoard = _pool.GetGroup(Matcher.GameBoard);
        gameBoard.OnEntityAdded += (group, entity, index, component) => createNewGameBoardCache((GameBoardComponent)component);
        gameBoard.OnEntityUpdated += (group, entity, index, previousComponent, newComponent) => createNewGameBoardCache((GameBoardComponent)newComponent);

        var gameBoardElements = pool.GetGroup(Matcher.AllOf(Matcher.GameBoardElement, Matcher.Position));
        gameBoardElements.OnEntityAdded += onGameBoardElementAdded;
        gameBoardElements.OnEntityRemoved += onGameBoardElementRemoved;
    }

    void createNewGameBoardCache(GameBoardComponent gameBoard) {

        Debug.Log("Create GameBoard Cache");

        var grid = new Entity[gameBoard.columns, gameBoard.rows];
        foreach (var e in _pool.GetEntities(Matcher.AllOf(Matcher.GameBoardElement, Matcher.Position))) {
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

    void onGameBoardElementRemoved(Group group, Entity entity, int index, IComponent component) {
        var pos = component as PositionComponent;
        if (pos == null) {
            pos = entity.position;
        }
        var grid = _pool.gameBoardCache.grid;
        grid[pos.x, pos.y] = null;
        _pool.ReplaceGameBoardCache(grid);
    }
}

