using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController1 : MonoBehaviour
{
    public float moveSpeed;

    [SerializeField] private float minLimit;
    [SerializeField] private float maxLimit;

    private float directionY;
    private Rigidbody2D rig;
    private Vector2 paddleDirection;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        GetInput();

        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.y = Mathf.Clamp(transform.position.y, minLimit, maxLimit);
        transform.position = paddlePos;
    }

    void FixedUpdate()
    {
        MoveObject();
    }

    private void GetInput()
    {
        directionY = Input.GetAxisRaw("Vertical");
        paddleDirection = new Vector2(0, directionY).normalized;
    }

    private void MoveObject()
    {
        rig.velocity = paddleDirection * moveSpeed;
    }
}
