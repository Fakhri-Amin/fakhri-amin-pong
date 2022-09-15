using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/LengthBuff")]

public class LengthBuff : PowerupEffect
{
    [SerializeField] private float amount;

    public override void Apply(GameObject target)
    {
        var paddle1 = FindObjectOfType<PaddleController1>();
        var paddle2 = FindObjectOfType<PaddleController2>();
        paddle1.GetComponent<Transform>().localScale += new Vector3(0, amount, 0);
        paddle2.GetComponent<Transform>().localScale += new Vector3(0, amount, 0);
    }
}
