namespace Entitas {
    public partial class Entity {
        public ScoreComponent score { get { return (ScoreComponent)GetComponent(ComponentIds.Score); } }

        public bool hasScore { get { return HasComponent(ComponentIds.Score); } }

        public void AddScore(ScoreComponent component) {
            AddComponent(ComponentIds.Score, component);
        }

        public void AddScore(int newScore) {
            var component = new ScoreComponent();
            component.score = newScore;
            AddScore(component);
        }

        public void ReplaceScore(int newScore) {
            ScoreComponent component;
            if (hasScore) {
                WillRemoveComponent(ComponentIds.Score);
                component = score;
            } else {
                component = new ScoreComponent();
            }
            component.score = newScore;
            ReplaceComponent(ComponentIds.Score, component);
        }

        public void RemoveScore() {
            RemoveComponent(ComponentIds.Score);
        }
    }

    public partial class Pool {
        public Entity scoreEntity { get { return GetGroup(Matcher.Score).GetSingleEntity(); } }

        public ScoreComponent score { get { return scoreEntity.score; } }

        public bool hasScore { get { return scoreEntity != null; } }

        public Entity SetScore(ScoreComponent component) {
            if (hasScore) {
                throw new SingleEntityException(Matcher.Score);
            }
            var entity = CreateEntity();
            entity.AddScore(component);
            return entity;
        }

        public Entity SetScore(int newScore) {
            if (hasScore) {
                throw new SingleEntityException(Matcher.Score);
            }
            var entity = CreateEntity();
            entity.AddScore(newScore);
            return entity;
        }

        public Entity ReplaceScore(int newScore) {
            var entity = scoreEntity;
            if (entity == null) {
                entity = SetScore(newScore);
            } else {
                entity.ReplaceScore(newScore);
            }

            return entity;
        }

        public void RemoveScore() {
            DestroyEntity(scoreEntity);
        }
    }

    public partial class Matcher {
        static AllOfMatcher _matcherScore;

        public static AllOfMatcher Score {
            get {
                if (_matcherScore == null) {
                    _matcherScore = new Matcher(ComponentIds.Score);
                }

                return _matcherScore;
            }
        }
    }
}
