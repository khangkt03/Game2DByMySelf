using UnityEngine;
using TMPro;
public class PlayerCollision : MonoBehaviour
{
    private GameManager gameManager; // biến gameManager để lưu trữ tham chiếu đến GameManager
    private AudioManager audioManager; // biến audioManager để lưu trữ tham chiếu đến AudioManager
    private void Awake()
    {
        gameManager = FindAnyObjectByType<GameManager>(); // tìm kiếm đối tượng GameManager trong scene và lấy component Gamemanager
        audioManager = FindAnyObjectByType<AudioManager>(); // tìm kiếm đối tượng AudioManager trong scene và lấy component AudioManager
    }
    // Phuong thức này sẽ được gọi khi có va chạm xảy ra với collider của player được tính là trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin")) // kiểm tra xem đối tượng va chạm có tag là "Coin" hay không
        {
            gameManager.AddScore(1);
            audioManager.PlayCoinSound(); // gọi phương thức PlayCoinSound để phát âm thanh khi nhặt được coin
            Destroy(collision.gameObject); // nếu có thì hủy đối tượng coin

        }
        else if (collision.CompareTag("Trap")) // kiểm tra xem đối tượng va chạm có tag là "Trap" hay không
        {
            gameManager.GameOver();

        }
        else if (collision.CompareTag("Enemy")) // kiểm tra xem đối tượng va chạm có tag là "Enemy" hay không
        {
            gameManager.GameOver();
        }
        else if (collision.CompareTag("Key")) // kiểm tra xem đối tượng va chạm có tag là "Key" hay không
        {
            Destroy(collision.gameObject); // nếu có thì hủy đối tượng key
            gameManager.GameWin(); // gọi phương thức GameWin để thắng trò chơi
        }

    }
}
