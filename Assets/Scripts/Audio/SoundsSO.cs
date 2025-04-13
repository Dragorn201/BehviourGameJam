using SoundManager;
using UnityEngine;

namespace SoundManager
{
    [CreateAssetMenu(menuName = "Sounds SO", fileName = "Sounds SO")]
    public class SoundsSO : ScriptableObject
    {
        public SoundList[] sounds;
    }
}