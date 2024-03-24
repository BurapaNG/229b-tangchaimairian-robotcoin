using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public Vector3 initialRotationSpeed = new Vector3(0, 0, 0); // ความเร็วเริ่มต้นในแต่ละแกน

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
            // กำหนดความเร็วการหมุนเริ่มต้น
            rb.angularVelocity = initialRotationSpeed;
        }
    }

    void FixedUpdate()
    {
        // หมุนวัตถุตามแกน Y โดยใช้ Rigidbody
        if (rb != null)
        {
            // หากต้องการให้หมุนเร็วที่แน่นอน สามารถใช้ฟังก์ชัน AddTorque ได้เช่นกัน
            // rb.AddTorque(Vector3.up * spinSpeed);

            // หรือใช้ MoveRotation เพื่อหมุนวัตถุตามแกนที่กำหนด
            Quaternion deltaRotation = Quaternion.Euler(initialRotationSpeed * Time.fixedDeltaTime);
            rb.MoveRotation(rb.rotation * deltaRotation);
        }
    }
}