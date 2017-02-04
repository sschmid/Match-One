using Entitas;
using Entitas.Unity.Blueprints;
using Entitas.CodeGenerator.Api;

[Game, Unique]
public sealed class BlueprintsComponent : IComponent {

    public Blueprints value;
}