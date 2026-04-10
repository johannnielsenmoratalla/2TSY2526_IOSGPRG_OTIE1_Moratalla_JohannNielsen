using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 10f;
    public AttributesManager shooterAtm;

    private Rigidbody2D rb;
    private Collider2D bulletCollider;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bulletCollider = GetComponent<Collider2D>();

        if (rb == null || bulletCollider == null)
        {
            Debug.LogError("Bullet missing Rigidbody2D or Collider2D!");
            return;
        }

        if (shooterAtm != null)
        {
            Collider2D[] shooterColliders = shooterAtm.GetComponentsInChildren<Collider2D>();
            foreach (var col in shooterColliders)
            {
                Physics2D.IgnoreCollision(bulletCollider, col);
            }
        }

        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        rb.AddForce(transform.right * bulletSpeed, ForceMode2D.Impulse);
        Destroy(gameObject, 5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (shooterAtm == null) return;

        var targetAtm = collision.GetComponentInParent<AttributesManager>();
        if (targetAtm == null) return;

        if (targetAtm == shooterAtm) return;

        if (shooterAtm.CompareTag("Player") && !collision.CompareTag("Enemy")) return;
        if (shooterAtm.CompareTag("Enemy") && !collision.CompareTag("Player")) return;

        targetAtm.TakeDamage(shooterAtm.attack);
        Destroy(gameObject);
    }
}