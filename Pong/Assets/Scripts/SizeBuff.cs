using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/SizeBuff")]
public class SizeBuff : PowerupEffect
{
    [SerializeField] private float amount;

    public override void Apply(GameObject target)
    {
        target.GetComponent<Transform>().localScale *= amount;

        // float clampedTransformScaleX = Mathf.Clamp(transformScale.x, 0.9f, 5f);
        // float clampedTransformScaleY = Mathf.Clamp(transformScale.y, 0.9f, 5f);
        // transformScale = new Vector2(clampedTransformScaleX, clampedTransformScaleY);

        target.GetComponentInChildren<TrailRenderer>().startWidth *= amount;
        target.GetComponentInChildren<TrailRenderer>().time *= amount;

    }
}
