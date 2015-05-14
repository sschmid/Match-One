using UnityEngine;
using Entitas;
using UnityEngine.UI;

public class ScoreLabelController : MonoBehaviour {
    Text _label;

    void Start() {
        _label = GetComponent<Text>();

        var pool = Pools.gamePool;
        pool.GetGroup(Matcher.Score).OnEntityAdded += (group, entity) => updateScore(entity.score.score);
        updateScore(pool.score.score);
    }

    void updateScore(int score) {
        _label.text = "Score " + score;
    }
}
