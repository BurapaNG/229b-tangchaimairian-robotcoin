using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class PlayDie : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // ตรวจสอบการชนกับวัตถุที่มี Tag ว่าเป็น "ตัวฆ่า"
        if (collision.gameObject.CompareTag("Amy"))
        {
            Die(); // เรียกใช้ฟังก์ชัน Die() เพื่อทำการตาย
        }
    }

    // ฟังก์ชันที่ใช้ในการตาย
    private void Die()
    {
        // โหลดหน้าฉากที่ต้องการโชว์หลังจากการตาย
        SceneManager.LoadScene("Restart");
    }
}