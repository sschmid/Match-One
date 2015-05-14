using UnityEngine;

public class InputController : MonoBehaviour {

    public LayerMask layerMask;

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            var hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 100, layerMask);
            if (hit.collider != null) {
                var pos = hit.collider.transform.position;
                var e = Pools.gamePool.CreateEntity();
                e.AddInput((int)pos.x, (int)pos.y);
            }
        } 
    }
}
