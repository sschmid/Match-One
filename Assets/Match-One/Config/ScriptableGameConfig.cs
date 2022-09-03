using UnityEngine;

[CreateAssetMenu(menuName = "Match One/Game Config")]
public class ScriptableGameConfig : ScriptableObject, IGameConfig
{
    [SerializeField] Vector2Int _boardSize;
    public Vector2Int BoardSize => _boardSize;

    [SerializeField] float _blockerProbability;
    public float BlockerProbability => _blockerProbability;
}
