using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyFloorCollisionDetector : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.parent.Rotate(new Vector3(0, 180, 0));
    }
}
