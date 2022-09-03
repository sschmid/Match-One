using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BurstModeButtonController : MonoBehaviour, IAnyBurstModeListener, IAnyBurstModeRemovedListener
{
    public Button Button;
    public TMP_Text Label;

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

        Button.onClick.AddListener(() => contexts.input.isBurstMode = !contexts.input.isBurstMode);
    }

    public void OnAnyBurstMode(InputEntity entity) => Label.text = "Burst Mode: on";
    public void OnAnyBurstModeRemoved(InputEntity entity) => Label.text = "Burst Mode: off";
}
