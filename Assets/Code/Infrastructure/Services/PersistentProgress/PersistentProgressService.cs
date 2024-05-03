using Data;

namespace Services.PersistentProgress
{
    public class PersistentProgressService : IPersistentProgressService
    {
        public Progress Progress { get; set; }
    }
}
