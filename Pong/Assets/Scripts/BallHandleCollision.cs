using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallHandleCollision : MonoBehaviour
{
    [SerializeField] private GameObject bumpVFXPrefab;
    [SerializeField] private ParticleSystem sizeDownVFX;
    [SerializeField] private ParticleSystem sizeUpVFX;
    private BallController ballController;

    private void Awake()
    {
        ballController = GetComponent<BallController>();
    }

    private void Start()
    {
        sizeDownVFX.Stop();
        sizeUpVFX.Stop();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("RightPaddle") || other.gameObject.CompareTag("LeftPaddle"))
        {
            ballController.BounceBall(other);
        }

        var bumpVFX = Instantiate(bumpVFXPrefab, transform.position, Quaternion.identity);
        Destroy(bumpVFX, 1f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Buff"))
        {
            sizeUpVFX.Play();
        }

        if (other.gameObject.CompareTag("Debuff"))
        {
            sizeDownVFX.Play();
        }
    }
}
