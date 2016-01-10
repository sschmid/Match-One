namespace Entitas {
    public partial class Entity {
        static readonly DestroyComponent destroyComponent = new DestroyComponent();

        public bool isDestroy {
            get { return HasComponent(ComponentIds.Destroy); }
            set {
                if (value != isDestroy) {
                    if (value) {
                        AddComponent(ComponentIds.Destroy, destroyComponent);
                    } else {
                        RemoveComponent(ComponentIds.Destroy);
                    }
                }
            }
        }

        public Entity IsDestroy(bool value) {
            isDestroy = value;
            return this;
        }
    }

    public partial class Matcher {
        static IMatcher _matcherDestroy;

        public static IMatcher Destroy {
            get {
                if (_matcherDestroy == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.Destroy);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherDestroy = matcher;
                }

                return _matcherDestroy;
            }
        }
    }
}
