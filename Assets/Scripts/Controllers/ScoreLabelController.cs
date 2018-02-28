using UnityEngine;
using UnityEngine.UI;

public class ScoreLabelController : MonoBehaviour, IScoreListener {

    public Text label;

    void Start() {
        Contexts.sharedInstance.gameState.CreateEntity().AddScoreListener(this);
    }

    public void OnScore(GameStateEntity entity, int value) {
        label.text = "Score " + value;
    }
}
