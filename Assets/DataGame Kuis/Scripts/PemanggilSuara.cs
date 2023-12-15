using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PemanggilSuara : MonoBehaviour
{
    public void PanggilSuara(AudioClip clip)
    {
        AudioManager.instance.PlaySFX(clip);
    }
}
