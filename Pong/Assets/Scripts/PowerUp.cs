using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private PowerupEffect powerupEffect;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
        PowerUpSpawner.Instance.currentInstanceAmount--;
        powerupEffect.Apply(other.gameObject);
    }
}
