using Entitas;
using Entitas.CodeGenerator;

[Game, SingleEntity]
public class GameBoardCacheComponent : IComponent {
    public Entity[,] grid;
}

