using System;
using UnityEngine;
using static UnityEngine.Input;

namespace MatchOne
{
    public class InputController : MonoBehaviour
    {
        InputContext _inputContext;

        void Start()
        {
            _inputContext = InputContext.Instance;
        }

        void Update()
        {
            var input = _inputContext.HasBurstMode()
                ? GetMouseButton(0)
                : GetMouseButtonDown(0);

            if (input)
            {
                var mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePosition);
                var entity = _inputContext.CreateEntity();
                entity.AddInput(new Vector2Int(
                    (int)Math.Round(mouseWorldPos.x),
                    (int)Math.Round(mouseWorldPos.y)
                ));
            }
        }
    }
}
