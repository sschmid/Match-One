public class GameBoardService {

    public static GameBoardService singleton = new GameBoardService();

    public int GetNextEmptyRow(GameContext context, IntVector2 position) {
        position.y -= 1;
        while (position.y >= 0 && context.GetEntitiesWithPosition(position).Count == 0) {
            position.y -= 1;
        }

        return position.y + 1;
    }
}
