using UnityEngine;

namespace MatchOne
{
    public static class BoardLogic
    {
        public static int GetNextEmptyRow(GameContext gameContext, Vector2Int position)
        {
            position.y -= 1;
            while (position.y >= 0 && gameContext.GetPieceWithPosition(position) == null)
            {
                position.y -= 1;
            }

            return position.y + 1;
        }
    }
}
