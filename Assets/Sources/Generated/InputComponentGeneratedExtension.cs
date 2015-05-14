namespace Entitas {
    public partial class Entity {
        public InputComponent input { get { return (InputComponent)GetComponent(ComponentIds.Input); } }

        public bool hasInput { get { return HasComponent(ComponentIds.Input); } }

        public void AddInput(InputComponent component) {
            AddComponent(ComponentIds.Input, component);
        }

        public void AddInput(int newX, int newY) {
            var component = new InputComponent();
            component.x = newX;
            component.y = newY;
            AddInput(component);
        }

        public void ReplaceInput(int newX, int newY) {
            InputComponent component;
            if (hasInput) {
                WillRemoveComponent(ComponentIds.Input);
                component = input;
            } else {
                component = new InputComponent();
            }
            component.x = newX;
            component.y = newY;
            ReplaceComponent(ComponentIds.Input, component);
        }

        public void RemoveInput() {
            RemoveComponent(ComponentIds.Input);
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
