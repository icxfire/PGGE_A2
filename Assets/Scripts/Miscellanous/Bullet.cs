using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void Start()
    {
        HandleDestructionOfBullet(); // changed the function at start to make its function clearer.
    }

    void Update()
    {
    }

    void HandleDestructionOfBullet()
    {
        // Destroy the bullet after 10 seconds if it does not hit any object.
        StartCoroutine(Destroy_Bullet(10.0f));
    }

    IEnumerator Destroy_Bullet(float duration)
    {
        yield return new WaitForSeconds(duration);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        IDamageable obj = collision.gameObject.GetComponent<IDamageable>();
        if (obj != null)
        {
            obj.TakeDamage();
        }

        StartCoroutine(Destroy_Bullet(0.1f));
    }
}
