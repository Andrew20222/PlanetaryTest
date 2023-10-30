using Planetary.Enums;
using Planetary.Interfaces;
using UnityEngine;

namespace Planetary
{
    public class Object : MonoBehaviour, IObject
    {
        [field: SerializeField] public MassClass MassClass { get; private set; }
        private double _mass;
        private Transform _cachedCenter;
        private float _radius;
        private float _angle;
        public void SetSystemCenter(Transform value) => _cachedCenter = value;

        public double Mass
        {
            get => _mass;
            set
            {
                if (value <= 0.00001)
                {
                    MassClass = MassClass.Asteroidan;
                    _radius = Random.Range(0, 0.03f);
                }
                else if (value is > 0.00001 and <= 0.1)
                {
                    MassClass = MassClass.Mercurian;
                    _radius = Random.Range(0.03f, 0.7f);
                }
                else if (value is > 0.1 and <= 0.5)
                {
                    MassClass = MassClass.Subterran;
                    _radius = Random.Range(0.5f, 1.2f);
                }
                else if (value is > 0.5 and <= 2)
                {
                    MassClass = MassClass.Terran;
                    _radius = Random.Range(0.8f, 1.9f);
                }
                else if (value is > 2 and <= 10)
                {
                    MassClass = MassClass.Superterran;
                    _radius = Random.Range(1.3f, 3.3f);
                }
                else if (value is > 10 and <= 50)
                {
                    MassClass = MassClass.Neptunian;
                    _radius = Random.Range(2.1f, 5.7f);
                }
                else if (value is > 50 and <= 5000)
                {
                    MassClass = MassClass.Jovian;
                    _radius = Random.Range(3.5f, 27f);
                }

                transform.localScale = Vector3.one * (float)value / 5f;
                _mass = value;
            }
        }

        public void Move(float deltaTime)
        {
            var speed = _radius;
            var cachedPosition = _cachedCenter.position;
            _angle += deltaTime;
            var x = Mathf.Cos(_angle * speed) * _radius;
            var y = Mathf.Sin(_angle * speed) * _radius;
            var position = cachedPosition - new Vector3(x, y, 0);
            position.z = cachedPosition.z;
            transform.position = position;
        }
    }
}