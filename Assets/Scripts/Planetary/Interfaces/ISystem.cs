using System.Collections.Generic;

namespace Planetary.Interfaces
{
    public interface ISystem
    {
        public IEnumerator<IObject> PlanetaryObjects();
        void UpdateSimulation(float deltaTime);
    }
}