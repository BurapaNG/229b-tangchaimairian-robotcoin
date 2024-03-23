using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private bool groundCheck = false;

    public float speed = 20.0f;
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

        Vector3 movement = new Vector3(horizontalInput, 0.0f, forwardInput) * speed * Time.deltaTime;
        playerRb.MovePosition(transform.position + transform.TransformDirection(movement));

        if (groundCheck && Input.GetKeyDown(KeyCode.Space))
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            groundCheck = false;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            groundCheck = true;
        }
    }
}