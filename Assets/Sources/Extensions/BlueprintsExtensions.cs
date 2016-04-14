using Entitas;
using UnityEngine;

namespace Entitas.Unity.Serialization.Blueprints {

    public partial class Blueprints {

        static readonly string[] _pieces = {
            Res.Piece0,
            Res.Piece1,
            Res.Piece2,
            Res.Piece3,
            Res.Piece4,
            Res.Piece5
        };

        public Entity ApplyPiece(Entity entity, int x, int y) {
            return entity
                .ApplyBlueprint(Piece)
                .AddPosition(x, y)
                .AddResource(_pieces[Random.Range(0, _pieces.Length)]);
        }

        public Entity ApplyBlocker(Entity entity, int x, int y) {
            return entity
                .ApplyBlueprint(Blocker)
                .AddPosition(x, y);
        }
    }
}