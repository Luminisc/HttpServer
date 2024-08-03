namespace Snadbox.Core.Infrastructure
{
    public class GoalsDb : IGoalsDb
    {
        private static readonly List<Goal> Goals =
        [
            new Goal() { Id = Guid.NewGuid(), Title = "Read tasks", Description = "Read them harder" },
            new Goal() { Id = Guid.NewGuid(), Title = "Create new tasks", Description = "Create them better" },
            new Goal() { Id = Guid.NewGuid(), Title = "Edit some tasks", Description = "Edit faster" },
            new Goal() { Id = Guid.NewGuid(), Title = "Delete some of them", Description = "Delete them stronger" },
        ];

        public Goal Create(Goal goal)
        {
            goal.Id = Guid.NewGuid();
            Goals.Add(goal);
            return goal;
        }

        public void Delete(Guid id) => Goals.RemoveAll(x => x.Id == id);

        public Goal? Get(Guid id) => Goals.FirstOrDefault(x => x.Id == id);

        public IEnumerable<Goal> Get() => Goals;

        public void Update(Goal goal)
        {
            var index = Goals.FindIndex(x => x.Id == goal.Id);
            if (index >= 0)
                Goals[index] = goal;
        }
    }
}
