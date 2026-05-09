using UnityEngine;

public class Trajectory : MonoBehaviour
{
    public GameObject dotPrefab;

    // จำนวนจุด
    public int dotsNumber = 50;

    // ระยะห่างจุด
    public float dotSpacing = 0.05f;

    private GameObject[] dots;

    void Start()
    {
        dots = new GameObject[dotsNumber];

        for (int i = 0; i < dotsNumber; i++)
        {
            dots[i] = Instantiate(
                dotPrefab,
                transform
            );

            dots[i].SetActive(false);
        }
    }

    public void ShowTrajectory(
        Vector2 startPos,
        Vector2 velocity
    )
    {
        for (int i = 0; i < dotsNumber; i++)
        {
            float t = i * dotSpacing;

            Vector2 position =
                startPos +
                velocity * t +
                0.5f *
                Physics2D.gravity *
                t * t;

            dots[i].transform.position = position;

            dots[i].SetActive(true);
        }
    }

    public void HideTrajectory()
    {
        for (int i = 0; i < dotsNumber; i++)
        {
            dots[i].SetActive(false);
        }
    }
}