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
    }

    public partial class Matcher {
        static AllOfMatcher _matcherDestroy;

        public static AllOfMatcher Destroy {
            get {
                if (_matcherDestroy == null) {
                    _matcherDestroy = new Matcher(ComponentIds.Destroy);
                }

                return _matcherDestroy;
            }
        }
    }
}
