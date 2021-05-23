using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "AudioClipCollection", menuName = "ScriptableObjects/Collections/AudioClipCollection")]
    public class AudioClipCollection : Collection<AudioClip>
    {
    }
}