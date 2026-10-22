using System.Collections;
using UnityEngine;

[RequireComponent (typeof(Collider2D))]
public class Alarm : MonoBehaviour
{
    [SerializeField] private int _thiefCounter;
    [SerializeField] private AudioSource _signalingAudio;
    [SerializeField] private SoundHandler _soundHandler;

    private float _maximumVolume = 1.0f;
    private float _minimumVolume = 0.0f;

    private Coroutine _alarmCoroutime;

    private void Start()
    {
        _thiefCounter = 0;
    }

    private void OnTriggerEnter2D(Collider2D enteredObject)
    {
        if (enteredObject.TryGetComponent<Thief>(out Thief thief))
        {
            _thiefCounter++;

            if (_thiefCounter > 0)
            {
                SwitchAlarm(_maximumVolume);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D exitedObject)
    {
        if (exitedObject.TryGetComponent<Thief>(out Thief thief))
        {
            _thiefCounter--;

            if (_thiefCounter == 0)
            {
                SwitchAlarm(_minimumVolume);
            }
        }
    }

    private void SwitchAlarm(float targetVolume)
    {
        if (_alarmCoroutime != null)
        {
            StopCoroutine(_alarmCoroutime);
        }  

        _alarmCoroutime = StartCoroutine(SwitchAlarmSound(targetVolume));
    }

    private IEnumerator SwitchAlarmSound(float targetVolume)
    {
        while (_signalingAudio.volume != targetVolume)
        {
            _soundHandler.ChangeSoundVolumeSmoothly(_signalingAudio, targetVolume );

            yield return null;
        }

        _alarmCoroutime = null;
    }
}
