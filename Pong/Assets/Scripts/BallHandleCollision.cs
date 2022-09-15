using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallHandleCollision : MonoBehaviour
{
    [SerializeField] private GameObject bumpVFXPrefab;

    private BallController ballController;

    private void Awake()
    {
        ballController = GetComponent<BallController>();
    }

    private void Start()
    {

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        var bumpVFX = Instantiate(bumpVFXPrefab, transform.position, Quaternion.identity);
        Destroy(bumpVFX, 1f);

        if (other.gameObject.CompareTag("RightPaddle") || other.gameObject.CompareTag("LeftPaddle"))
        {
            ballController.BounceBall(other);
            MusicManager.Instance.PlayKickSFX();
            return;
        }

        MusicManager.Instance.PlayWallSFX();

    }
}
