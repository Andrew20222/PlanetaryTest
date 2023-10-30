using System.Collections.Generic;
using Planetary.Interfaces;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private Planetary.Factory.System systemFactory;
    [SerializeField] private List<double> totalMass;
    private List<ISystem> _planetarySystem;
    private ISystemFactory _systemFactory;

    private void Awake()
    {
        _planetarySystem = new List<ISystem>(totalMass.Count);
        _systemFactory = systemFactory;
        CreateSystems();
    }

    private void CreateSystems()
    {
        foreach (var mass in totalMass)
        {
            var itemSystem = _systemFactory.Create(mass);
            var objectIEnumerator = itemSystem.PlanetaryObjects();
            var moveCheck = objectIEnumerator.MoveNext();
            var currentMass = (float)mass;
            while (moveCheck && currentMass != 0)
            {
                var itemObject = objectIEnumerator.Current;
                var randomMass = Random.Range(0, currentMass);
                var itemMass = itemObject.Mass;
                itemMass += randomMass;
                itemObject.Mass = itemMass;
                currentMass -= randomMass;
                moveCheck = objectIEnumerator.MoveNext();
                if (moveCheck || currentMass == 0) continue;
                objectIEnumerator.Reset();
                moveCheck = objectIEnumerator.Current != null || objectIEnumerator.MoveNext();
            }

            _planetarySystem.Add(itemSystem);
        }
    }

    private void Update()
    {
        foreach (var system in _planetarySystem)
        {
            system.UpdateSimulation(Time.deltaTime);
        }
    }
}