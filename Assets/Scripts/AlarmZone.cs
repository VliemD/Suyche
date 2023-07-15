using UnityEngine;

[RequireComponent(typeof(Sound))]
public class AlarmZone: MonoBehaviour
{
    private Sound _sound;

    private void Start()
    {
        _sound = GetComponent<Sound>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<TesterInput>())
            _sound.IncreaseVolume();        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<TesterInput>())
            _sound.DecreaseVolume();        
    }    
}
