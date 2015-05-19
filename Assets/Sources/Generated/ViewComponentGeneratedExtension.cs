namespace Entitas {
    public partial class Entity {
        public ViewComponent view { get { return (ViewComponent)GetComponent(ComponentIds.View); } }

        public bool hasView { get { return HasComponent(ComponentIds.View); } }

        public Entity AddView(ViewComponent component) {
            return AddComponent(ComponentIds.View, component);
        }

        public Entity AddView(UnityEngine.GameObject newGameObject) {
            var component = new ViewComponent();
            component.gameObject = newGameObject;
            return AddView(component);
        }

        public Entity ReplaceView(UnityEngine.GameObject newGameObject) {
            ViewComponent component;
            if (hasView) {
                WillRemoveComponent(ComponentIds.View);
                component = view;
            } else {
                component = new ViewComponent();
            }
            component.gameObject = newGameObject;
            return ReplaceComponent(ComponentIds.View, component);
        }

        public Entity RemoveView() {
            return RemoveComponent(ComponentIds.View);
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
