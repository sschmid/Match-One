using Entitas;

namespace Entitas {
    public partial class Entity {
        public ResourceComponent resource { get { return (ResourceComponent)GetComponent(GameComponentIds.Resource); } }

        public bool hasResource { get { return HasComponent(GameComponentIds.Resource); } }

        public void AddResource(ResourceComponent component) {
            AddComponent(GameComponentIds.Resource, component);
        }

        public void AddResource(string newName) {
            var component = new ResourceComponent();
            component.name = newName;
            AddResource(component);
        }

        public void ReplaceResource(string newName) {
            ResourceComponent component;
            if (hasResource) {
                WillRemoveComponent(GameComponentIds.Resource);
                component = resource;
            } else {
                component = new ResourceComponent();
            }
            component.name = newName;
            ReplaceComponent(GameComponentIds.Resource, component);
        }

        public void RemoveResource() {
            RemoveComponent(GameComponentIds.Resource);
        }
    }
}

    public partial class GameMatcher {
        static AllOfMatcher _matcherResource;

        public static AllOfMatcher Resource {
            get {
                if (_matcherResource == null) {
                    _matcherResource = new GameMatcher(GameComponentIds.Resource);
                }

                return _matcherResource;
            }
        }
    }
