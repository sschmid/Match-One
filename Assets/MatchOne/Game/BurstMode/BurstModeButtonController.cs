using MatchOne.Input;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MatchOne
{
    public class BurstModeButtonController : MonoBehaviour, IMatchOneInputAnyBurstModeAddedListener, IMatchOneInputAnyBurstModeRemovedListener
    {
        public Button Button;
        public TMP_Text Label;

        void Start()
        {
            var inputContext = InputContext.Instance;

            inputContext.CreateEntity()
                .AddAnyBurstModeAddedListener(this)
                .AddAnyBurstModeRemovedListener(this);

            if (inputContext.HasBurstMode())
                OnAnyBurstModeAdded(inputContext.GetBurstModeEntity());
            else
                OnAnyBurstModeRemoved(inputContext.GetBurstModeEntity());

            Button.onClick.AddListener(() =>
            {
                if (inputContext.HasBurstMode())
                    inputContext.UnsetBurstMode();
                else
                    inputContext.SetBurstMode();
            });
        }

        public void OnAnyBurstModeAdded(Entity entity)
        {
            Label.text = "Burst Mode: on";
        }

        public void OnAnyBurstModeRemoved(Entity entity)
        {
            Label.text = "Burst Mode: off";
        }
    }
}
