using Entitas;
using Entitas.CodeGenerator;

[Game, SingleEntity]
public sealed class GameBoardComponent : IComponent {

    public int columns;
    public int rows;
}
