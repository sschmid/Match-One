using UnityEngine;

public class InputController : MonoBehaviour {

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            var hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 100);
            if (hit.collider != null) {
                var pos = hit.collider.transform.position;
                Pools.gamePool.CreateEntity()
                    .AddInput((int)pos.x, (int)pos.y);
            }
        } 
    }
}
