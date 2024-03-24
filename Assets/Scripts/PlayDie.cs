using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayDie : MonoBehaviour
{
    public int maxHealth = 100; // ปรับ maxHealth ตามต้องการ
    private int currentHealth;
    private PlayDie playDie;

    private void Start()
    {
        currentHealth = maxHealth;
        {
            playDie = GetComponent<PlayDie>();
        }
        
    }

    // ฟังก์ชันที่ใช้ในการลด HP
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die(); // เรียกใช้ฟังก์ชัน Die() เมื่อ HP เท่ากับหรือน้อยกว่า 0
        }
    }

    // ฟังก์ชันที่ใช้ในการตาย
    private void Die()
    {
        // โหลดหน้าฉากที่ต้องการโชว์หลังจากการตาย
        SceneManager.LoadScene("Restart");
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("DA0"))
        {
            playDie.TakeDamage(1000); // ลด HP เมื่อ Player ชนกับ "Amy"
        }
        if (collision.gameObject.CompareTag("Amy"))
        {
            playDie.TakeDamage(10); // ลด HP เมื่อ Player ชนกับ "Amy"
        }
    }
}