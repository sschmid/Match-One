using UnityEngine;

public static class BoardLogic
{
    public static int GetNextEmptyRow(Contexts contexts, Vector2Int position)
    {
        position.y -= 1;
        while (position.y >= 0 && contexts.game.GetPieceWithPosition(position) == null)
        {
            position.y -= 1;
        }

        return position.y + 1;
    }
}
