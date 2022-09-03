using UnityEngine;
using UnityEngine.UI;

public class BurstModeLabelController : MonoBehaviour, IAnyBurstModeListener, IAnyBurstModeRemovedListener
{
    public Text label;

    string _text;

    void Awake()
    {
        _text = label.text;
    }

    void Start()
    {
        var contexts = Contexts.sharedInstance;
        var listener = contexts.input.CreateEntity();
        listener.AddAnyBurstModeListener(this);
        listener.AddAnyBurstModeRemovedListener(this);

        if (contexts.input.isBurstMode)
        {
            OnAnyBurstMode(contexts.input.burstModeEntity);
        }
        else
        {
            OnAnyBurstModeRemoved(contexts.input.burstModeEntity);
        }
    }

    public void OnAnyBurstMode(InputEntity entity)
    {
        label.text = _text + ": on";
    }

    public void OnAnyBurstModeRemoved(InputEntity entity)
    {
        label.text = _text + ": off";
    }
}
