using UnityEngine;

namespace _Project.Player
{
    [CreateAssetMenu(menuName = "Create PlayerConfig", fileName = "PlayerConfig", order = 0)]
    public class PlayerConfig : ScriptableObject
    {
        public float MoveSpeed;
        public float JumpSpeed;
    }
}