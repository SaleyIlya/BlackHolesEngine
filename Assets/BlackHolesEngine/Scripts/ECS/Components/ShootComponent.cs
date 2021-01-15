using System.Collections.Generic;
using BlackHoles.Game;
using UnityEngine;

namespace BlackHoles.BlackHolesEngine.Scripts.ECS.Components
{
    public struct ShootComponent
    {
        public Transform[] ShootPoints;
        public float ShootDelay;
        public float TimeSinceLastShoot;
        public BulletGameObject BulletPrefab;
        public Vector2 ShootDirection;
    }
}