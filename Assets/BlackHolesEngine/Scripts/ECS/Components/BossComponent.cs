using UnityEngine;

namespace BlackHoles.BlackHolesEngine.Scripts.ECS.Components
{
    public struct BossComponent
    {
        public int Hp;
        public float MainY;
        public float MaxRightX;
        public float MaxLeftX;
        public Vector2 CurrentPointToMove;
    }
}