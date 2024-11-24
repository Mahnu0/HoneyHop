using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySounds : MonoBehaviour
{
    public AudioClip explosion;

    private void Start()
    {
        
    }

    public void Jump()
    {
        SFXManager.instance.PlaySFX(explosion, transform, 1f);
    }
}
