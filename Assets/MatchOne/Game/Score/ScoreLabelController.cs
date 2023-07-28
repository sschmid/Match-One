using MatchOne.GameState;
using TMPro;
using UnityEngine;

namespace MatchOne
{
    public class ScoreLabelController : MonoBehaviour, IMatchOneGameStateAnyScoreAddedListener
    {
        public TMP_Text Label;

        void Start()
        {
            GameStateContext.Instance.CreateEntity().AddAnyScoreAddedListener(this);
        }

        public void OnAnyScoreAdded(Entity entity, int value)
        {
            Label.text = "Score " + value;
        }
    }
}
