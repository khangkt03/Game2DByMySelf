using UnityEngine;

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

    }
}
