using Entitas;

namespace MatchOne
{
    partial class InputContext : IContext
    {
        public static InputContext Instance
        {
            get => _instance ??= new InputContext();
            set => _instance = value;
        }

        static InputContext _instance;
    }
}
