public class GameBoardService {

    public static GameBoardService singleton = new GameBoardService();

    Contexts _contexts;

    public void Initialize(Contexts contexts) {
        _contexts = contexts;
    }

    public int GetNextEmptyRow(IntVector2 position) {
        position.y -= 1;
        while (position.y >= 0 && _contexts.game.GetEntitiesWithPosition(position).Count == 0) {
            position.y -= 1;
        }

        return position.y + 1;
    }
}
