using UnityEngine;

[CreateAssetMenu(menuName = "Match One/Piece Colors Config")]
public class ScriptablePieceColorsConfig : ScriptableObject, IPieceColorsConfig
{
    [SerializeField] public Color[] _colors;
    public Color[] Colors => _colors;
}
