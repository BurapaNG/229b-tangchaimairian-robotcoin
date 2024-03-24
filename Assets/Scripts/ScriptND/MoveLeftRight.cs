using UnityEngine;

public class MoveLeftRight : MonoBehaviour
{
    public enum MovementAxis { XAxis, YAxis, ZAxis }; // เพิ่ม enum เพื่อกำหนดแกนที่วัตถุจะเคลื่อนที่

    public float speed = 5f; // ความเร็วของการเคลื่อนที่
    public float distance = 3f; // ระยะที่วัตถุจะเคลื่อนที่ซ้ายและขวา
    public MovementAxis movementAxis = MovementAxis.XAxis; // แกนที่วัตถุจะเคลื่อนที่

    private Vector3 startPos;
    private float direction = 1f; // เพื่อให้เคลื่อนที่ไปซ้ายและขวา

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // เคลื่อนที่ตามทิศทาง
        switch (movementAxis)
        {
            case MovementAxis.XAxis:
                transform.Translate(Vector3.right * direction * speed * Time.deltaTime);
                break;
            case MovementAxis.YAxis:
                transform.Translate(Vector3.up * direction * speed * Time.deltaTime);
                break;
            case MovementAxis.ZAxis:
                transform.Translate(Vector3.forward * direction * speed * Time.deltaTime);
                break;
        }

        // เมื่อเคลื่อนที่ถึงระยะที่กำหนด สลับทิศทาง
        switch (movementAxis)
        {
            case MovementAxis.XAxis:
                if (Mathf.Abs(transform.position.x - startPos.x) >= distance)
                {
                    direction *= -1f; // สลับทิศทาง
                }
                break;
            case MovementAxis.YAxis:
                if (Mathf.Abs(transform.position.y - startPos.y) >= distance)
                {
                    direction *= -1f; // สลับทิศทาง
                }
                break;
            case MovementAxis.ZAxis:
                if (Mathf.Abs(transform.position.z - startPos.z) >= distance)
                {
                    direction *= -1f; // สลับทิศทาง
                }
                break;
        }
    }
}