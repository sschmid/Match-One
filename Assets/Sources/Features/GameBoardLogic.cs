public static class GameBoardLogic {

    public static int GetNextEmptyRow(GameContext context, int column, int row) {
        var rowBelow = row - 1;
        while(rowBelow >= 0 && context.GetEntitiesWithPosition(column, rowBelow).Count == 0) {
            rowBelow -= 1;
        }

        return rowBelow + 1;
    }
}
