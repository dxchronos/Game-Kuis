using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UI_Timer : MonoBehaviour
{
    public static event System.Action EventWaktuHabis;

    [SerializeField]
    private Slider _timeBar = null;

    [SerializeField]
    private float _waktuJawab = 25f;

    private float _sisaWaktu = 0f;
    private bool _WaktuBerjalan = true;

    public bool WaktuBerjalan
    {
        get => _WaktuBerjalan;
        set => _WaktuBerjalan = value;
    }

    private void Start()
    {
        UlangWaktu();
    }
    
    private void Update() 
    {
        if (!_WaktuBerjalan)
        return;
        _sisaWaktu -= Time.deltaTime;
        _timeBar.value = _sisaWaktu / _waktuJawab;

        if (_sisaWaktu <= 0f)
        {
            EventWaktuHabis?.Invoke();
            _WaktuBerjalan = false;
            return;
        }

        Debug.Log(_sisaWaktu);
    }

    public void UlangWaktu()
    {
        _sisaWaktu = _waktuJawab;
    }

}
