using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float spinSpeed = 20f; // ความเร็วในการหมุน

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody not found on this object!");
        }
        else
        {
            rb.angularVelocity = Random.insideUnitSphere * spinSpeed;
        }
    }

    void FixedUpdate()
    {
        // หมุนวัตถุให้เรื่อยๆ โดยใช้ Rigidbody
        if (rb != null)
        {
            rb.MoveRotation(rb.rotation * Quaternion.Euler(Vector3.up * spinSpeed * Time.fixedDeltaTime));
        }
    }

    void Awake()
    {
        // ตั้งค่าความเร็วหมุนเริ่มต้นเมื่อเริ่มเกมใหม่
        if (rb != null)
        {
            rb.angularVelocity = Random.insideUnitSphere * spinSpeed;
        }
    }
}