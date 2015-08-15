using UnityEngine;
using Entitas;
using UnityEngine.UI;

public class ScoreLabelController : MonoBehaviour {
    Text _label;

    void Start() {
        _label = GetComponent<Text>();

        var pool = Pools.pool;
        pool.GetGroup(Matcher.Score).OnEntityAdded += (group, entity, index, component) => updateScore(entity.score.value);
        updateScore(pool.score.value);
    }

    void updateScore(int score) {
        _label.text = "Score " + score;
    }
}
