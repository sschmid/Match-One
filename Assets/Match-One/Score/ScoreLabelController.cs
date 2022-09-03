using TMPro;
using UnityEngine;

public class ScoreLabelController : MonoBehaviour, IAnyScoreListener
{
    public TMP_Text Label;

    void Start()
    {
        var listener = Contexts.sharedInstance.gameState.CreateEntity();
        listener.AddAnyScoreListener(this);
    }

    public void OnAnyScore(GameStateEntity entity, int value) =>
        Label.text = "Score " + value;
}
