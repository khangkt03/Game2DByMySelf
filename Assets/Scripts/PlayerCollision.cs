using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    // Phuong thức này sẽ được gọi khi có va chạm xảy ra với collider của player được tính là trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin")) // kiểm tra xem đối tượng va chạm có tag là "Coin" hay không
        {
            Debug.Log("Coin collected!"); // in ra thông báo "Coin collected!" trên console
            Destroy(collision.gameObject); // nếu có thì hủy đối tượng coin

        }

    }
}
