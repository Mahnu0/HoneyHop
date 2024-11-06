using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySounds : MonoBehaviour
{
    [SerializeField] private AudioClip explosion;

    private void Start()
    {
        
    }

    public void Explosion()
    {
        SFXManager.instance.PlaySFX(explosion, transform, 1f);
    }
}
