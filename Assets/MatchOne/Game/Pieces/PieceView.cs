using DG.Tweening;
using Entitas;
using UnityEngine;

namespace MatchOne
{
    public class PieceView : View
    {
        public SpriteRenderer Sprite;
        public float DestroyDuration;

        public override void Link(Entity entity)
        {
            base.Link(entity);

            if (_linkedEntity.GetPiece().Type >= 0)
            {
                var config = ConfigContext.Instance.GetPieceColorsConfig().Value;
                Sprite.color = config.Colors[_linkedEntity.GetPiece().Type];
            }
        }

        public override void OnPositionAdded(Game.Entity entity, Vector2Int value)
        {
            transform.DOKill();
            var isTopRow = value.y == GameContext.Instance.GetBoard().Size.y - 1;
            if (isTopRow)
                transform.localPosition = new Vector3(value.x, value.y + 1);

            transform.DOMove(new Vector3(value.x, value.y, 0f), 0.3f);
        }

        protected override void OnDestroy()
        {
            var color = Sprite.color;
            color.a = 0f;
            Sprite.material.DOColor(color, DestroyDuration);
            gameObject.transform
                .DOScale(Vector3.one * 1.5f, DestroyDuration)
                .OnComplete(base.OnDestroy);
        }
    }
}
