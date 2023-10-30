using Planetary.Enums;

namespace Planetary.Interfaces
{
    public interface IObject
    {
        MassClass MassClass { get; }
        double Mass { get; set; }
    }
}