using Entitas;
using Entitas.Blueprints.Unity;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public sealed class BlueprintsComponent : IComponent {

    public Blueprints value;
}