using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChAudio : MonoBehaviour
{
    [SerializeField] private ChBase _chBase;
    public ChBase chBase
    {
        get { return _chBase != null ? _chBase : GetComponentInParent<ChBase>(); } 
        set { _chBase = value; }
    }
    private void Awake()
    {
        chBase = GetComponentInParent<ChBase>();
    }

    public void Sound(string audio)
    {
        if (chBase.isLocalPlayer)
        {
            chBase.chAnim.SpawnAnimAudio(audio);
        }
    }
}
