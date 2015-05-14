namespace Entitas {
    public partial class Entity {
        public ViewComponent view { get { return (ViewComponent)GetComponent(ComponentIds.View); } }

        public bool hasView { get { return HasComponent(ComponentIds.View); } }

        public void AddView(ViewComponent component) {
            AddComponent(ComponentIds.View, component);
        }

        public void AddView(UnityEngine.GameObject newGameObject) {
            var component = new ViewComponent();
            component.gameObject = newGameObject;
            AddView(component);
        }

        public void ReplaceView(UnityEngine.GameObject newGameObject) {
            ViewComponent component;
            if (hasView) {
                WillRemoveComponent(ComponentIds.View);
                component = view;
            } else {
                component = new ViewComponent();
            }
            component.gameObject = newGameObject;
            ReplaceComponent(ComponentIds.View, component);
        }

        public void RemoveView() {
            RemoveComponent(ComponentIds.View);
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
