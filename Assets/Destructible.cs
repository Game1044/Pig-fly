using UnityEngine;

public class Destructible : MonoBehaviour
{
    public float durability = 15f;

    public float damageMultiplier = 3f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // ความเร็วสัมพัทธ์
        Vector2 velocity = collision.relativeVelocity;

        // กันชนเบา
        if (velocity.magnitude < 3f)
            return;

        Vector2 normal =
            collision.contacts[0].normal;

        // Dot Product
        float impact =
            Vector2.Dot(
                velocity.normalized,
                -normal
            );

        // กัน impact ต่ำเกิน
        float minImpact = 0.5f;

        float impactValue =
            Mathf.Max(impact, minImpact);

        float damage =
            (
                impactValue *
                velocity.magnitude *
                damageMultiplier
            ) / 5f;

        // ดาเมจจากตกพื้น
        if (collision.gameObject.CompareTag("Ground"))
        {
            damage *= 2f;
        }

        Debug.Log("Damage: " + damage);

        TakeDamage(damage);

        ApplyTorque(collision, velocity);
    }

    void TakeDamage(float damage)
    {
        durability -= damage;

        if (durability <= 0)
        {
            Destroy(gameObject);
        }
    }

    void ApplyTorque(
        Collision2D collision,
        Vector2 velocity
    )
    {
        Vector2 contactPoint =
            collision.contacts[0].point;

        Vector2 center =
            rb.worldCenterOfMass;

        Vector2 lever =
            contactPoint - center;

        // Cross Product
        float torque =
            Vector3.Cross(lever, velocity).z;

        rb.AddTorque(torque * 1f);
    }
}