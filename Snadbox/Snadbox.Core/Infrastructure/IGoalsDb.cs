namespace Snadbox.Core.Infrastructure
{
    public interface IGoalsDb
    {
        public IEnumerable<Goal> Get();
        public Goal? Create(Goal goal);
        public Goal? Get(Guid id);
        public void Update(Goal goal);
        public void Delete(Guid id);
    }
}
