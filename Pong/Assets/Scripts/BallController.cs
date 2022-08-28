using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float extraSpeed = 1.5f;
    [SerializeField] private float maxSpeed = 15f;
    [SerializeField] private GameObject bumpVFXPrefab;

    public bool isLeftPaddleTurn;
    private Rigidbody2D rig;
    private int hitCounter;
    private float startSpeed;


    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        startSpeed = moveSpeed;
        StartCoroutine(LaunchBall());
    }

    public IEnumerator LaunchBall()
    {
        RestartBall();
        hitCounter = 0;
        yield return new WaitForSeconds(1f);
        if (isLeftPaddleTurn)
        {
            MoveBall(new Vector2(1f, 0f));
        }
        else
        {
            MoveBall(new Vector2(-1f, 0f));
        }
    }

    public void MoveBall(Vector2 direction)
    {
        direction = direction.normalized;
        moveSpeed = moveSpeed + hitCounter * extraSpeed;
        moveSpeed = Mathf.Clamp(moveSpeed, startSpeed, maxSpeed);
        rig.velocity = direction * moveSpeed;
    }

    private void BounceBall(Collision2D other)
    {
        Vector3 ballPosition = transform.position;
        Vector3 paddlePosition = other.transform.position;
        float paddleHeight = other.collider.bounds.size.y;

        float positionX = other.gameObject.CompareTag("RightPaddle") ? 1 : -1;

        float positionY = (ballPosition.y - paddlePosition.y) / paddleHeight;

        hitCounter++;

        MoveBall(new Vector2(positionX, positionY));
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("RightPaddle") || other.gameObject.CompareTag("LeftPaddle"))
        {
            BounceBall(other);
        }

        var bumpVFX = Instantiate(bumpVFXPrefab, transform.position, Quaternion.identity);
        Destroy(bumpVFX, 1f);
    }

    private void RestartBall()
    {
        moveSpeed = startSpeed;
        rig.velocity = new Vector2(0, 0);
        transform.position = new Vector2(0, 0);
    }
}
