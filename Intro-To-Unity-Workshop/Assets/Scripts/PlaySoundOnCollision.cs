using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnCollision : MonoBehaviour
{
    [SerializeField]
    private AudioClip sound;

    private void OnCollisionEnter(Collision collision)
    {
        if (sound == null)
        {
            return;
        }
        AudioSource.PlayClipAtPoint(sound, transform.position);
    }
}
