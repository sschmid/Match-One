using System;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraView : MonoBehaviour, IAnyBoardListener
{
    Camera _cam;

    void Start()
    {
        _cam = GetComponent<Camera>();
        var listener = Contexts.sharedInstance.game.CreateEntity();
        listener.AddAnyBoardListener(this);
    }

    public void OnAnyBoard(GameEntity entity, Vector2Int size)
    {
        _cam.orthographicSize = Math.Max(size.x, size.y) * 0.7f;
        transform.localPosition = new Vector3(
            size.x * 0.5f - 0.5f,
            size.y * 0.6f,
            -10
        );
    }
}
