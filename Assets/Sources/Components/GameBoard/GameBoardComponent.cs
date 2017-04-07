using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public sealed class GameBoardComponent : IComponent {

    public int columns;
    public int rows;
}
