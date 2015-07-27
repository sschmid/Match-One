using System.Collections.Generic;

namespace Entitas {
    public partial class Entity {
        public ViewComponent view { get { return (ViewComponent)GetComponent(ComponentIds.View); } }

        public bool hasView { get { return HasComponent(ComponentIds.View); } }

        static readonly Stack<ViewComponent> _viewComponentPool = new Stack<ViewComponent>();

        public static void ClearViewComponentPool() {
            _viewComponentPool.Clear();
        }

        public Entity AddView(UnityEngine.GameObject newGameObject) {
            var component = _viewComponentPool.Count > 0 ? _viewComponentPool.Pop() : new ViewComponent();
            component.gameObject = newGameObject;
            return AddComponent(ComponentIds.View, component);
        }

        public Entity ReplaceView(UnityEngine.GameObject newGameObject) {
            var previousComponent = view;
            var component = _viewComponentPool.Count > 0 ? _viewComponentPool.Pop() : new ViewComponent();
            component.gameObject = newGameObject;
            ReplaceComponent(ComponentIds.View, component);
            if (previousComponent != null) {
                _viewComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemoveView() {
            var component = view;
            RemoveComponent(ComponentIds.View);
            _viewComponentPool.Push(component);
            return this;
        }
    }

    public partial class Matcher {
        static AllOfMatcher _matcherView;

        public static AllOfMatcher View {
            get {
                if (_matcherView == null) {
                    _matcherView = new Matcher(ComponentIds.View);
                }

                return _matcherView;
            }
        }
    }
}
