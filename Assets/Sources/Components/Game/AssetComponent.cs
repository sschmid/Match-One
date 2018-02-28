using Entitas;
using Entitas.CodeGeneration.Attributes;

[Event(false)]
public sealed class AssetComponent : IComponent {
    public string value;
}
