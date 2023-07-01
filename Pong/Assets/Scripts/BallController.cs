using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [Header("Speed")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float extraSpeed = 1.5f;
    [SerializeField] private float maxSpeed = 15f;


    [Header("Others")]
    public bool isLeftPaddleTurn;
    public int getHitCount;

    private Rigidbody2D rig;
    private int hitCounter;
    private float startSpeed;
    private TrailRenderer trailRenderer;

    private Vector3 startLocalScale;
    private float startTrailRendererWidth;
    private float startTrailRendererTime;


    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
        trailRenderer = GetComponentInChildren<TrailRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        startSpeed = moveSpeed;
        startLocalScale = transform.localScale;
        startTrailRendererWidth = trailRenderer.startWidth;
        startTrailRendererTime = trailRenderer.time;
        StartCoroutine(LaunchBall());
    }

    public IEnumerator LaunchBall()
    {
        RestartBall();
        hitCounter = 0;
        moveSpeed = startSpeed;
        yield return new WaitForSeconds(2f);
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

    public void BounceBall(Collision2D other)
    {
        Vector3 ballPosition = transform.position;
        Vector3 paddlePosition = other.transform.position;
        float paddleHeight = other.collider.bounds.size.y;

        float positionX = other.gameObject.CompareTag("RightPaddle") ? 1 : -1;

        float positionY = (ballPosition.y - paddlePosition.y) / paddleHeight;

        hitCounter++;

        MoveBall(new Vector2(positionX, positionY));
    }

    private void RestartBall()
    {
        transform.position = new Vector2(0, 0);
        rig.velocity = new Vector2(0, 0);
        transform.localScale = startLocalScale;
        trailRenderer.startWidth = startTrailRendererWidth;
        trailRenderer.time = startTrailRendererTime;
        getHitCount = 0;
        GameManager.Instance.DisplayGoalText();

        var paddle1 = FindObjectOfType<PaddleController1>();
        var paddle2 = FindObjectOfType<PaddleController2>();
        paddle1.GetComponent<Transform>().localScale = new Vector3(0.9f, 0.9f, 1);
        paddle2.GetComponent<Transform>().localScale = new Vector3(0.9f, 0.9f, 1);
        paddle1.moveSpeed = 12f;
        paddle2.moveSpeed = 12f;
    }
}
