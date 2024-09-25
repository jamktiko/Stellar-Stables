using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabMovementHandler : FishMovementHandler
{
    public override void Spawned(float spawnXValue, float newFishSpeed)
    {
        transform.position = new Vector3(spawnXValue, -4.58f, 0f);
        base.Spawned(spawnXValue, newFishSpeed);
        fishSpeed /= 1.5f;
        bobbingAmplitude = 0;
        bobbingFrequency = 0;
        bobbingOffset = 0;
    }

}
