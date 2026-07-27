using UnityEngine;
using TMPro;
public class PlayerCollision : MonoBehaviour
{
    private GameManager gameManager; // biến gameManager để lưu trữ tham chiếu đến GameManager

    private void Awake()
    {
        gameManager = FindAnyObjectByType<GameManager>(); // tìm kiếm đối tượng GameManager trong scene và lấy component Gamemanager
    }
    // Phuong thức này sẽ được gọi khi có va chạm xảy ra với collider của player được tính là trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin")) // kiểm tra xem đối tượng va chạm có tag là "Coin" hay không
        {
            gameManager.AddScore(1); // nếu có thì gọi phương thức AddScore của gameManager để tăng điểm số lên 1 
            Debug.Log("Coin collected!"); // in ra thông báo "Coin collected!" trên console
            Destroy(collision.gameObject); // nếu có thì hủy đối tượng coin

        }
        else if (collision.CompareTag("Trap")) // kiểm tra xem đối tượng va chạm có tag là "Trap" hay không
        {
            gameManager.GameOver(); // nếu có thì gọi phương thức GameOver của gameManager để kết thúc trò chơi
            Debug.Log("Đau quá trời r nè "); // nếu có thì in ra thông báo
                                             // Thực hiện các hành động khác khi va chạm với trap, ví dụ: kết thúc trò chơi, giảm máu, v.v.
        }

    }
}
