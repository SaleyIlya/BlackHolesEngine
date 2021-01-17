using UnityEngine;

namespace BlackHoles.BlackHolesEngine.Scripts.ECS.Components
{
    public struct SpawnComponent
    {
        public Vector2 SpawnPoint;
        public float TimeToSpawn;
        public GameObject ObjectToSpawn;
    }
}