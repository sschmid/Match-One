using Entitas;
using Entitas.CodeGeneration.Attributes;

[Event(EventTarget.Any)]
public sealed class AssetComponent : IComponent {
    public string value;
}
