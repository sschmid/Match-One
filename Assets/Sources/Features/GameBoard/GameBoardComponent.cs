using Entitas;
using Entitas.CodeGenerator.Api;

[Game, Unique]
public sealed class GameBoardComponent : IComponent {

    public int columns;
    public int rows;
}
