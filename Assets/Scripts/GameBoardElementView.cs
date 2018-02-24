using DG.Tweening;
using UnityEngine;

public class GameBoardElementView : View {

    public SpriteRenderer sprite;

    public override void Hide() {
        var color = sprite.color;
        color.a = 0f;
        sprite.material.DOColor(color, 0.2f);
        gameObject.transform
            .DOScale(Vector3.one * 1.5f, 0.2f)
            .OnComplete(onHidden);
    }

    public override void OnPosition(GameEntity entity, IntVector2 value) {
        var isTopRow = value.y == Contexts.sharedInstance.game.gameBoard.rows - 1;
        if (isTopRow) {
            transform.localPosition = new Vector3(value.x, value.y + 1);
        }

        transform.DOMove(new Vector3(value.x, value.y, 0f), 0.3f);
    }
}
