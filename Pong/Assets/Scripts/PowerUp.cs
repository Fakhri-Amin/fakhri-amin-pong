using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private PowerupEffect powerupEffect;
    [SerializeField] private GameObject explosionVFX;
    private void OnTriggerEnter2D(Collider2D other)
    {
        PowerUpSpawner.Instance.currentInstanceAmount--;
        powerupEffect.Apply(other.gameObject);
        var vfx = Instantiate(explosionVFX, transform.position, Quaternion.identity);
        Destroy(vfx, 2f);
        Destroy(gameObject);
    }
}
