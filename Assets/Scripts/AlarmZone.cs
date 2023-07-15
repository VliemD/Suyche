using UnityEngine;

[RequireComponent(typeof(ControlSound))]
public class AlarmZone: MonoBehaviour
{
    private ControlSound _sound;

    private void Start()
    {
        _sound = GetComponent<ControlSound>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<ControlTester>())
            _sound.IncreaseVolume();        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<ControlTester>())
            _sound.DecreaseVolume();        
    }    
}
