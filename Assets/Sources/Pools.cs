using Entitas;
using Entitas.Unity.VisualDebugging;

public static class Pools {

    static Pool _gamePool;

    public static Pool gamePool { 
        get {
            if (_gamePool == null) {
                #if (UNITY_EDITOR)
                _gamePool = new DebugPool(ComponentIds.TotalComponents, "Game Pool");
                #else
                _gamePool = new Pool(ComponentIds.TotalComponents);
                #endif
            }
            return _gamePool;
        }
    }
}

