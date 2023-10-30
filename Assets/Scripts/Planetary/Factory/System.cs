using Planetary.Interfaces;
using Planetary.System;
using UnityEngine;

namespace Planetary.Factory
{
    public class System : MonoBehaviour, ISystemFactory
    {
        [SerializeField] private Controller prefab;

        public ISystem Create(double mass)
        {
            return Instantiate(prefab);
        }
    }
}