using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Star"))
        {
            SFXManager.instance.ShowStarParticles(other.gameObject);
            AudioManager.instance.PlaySoundStarPickup(other.gameObject);
            Destroy(other.gameObject);
            LevelManager.instance.IncrementStarCount();
        }
}   }
