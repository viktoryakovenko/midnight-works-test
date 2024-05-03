using Data;

namespace Services.PersistentProgress
{
    public interface IPersistentProgressService
    {
        public Progress Progress { get; set; }
    }
}
