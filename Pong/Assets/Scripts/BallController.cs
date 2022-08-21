using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private Rigidbody2D rig;

    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rig.velocity = new Vector2(0.5f, 0.5f) * moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
