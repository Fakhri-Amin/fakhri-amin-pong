using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private KeyCode upKey;
    [SerializeField] private KeyCode downKey;

    private Rigidbody2D rig;
    private Vector2 inputVector;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        inputVector = GetInput();
    }

    void FixedUpdate()
    {
        MoveObject(inputVector);
    }

    private Vector2 GetInput()
    {
        if (Input.GetKey(upKey))
        {
            return Vector2.up;
        }
        else if (Input.GetKey(downKey))
        {
            return Vector2.down;
        }

        return Vector2.zero;
    }

    private void MoveObject(Vector2 direction)
    {
        direction.y = Mathf.Clamp(direction.y, -3.4f, 3.4f);
        rig.velocity = new Vector2(direction.x, direction.y).normalized * moveSpeed;
    }
}
