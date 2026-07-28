using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 3f; // tốc độ di chuyển của enemy
    [SerializeField] private float distance = 5f; // khoảng cách di chuyển của enemy
    private Vector3 startPos; // vị trí bắt đầu của enemy
    private bool movingRight = true; // biến để kiểm tra hướng di chuyển của enemy

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.position; // lưu vị trí bắt đầu của enemy

    }

    // Update is called once per frame
    void Update()
    {
        float leftBound = startPos.x - distance; // tính toán biên trái của enemy
        float rightBound = startPos.x + distance; // tính toán biên phải của enemy

        if (movingRight) // nếu enemy đang di chuyển sang phải
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime); // di chuyển enemy sang phải
            if (transform.position.x >= rightBound) // nếu enemy đã di chuyển đến biên phải
            {
                movingRight = false; // đổi hướng di chuyển sang trái
                Flip(); // lật hướng của enemy
            }
        }
        else // nếu enemy đang di chuyển sang trái
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime); // di chuyển enemy sang trái
            if (transform.position.x <= leftBound) // nếu enemy đã di chuyển đến biên trái
            {
                movingRight = true; // đổi hướng di chuyển sang phải
                Flip(); // lật hướng của enemy
            }
        }
    }

    void Flip() // phương thức Flip để lật hướng của enemy
    {
        Vector3 scale = transform.localScale; // lấy scale hiện tại của enemy
        scale.x *= -1; // lật hướng của enemy bằng cách nhân scale.x với -1
        transform.localScale = scale; // cập nhật scale mới cho enemy
    }
}
