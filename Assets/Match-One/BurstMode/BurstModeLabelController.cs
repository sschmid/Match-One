using UnityEngine;
using UnityEngine.UI;

public class BurstModeLabelController : MonoBehaviour, IAnyBurstModeListener, IAnyBurstModeRemovedListener
{
    public Text Label;

    string _text;

    void Awake() => _text = Label.text;

    void Start()
    {
        var contexts = Contexts.sharedInstance;
        var listener = contexts.input.CreateEntity();
        listener.AddAnyBurstModeListener(this);
        listener.AddAnyBurstModeRemovedListener(this);

        if (contexts.input.isBurstMode)
            OnAnyBurstMode(contexts.input.burstModeEntity);
        else
            OnAnyBurstModeRemoved(contexts.input.burstModeEntity);
    }

    public void OnAnyBurstMode(InputEntity entity) => Label.text = _text + ": on";
    public void OnAnyBurstModeRemoved(InputEntity entity) => Label.text = _text + ": off";
}
