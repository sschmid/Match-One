using System;
using MatchOne.Game;
using UnityEngine;

namespace MatchOne
{
    [RequireComponent(typeof(Camera))]
    public class CameraView : MonoBehaviour, IMatchOneGameAnyBoardAddedListener
    {
        Camera _cam;

        void Start()
        {
            _cam = GetComponent<Camera>();
            GameContext.Instance.CreateEntity().AddAnyBoardAddedListener(this);
        }

        public void OnAnyBoardAdded(Entity entity, Vector2Int size)
        {
            _cam.orthographicSize = Math.Max(size.x, size.y) * 0.7f;
            transform.localPosition = new Vector3(
                size.x * 0.5f - 0.5f,
                size.y * 0.6f,
                -10
            );
        }
    }
}
