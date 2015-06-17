using UnityEngine;

public class InputController : MonoBehaviour {

    public bool burstMode;

    void Update() {
        if (Input.GetKeyDown("b")) {
            burstMode = !burstMode;
        }

        var input = false;
        if (burstMode) {
            input = Input.GetMouseButton(0);
        } else {
            input = Input.GetMouseButtonDown(0);
        }
        if (input) {
            var hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 100);
            if (hit.collider != null) {
                var pos = hit.collider.transform.position;
                Pools.gamePool.CreateEntity()
                    .AddInput((int)pos.x, (int)pos.y);
            }
        } 
    }
}
