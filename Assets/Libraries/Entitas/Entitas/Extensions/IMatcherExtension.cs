namespace Entitas {

    public static class IMatcherExtension {

        /// Convenience method to create a new TriggerOnEvent. Commonly used in IReactiveSystem and IMultiReactiveSystem.
        public static TriggerOnEvent OnEntityAdded(this IMatcher matcher) {
            return new TriggerOnEvent(matcher, GroupEvent.Added);
        }

        /// Convenience method to create a new TriggerOnEvent. Commonly used in IReactiveSystem and IMultiReactiveSystem.
        public static TriggerOnEvent OnEntityRemoved(this IMatcher matcher) {
            return new TriggerOnEvent(matcher, GroupEvent.Removed);
        }

        /// Convenience method to create a new TriggerOnEvent. Commonly used in IReactiveSystem and IMultiReactiveSystem.
        public static TriggerOnEvent OnEntityAddedOrRemoved(this IMatcher matcher) {
            return new TriggerOnEvent(matcher, GroupEvent.AddedOrRemoved);
        }
    }
}

