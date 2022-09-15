using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/SpeedBuff")]

public class SpeedBuff : PowerupEffect
{
    [SerializeField] private float amount;

    public override void Apply(GameObject target)
    {
        // target.GetComponent<PaddleController>().moveSpeed *= amount;
        var paddle1 = FindObjectOfType<PaddleController1>();
        var paddle2 = FindObjectOfType<PaddleController2>();
        paddle1.moveSpeed *= amount;
        paddle2.moveSpeed *= amount;

    }
}
