using Entitas;
using Entitas.CodeGenerator;

[SingleEntity]
public class GameBoardCacheComponent : IComponent {
    public Entity[,] grid;
}

