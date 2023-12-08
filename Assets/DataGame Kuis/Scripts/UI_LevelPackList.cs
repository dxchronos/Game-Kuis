using UnityEngine;

public class UI_LevelPackList : MonoBehaviour
{
    [SerializeField] 
    private InisialDataGameplay _inisialData = null;

    [SerializeField] 
    private UI_LevelKuisList _levelList = null;

    [SerializeField] 
    private UI_OpsiLevelPack _tombolLevelPack = null;

    [SerializeField] 
    private RectTransform _content = null;

    [Space, SerializeField] 
    private LevelPackKuis[] _levelPacks = new LevelPackKuis[0];

    private void Start() 
    {
        LoadLevelPack();

        if  (_inisialData.SaatKalah)
        {
            UI_OpsiLevelPack_EventSaatKlik(_inisialData.levelPack);
        }

        UI_OpsiLevelPack.EventSaatKlik += UI_OpsiLevelPack_EventSaatKlik;
    }

    private void OnDestroy() 
    {
        UI_OpsiLevelPack.EventSaatKlik -= UI_OpsiLevelPack_EventSaatKlik;
    }

    private void UI_OpsiLevelPack_EventSaatKlik(LevelPackKuis levelPack)
    {
        _levelList.gameObject.SetActive(true);
        _levelList.UnloadLevelPack(levelPack);
        gameObject.SetActive(false);
        _inisialData.levelPack = levelPack;
    }
    private void LoadLevelPack()
    {
        foreach (var lp in _levelPacks)
        {
            //Membuat salinan objek dari prefab tombol level pack
            var t = Instantiate(_tombolLevelPack);

            t.SetLevelPack(lp);

            //Input objek tombol sebagai child objek "content"
            t.transform.SetParent(_content);
            t.transform.localScale = Vector3.one;
        }
    }
}