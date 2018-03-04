using UnityEngine;
using UnityEngine.UI;

public class BurstModeLabelController : MonoBehaviour, IBurstModeListener, IBurstModeRemovedListener {

    public Text label;

    string _text;

    void Awake() {
        _text = label.text;
    }

    void Start() {
        var contexts = Contexts.sharedInstance;
        var listener = contexts.input.CreateEntity();
        listener.AddBurstModeListener(this);
        listener.AddBurstModeRemovedListener(this);

        if (contexts.input.isBurstMode) {
            OnBurstMode(contexts.input.burstModeEntity);
        } else {
            OnBurstModeRemoved(contexts.input.burstModeEntity);
        }
    }

    public void OnBurstMode(InputEntity entity) {
        label.text = _text + ": on";
    }

    public void OnBurstModeRemoved(InputEntity entity) {
        label.text = _text + ": off";
    }
}
