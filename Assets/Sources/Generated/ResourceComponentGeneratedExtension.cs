namespace Entitas {
    public partial class Entity {
        public ResourceComponent resource { get { return (ResourceComponent)GetComponent(ComponentIds.Resource); } }

        public bool hasResource { get { return HasComponent(ComponentIds.Resource); } }

        public void AddResource(ResourceComponent component) {
            AddComponent(ComponentIds.Resource, component);
        }

        public void AddResource(string newName) {
            var component = new ResourceComponent();
            component.name = newName;
            AddResource(component);
        }

        public void ReplaceResource(string newName) {
            ResourceComponent component;
            if (hasResource) {
                WillRemoveComponent(ComponentIds.Resource);
                component = resource;
            } else {
                component = new ResourceComponent();
            }
            component.name = newName;
            ReplaceComponent(ComponentIds.Resource, component);
        }

        public void RemoveResource() {
            RemoveComponent(ComponentIds.Resource);
        }
    }

    public partial class Matcher {
        static AllOfMatcher _matcherResource;

        public static AllOfMatcher Resource {
            get {
                if (_matcherResource == null) {
                    _matcherResource = new Matcher(ComponentIds.Resource);
                }

                return _matcherResource;
            }
        }
    }
}
