using UnityEngine;
using TMPro;

public class CoinCollection : MonoBehaviour
{
    [SerializeField] private TMP_Text Score;
    private int Coin = 0;
    private bool hasWon = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            Coin++;
            Debug.Log("Coin collected: " + Coin);
            Score.text = "Coin: " + Coin;
            Destroy(other.gameObject); // ทำลายเหรียญที่เก็บได้

            if (Coin >= 20 && !hasWon) // เมื่อเก็บเหรียญ 2 เหรียญ และยังไม่ชนกับวัตถุที่ชื่อ WIN
            {
                hasWon = true;
                EndGame("Restart"); // เรียกเมทอดจบเกมพร้อมโชว์ Scene ที่ชื่อ Restart
            }
        }
        else if (other.CompareTag("WIN") && Coin < 20) // ถ้าชนกับวัตถุที่มี Tag WIN แต่ยังไม่เก็บเหรียญครบ 2 เหรียญ
        {
            EndGame(); // จบเกมทันที
        }
    }

    private void EndGame(string sceneName = "")
    {
        Debug.Log("Game Over");
        // ปรับเปลี่ยนโค้ดเพื่อจบเกม ตามต้องการ เช่น โหลดหน้าเมนูหรือแสดงข้อความ Game Over
        if (!string.IsNullOrEmpty(sceneName))
        {
            // โหลด Scene ที่ชื่อ sceneName (ถ้ามีการระบุ)
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        }
    }
}