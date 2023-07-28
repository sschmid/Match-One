using UnityEngine;

namespace MatchOne
{
    [CreateAssetMenu(menuName = "MatchOne/Piece Colors Config")]
    public class ScriptablePieceColorsConfig : ScriptableObject, IPieceColorsConfig
    {
        [SerializeField] public Color[] _colors;
        public Color[] Colors => _colors;
    }
}
