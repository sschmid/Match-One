using Entitas;
using Entitas.CodeGeneration.Attributes;

[Unique]
public sealed class GameBoardComponent : IComponent {
    public int columns;
    public int rows;
}
