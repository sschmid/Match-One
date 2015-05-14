using Entitas;
using Entitas.CodeGenerator;

[SingleEntity]
public class GameBoardComponent : IComponent {
    public int columns;
    public int rows;
}

