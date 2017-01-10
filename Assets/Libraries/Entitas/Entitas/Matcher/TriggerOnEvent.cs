namespace Entitas {

    public struct TriggerOnEvent {

        public IMatcher trigger;
        public GroupEvent eventType;

        public TriggerOnEvent(IMatcher trigger, GroupEvent eventType) {
            this.trigger = trigger;
            this.eventType = eventType;
        }
    }
}

