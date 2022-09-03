//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public AnyBoardListenerComponent anyBoardListener { get { return (AnyBoardListenerComponent)GetComponent(GameComponentsLookup.AnyBoardListener); } }
    public bool hasAnyBoardListener { get { return HasComponent(GameComponentsLookup.AnyBoardListener); } }

    public void AddAnyBoardListener(System.Collections.Generic.List<IAnyBoardListener> newValue) {
        var index = GameComponentsLookup.AnyBoardListener;
        var component = (AnyBoardListenerComponent)CreateComponent(index, typeof(AnyBoardListenerComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceAnyBoardListener(System.Collections.Generic.List<IAnyBoardListener> newValue) {
        var index = GameComponentsLookup.AnyBoardListener;
        var component = (AnyBoardListenerComponent)CreateComponent(index, typeof(AnyBoardListenerComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveAnyBoardListener() {
        RemoveComponent(GameComponentsLookup.AnyBoardListener);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherAnyBoardListener;

    public static Entitas.IMatcher<GameEntity> AnyBoardListener {
        get {
            if (_matcherAnyBoardListener == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.AnyBoardListener);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherAnyBoardListener = matcher;
            }

            return _matcherAnyBoardListener;
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public void AddAnyBoardListener(IAnyBoardListener value) {
        var listeners = hasAnyBoardListener
            ? anyBoardListener.value
            : new System.Collections.Generic.List<IAnyBoardListener>();
        listeners.Add(value);
        ReplaceAnyBoardListener(listeners);
    }

    public void RemoveAnyBoardListener(IAnyBoardListener value, bool removeComponentWhenEmpty = true) {
        var listeners = anyBoardListener.value;
        listeners.Remove(value);
        if (removeComponentWhenEmpty && listeners.Count == 0) {
            RemoveAnyBoardListener();
        } else {
            ReplaceAnyBoardListener(listeners);
        }
    }
}