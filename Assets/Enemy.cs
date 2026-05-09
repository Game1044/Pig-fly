using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 5f;

    void OnCollisionEnter2D(Collision2D collision)
    {
        // ใช้แรงชนจริง
        Vector2 velocity = collision.relativeVelocity;

        // ชนเบาไม่คิดดาเมจ
        if (velocity.magnitude < 2f)
            return;

        // ดาเมจจากความเร็ว
        float damage = velocity.magnitude;

        TakeDamage(damage);

        Debug.Log("Enemy Damage: " + damage);
    }

    void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}