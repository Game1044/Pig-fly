using UnityEngine;

public class Slingshot : MonoBehaviour
{
    private Rigidbody2D rb;

    private Vector2 startPoint;

    private bool isDragging = false;

    public float power = 40f;

    public float maxDistance = 3f;

    public Trajectory trajectory;

    public GameManager gameManager;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        startPoint = transform.position;

        // ตอนเริ่มยังไม่ใช้ฟิสิกส์
        rb.bodyType = RigidbodyType2D.Kinematic;
    }

    void OnMouseDown()
    {
        isDragging = true;
    }

    void OnMouseDrag()
    {
        if (isDragging)
        {
            Vector2 mousePos =
                Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector2 direction = mousePos - startPoint;

            // จำกัดระยะลาก
            if (direction.magnitude > maxDistance)
            {
                direction =
                    direction.normalized * maxDistance;
            }

            // กันลากไปข้างหน้า
            if (direction.x > 0)
            {
                direction.x = 0;
            }

            transform.position = startPoint + direction;

            // Vector Addition
            Vector2 force =
                (startPoint - (Vector2)transform.position)
                * power;

            // trajectory
            Vector2 velocity = force / rb.mass;

            trajectory.ShowTrajectory(
                startPoint,
                velocity
            );
        }
    }

    void OnMouseUp()
    {
        isDragging = false;

        Vector2 releasePoint = transform.position;

        // Vector Addition
        Vector2 force =
            (startPoint - releasePoint) * power;

        // ซ่อนเส้นปะ
        trajectory.HideTrajectory();

        // เปิดฟิสิกส์
        rb.bodyType = RigidbodyType2D.Dynamic;

        // ยิง
        rb.AddForce(force, ForceMode2D.Impulse);

        // รอ 3 วิแล้วเรียกนกใหม่
        Invoke("NextBird", 3f);
    }

    void NextBird()
    {
        gameManager.SpawnNextBird();

        // ปิดนกตัวเก่า
        gameObject.SetActive(false);
    }
}