namespace Entitas {

    public static class GroupExtension {

        /// Creates a GroupObserver for this group.
        public static Collector CreateObserver(this Group group, GroupEvent eventType = GroupEvent.Added) {
            return new Collector(group, eventType);
        }
    }
}

