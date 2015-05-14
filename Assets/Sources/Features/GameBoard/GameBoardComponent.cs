using Entitas;
using Entitas.CodeGenerator;

[Game, SingleEntity]
public class GameBoardComponent : IComponent {
    public int columns;
    public int rows;
}

