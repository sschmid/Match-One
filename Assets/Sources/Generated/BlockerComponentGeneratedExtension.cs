namespace Entitas {
    public partial class Entity {
        static readonly BlockerComponent blockerComponent = new BlockerComponent();

        public bool isBlocker {
            get { return HasComponent(ComponentIds.Blocker); }
            set {
                if (value != isBlocker) {
                    if (value) {
                        AddComponent(ComponentIds.Blocker, blockerComponent);
                    } else {
                        RemoveComponent(ComponentIds.Blocker);
                    }
                }
            }
        }
    }

    public partial class Matcher {
        static AllOfMatcher _matcherBlocker;

        public static AllOfMatcher Blocker {
            get {
                if (_matcherBlocker == null) {
                    _matcherBlocker = new Matcher(ComponentIds.Blocker);
                }

                return _matcherBlocker;
            }
        }
    }
}
