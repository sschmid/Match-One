using UnityEngine;

namespace MatchOne
{
    [CreateAssetMenu(menuName = "MatchOne/Game Config")]
    public class ScriptableGameConfig : ScriptableObject, IGameConfig
    {
        [SerializeField] Vector2Int _boardSize;
        public Vector2Int BoardSize => _boardSize;

        [SerializeField] float _blockerProbability;
        public float BlockerProbability => _blockerProbability;
    }
}
