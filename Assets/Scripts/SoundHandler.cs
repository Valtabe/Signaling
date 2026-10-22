using UnityEngine;

public class SoundHandler : MonoBehaviour
{
    [SerializeField] private float _changeRate;

    public void ChangeSoundVolumeSmoothly(AudioSource sound, float targetVolume) =>
        sound.volume = Mathf.MoveTowards(sound.volume, targetVolume, _changeRate * Time.deltaTime);
}
