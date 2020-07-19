using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyFlipPathfinding : MonoBehaviour
{
    public AIPath thisAiPath;
    // Update is called once per frame
    void Update()
    {
        if (thisAiPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(-2.27f, 2.27f, 2.27f);
        }
        else if (thisAiPath.desiredVelocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(2.27f, 2.27f, 2.27f);
        }
    }
}
