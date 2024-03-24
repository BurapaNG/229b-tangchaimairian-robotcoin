using UnityEngine;

public class MoveFromAToB : MonoBehaviour
{
    public Vector3 pointA; // ตำแหน่งจุด A
    public Vector3 pointB; // ตำแหน่งจุด B

    public float speed = 5f; // ความเร็วของการเคลื่อนที่

    private float startTime;
    private float journeyLength;
    private bool movingToB = true;

    void Start()
    {
        startTime = Time.time;
        journeyLength = Vector3.Distance(pointA, pointB);
    }

    void Update()
    {
        float distCovered = (Time.time - startTime) * speed;
        float fracJourney = distCovered / journeyLength;

        if (movingToB)
        {
            transform.position = Vector3.Lerp(pointA, pointB, fracJourney);
            if (fracJourney >= 1)
            {
                movingToB = false;
                startTime = Time.time;
            }
        }
        else
        {
            transform.position = Vector3.Lerp(pointB, pointA, fracJourney);
            if (fracJourney >= 1)
            {
                movingToB = true;
                startTime = Time.time;
            }
        }
    }
}