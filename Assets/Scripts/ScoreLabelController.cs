using Entitas;
using UnityEngine;
using UnityEngine.UI;

public class ScoreLabelController : MonoBehaviour {

    Text _label;

    void Awake() {
        _label = GetComponent<Text>();
    }

    void Start() {
        var context = Contexts.sharedInstance.gameSession;

        context.GetGroup(GameSessionMatcher.Score).OnEntityAdded +=
            (group, entity, index, component) => updateScore(entity.score.value);

        updateScore(context.score.value);
    }

    void updateScore(int score) {
        _label.text = "Score " + score;
    }
}
