using System;
using Entitas;

public static class GameBoardLogic {

    public static int GetNextEmptyRow(this Entity[,] grid, int column, int row) {
        var rowBelow = row - 1;
        while (rowBelow >= 0 && grid[column, rowBelow] == null) {
            rowBelow -= 1;
        }

        return rowBelow + 1;
    }
}

