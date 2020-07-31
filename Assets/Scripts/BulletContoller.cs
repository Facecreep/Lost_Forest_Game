using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletContoller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<Animator>().SetTrigger("Hit");

        HealthManager healthManager = collision.gameObject.GetComponent<HealthManager>();
        if (healthManager != null)
            healthManager.Damage(1);
    }
}