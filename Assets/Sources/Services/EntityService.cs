public class EntityService {

    public RandomService randomService = RandomService.game;

    public static EntityService singleton = new EntityService();

    static readonly string[] _pieces = {
        Res.Piece0,
        Res.Piece1,
        Res.Piece2,
        Res.Piece3,
        Res.Piece4,
        Res.Piece5
    };

    Contexts _contexts;

    public void Initialize(Contexts contexts) {
        _contexts = contexts;
    }

    public GameEntity CreateGameBoard() {
        var entity = _contexts.game.CreateEntity();
        entity.AddGameBoard(8, 9);
        return entity;
    }

    public GameEntity CreateRandomPiece(int x, int y) {
        var entity = _contexts.game.CreateEntity();
        entity.isGameBoardElement = true;
        entity.isMovable = true;
        entity.isInteractive = true;
        entity.AddPosition(new IntVector2(x, y));
        entity.AddAsset(randomService.Element(_pieces));
        return entity;
    }

    public GameEntity CreateBlocker(int x, int y) {
        var entity = _contexts.game.CreateEntity();
        entity.isGameBoardElement = true;
        entity.AddPosition(new IntVector2(x, y));
        entity.AddAsset(Res.Blocker);
        return entity;
    }
}
