using Entitas;
using UnityEngine;
using Entitas.Blueprints;

public static class BlueprintsExtensions {

    static readonly string[] _pieces = {
        Res.Piece0,
        Res.Piece1,
        Res.Piece2,
        Res.Piece3,
        Res.Piece4,
        Res.Piece5
    };

    public static Entity CreateRandomPiece(this GameContext context, int x, int y) {
		var entity = context.CreateEntity();
        entity.ApplyBlueprint(context.blueprints.value.Piece());

        entity.AddPosition(x, y);
        entity.AddAsset(_pieces[Random.Range(0, _pieces.Length)]);

        return entity;
    }

    public static Entity CreateBlocker(this GameContext context, int x, int y) {
        var entity = context.CreateEntity();
        entity.ApplyBlueprint(context.blueprints.value.Blocker());

        entity.AddPosition(x, y);
        entity.AddAsset(Res.Blocker);
        return entity;
    }
}
