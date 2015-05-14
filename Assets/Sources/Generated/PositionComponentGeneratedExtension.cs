using Entitas;

namespace Entitas {
    public partial class Entity {
        public PositionComponent position { get { return (PositionComponent)GetComponent(GameComponentIds.Position); } }

        public bool hasPosition { get { return HasComponent(GameComponentIds.Position); } }

        public void AddPosition(PositionComponent component) {
            AddComponent(GameComponentIds.Position, component);
        }

        public void AddPosition(int newX, int newY) {
            var component = new PositionComponent();
            component.x = newX;
            component.y = newY;
            AddPosition(component);
        }

        public void ReplacePosition(int newX, int newY) {
            PositionComponent component;
            if (hasPosition) {
                WillRemoveComponent(GameComponentIds.Position);
                component = position;
            } else {
                component = new PositionComponent();
            }
            component.x = newX;
            component.y = newY;
            ReplaceComponent(GameComponentIds.Position, component);
        }

        public void RemovePosition() {
            RemoveComponent(GameComponentIds.Position);
        }
    }
}

    public partial class GameMatcher {
        static AllOfMatcher _matcherPosition;

        public static AllOfMatcher Position {
            get {
                if (_matcherPosition == null) {
                    _matcherPosition = new GameMatcher(GameComponentIds.Position);
                }

                return _matcherPosition;
            }
        }
    }
