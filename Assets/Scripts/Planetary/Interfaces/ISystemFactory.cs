namespace Planetary.Interfaces
{
    public interface ISystemFactory
    {
       public ISystem Create(double mass);
    }
}