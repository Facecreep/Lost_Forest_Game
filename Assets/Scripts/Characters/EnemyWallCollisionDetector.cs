using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWallCollisionDetector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(transform.parent != null)
            transform.parent.Rotate(new Vector3(0, 180, 0));
    }
}
