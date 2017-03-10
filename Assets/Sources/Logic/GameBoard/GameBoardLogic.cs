public static class GameBoardLogic {

    public static int GetNextEmptyRow(GameContext context, IntVector2 position) {
        position.y -= 1;
        while(position.y >= 0 && context.GetEntitiesWithPosition(position).Count == 0) {
            position.y -= 1;
        }

        return position.y + 1;
    }
}
