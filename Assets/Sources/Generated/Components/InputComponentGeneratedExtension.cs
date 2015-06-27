namespace Entitas {
    public partial class Entity {
        public InputComponent input { get { return (InputComponent)GetComponent(ComponentIds.Input); } }

        public bool hasInput { get { return HasComponent(ComponentIds.Input); } }

        public Entity AddInput(InputComponent component) {
            return AddComponent(ComponentIds.Input, component);
        }

        public Entity AddInput(int newX, int newY) {
            var component = new InputComponent();
            component.x = newX;
            component.y = newY;
            return AddInput(component);
        }

        public Entity ReplaceInput(int newX, int newY) {
            InputComponent component;
            if (hasInput) {
                WillRemoveComponent(ComponentIds.Input);
                component = input;
            } else {
                component = new InputComponent();
            }
            component.x = newX;
            component.y = newY;
            return ReplaceComponent(ComponentIds.Input, component);
        }

        public Entity RemoveInput() {
            return RemoveComponent(ComponentIds.Input);
        }
    }

    public partial class Matcher {
        static AllOfMatcher _matcherInput;

        public static AllOfMatcher Input {
            get {
                if (_matcherInput == null) {
                    _matcherInput = new Matcher(ComponentIds.Input);
                }

                return _matcherInput;
            }
        }
    }
}
