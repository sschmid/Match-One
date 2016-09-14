using Entitas;
using Entitas.CodeGenerator;

[Core, SingleEntity]
public sealed class GameBoardComponent : IComponent {

    public int columns;
    public int rows;
}
