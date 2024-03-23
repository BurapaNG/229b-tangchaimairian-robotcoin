using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private bool groundCheck = false;

    public float speed = 10.0f;
    public float jumpForce = 6.0f;
    private float horizontalInput;
    private float forwardInput;

    private Rigidbody playerRb;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);

        if (groundCheck)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                groundCheck = false;
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            groundCheck = true;
        }
    }

    private void FixedUpdate()
    {
        SmoothMovement();
    }

    private void SmoothMovement()
    {
        // สร้างเวกเตอร์เริ่มต้นที่ชี้ไปด้านล่างของตัวละคร
        Vector3 downwardDirection = -transform.up;

        // สร้างเรนเดอร์เรียนเสียดทาน
        RaycastHit hit;
        if (Physics.Raycast(transform.position, downwardDirection, out hit))
        {
            // หากเรนเดอร์ชนกับพื้น
            if (hit.distance < 0.1f) // ใช้ค่าความลื่นตามที่คุณต้องการ
            {
                // ปรับตำแหน่งของตัวละครให้เรียบบนพื้น
                transform.position = new Vector3(transform.position.x, hit.point.y + 0.1f, transform.position.z);
            }
        }

        // เคลื่อนที่ตัวละครไปข้างหน้า
        playerRb.MovePosition(transform.position + transform.forward * speed * Time.fixedDeltaTime);
    }
}