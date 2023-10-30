using System.Collections;
using System.Collections.Generic;
using Planetary.Interfaces;
using UnityEngine;

namespace Planetary.System
{
    public class Controller : MonoBehaviour, ISystem, IEnumerable<IObject>
    {
        [SerializeField] private Object prefab;
        private List<Object> _planetaryObjects;

        private void Awake()
        {
            _planetaryObjects = new List<Object>();
            var randomCountObjects = Random.Range(2, 7);
            for (var i = 0; i < randomCountObjects; i++)
            {
                var item = Instantiate(prefab);
                item.SetSystemCenter(transform);
                _planetaryObjects.Add(item);
            }
        }

        public void UpdateSimulation(float deltaTime)
        {
            foreach (var planeteryObject in _planetaryObjects)
            {
                planeteryObject.Move(deltaTime);
            }
        }
        

        public IEnumerator<IObject> PlanetaryObjects()
        {
            return GetEnumerator();
        }

        public IEnumerator<IObject> GetEnumerator()
        {
            return _planetaryObjects.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}