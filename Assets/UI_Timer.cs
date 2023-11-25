using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UI_Timer : MonoBehaviour
{
    [SerializeField]
    private UI_PesanLevel _tempatPesan = null;

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
            _tempatPesan.Pesan = "TIME UP!!";
            _tempatPesan.gameObject.SetActive(true);
            //Debug.Log("Time Up");
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
