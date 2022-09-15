using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/SizeBuff")]
public class SizeBuff : PowerupEffect
{
    [SerializeField] private float amount;

    public override void Apply(GameObject target)
    {
        if (amount > 1) // Buff
        {
            if (target.GetComponent<BallController>().getHitCount <= 3)
            {
                target.GetComponent<BallController>().getHitCount++;
                target.GetComponent<Transform>().localScale *= amount;
                target.GetComponentInChildren<TrailRenderer>().startWidth *= amount;
                target.GetComponentInChildren<TrailRenderer>().time *= amount;
            }
        }
        else if (amount < 1) // Debuff
        {
            if (target.GetComponent<BallController>().getHitCount >= -3)
            {
                target.GetComponent<BallController>().getHitCount--;
                target.GetComponent<Transform>().localScale *= amount;
                target.GetComponentInChildren<TrailRenderer>().startWidth *= amount;
                target.GetComponentInChildren<TrailRenderer>().time *= amount;
            }
        }
    }
}
