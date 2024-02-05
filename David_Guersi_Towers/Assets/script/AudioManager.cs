using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //shooting
    [SerializeField] AudioClip shootingClip;
    [SerializeField] [Range(0f, 1f)] float shootingVolume = 1f;

    //EnemyHitted
    [SerializeField] AudioClip Hitted;
    [SerializeField] [Range(0f, 1f)] float casualExplosionVolume;

    //EnemyDeath
    [SerializeField] AudioClip enemyDeath;
    [SerializeField] [Range(0f, 1f)] float explosionVolume;

    public void PlayShootingClip()
    {
        PlayClip(shootingClip, shootingVolume);
    }

    public void CasualExplosion()
    {
        PlayClip(Hitted, casualExplosionVolume);
    }

    public void PlayerExplosion()
    {
        PlayClip(enemyDeath, explosionVolume);
        
    }

    void PlayClip(AudioClip clip, float volume)
    {
        Vector3 cameraPos = Camera.main.transform.position;
        AudioSource.PlayClipAtPoint(clip, cameraPos, volume);
    }
}
