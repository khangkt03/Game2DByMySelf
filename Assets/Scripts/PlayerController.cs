using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 5f; // tốc độ di chuyển của player 
    [SerializeField] private float jumpForce = 15f; // mức độ nhảy cao của player
    [SerializeField] private LayerMask groundLayer; // lớp mặt đất để kiểm tra va chạm với player
    [SerializeField] private Transform groundCheck; // vị trí kiểm tra va chạm với mặt đất

    private bool isGrounded; // biến isGrounded để kiểm tra xem player có đang đứng trên mặt đất hay không

    private Rigidbody2D rb; // biến rb để lưu trữ Rigidbody2D của player (Để sử dung được component đó ở trên Unity ta cần khai báo biến)
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); // lấy Rigidbody2D của player
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement(); // gọi hàm HandleMovement để xử lý di chuyển của player
        HandleJump(); // gọi hàm HandleJump để xử lý nhảy của player
    }

    // Hàm HandleMovement để xử lý di chuyển của player
    private void HandleMovement()

    {   //Nhận input từ người chơi và di chuyển nhân vật theo trục ngang
        float moveInput = Input.GetAxisRaw("Horizontal"); // lấy giá trị di chuyển từ bàn phím (trái/phải) TỪ TRỤC NGANG
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y); // cập nhật vận tốc của player theo trục x

        // Lật hướng của player dựa trên hướng di chuyển
        if (moveInput > 0) // nếu di chuyển sang phải
        {
            transform.localScale = new Vector3(1, 1, 1); // lật hướng của player sang phải
        }
        else if (moveInput < 0) // nếu di chuyển sang trái
        {
            transform.localScale = new Vector3(-1, 1, 1); // lật hướng của player sang trái
        }
    }


    private void HandleJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded) // kiểm tra nếu người chơi nhấn nút nhảy và player đang đứng trên mặt đất
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce); // đặt lại vận tốc theo trục y về jumpForce 

        }

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer); // kiểm tra va chạm với mặt đất bằng cách tạo một hình tròn nhỏ tại vị trí groundCheck và kiểm tra xem có va chạm với lớp groundLayer hay không
    }
}
