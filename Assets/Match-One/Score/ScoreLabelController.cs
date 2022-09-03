using UnityEngine;
using UnityEngine.UI;

public class ScoreLabelController : MonoBehaviour, IAnyScoreListener
{
    public Text label;

    void Start()
    {
        var listener = Contexts.sharedInstance.gameState.CreateEntity();
        listener.AddAnyScoreListener(this);
    }

    public void OnAnyScore(GameStateEntity entity, int value)
    {
        label.text = "Score " + value;
    }
}
