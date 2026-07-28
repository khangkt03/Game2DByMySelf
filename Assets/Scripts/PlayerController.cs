using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 5f; // tốc độ di chuyển của player 
    [SerializeField] private float jumpForce = 15f; // mức độ nhảy cao của player
    [SerializeField] private LayerMask groundLayer; // lớp mặt đất để kiểm tra va chạm với player
    [SerializeField] private Transform groundCheck; // vị trí kiểm tra va chạm với mặt đất
    private Animator animator; // biến animator để lưu trữ Animator của player (Để sử dung được component đó ở trên Unity ta cần khai báo biến)

    private bool isGrounded; // biến isGrounded để kiểm tra xem player có đang đứng trên mặt đất hay không

    private Rigidbody2D rb; // biến rb để lưu trữ Rigidbody2D của player (Để sử dung được component đó ở trên Unity ta cần khai báo biến)
    private GameManager gameManager; // biến gameManager để lưu trữ tham chiếu đến GameManager

    private AudioManager audioManager; // biến audioManager để lưu trữ tham chiếu đến AudioManager

    private void Awake()
    {
        animator = GetComponent<Animator>(); // lấy Animator của player
        rb = GetComponent<Rigidbody2D>(); // lấy Rigidbody2D của player
        gameManager = FindAnyObjectByType<GameManager>(); // tìm kiếm đối tượng GameManager trong scene và lấy component Gamemanager
        audioManager = FindAnyObjectByType<AudioManager>(); // tìm kiếm đối tượng AudioManager trong scene và lấy component AudioManager
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.IsGameOver() || gameManager.IsGameWin()) // kiểm tra xem trò chơi đã kết thúc hay chưa
        {
            return; // nếu đã kết thúc thì không thực hiện các hành động tiếp theo
        }
        HandleMovement(); // gọi hàm HandleMovement để xử lý di chuyển của player
        HandleJump(); // gọi hàm HandleJump để xử lý nhảy của player
        UpdateAnimator(); // gọi hàm UpdateAnimator để cập nhật trạng thái của Animator
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
            audioManager.PlayJumpSound(); // gọi phương thức PlayJumpSound để phát âm thanh khi nhảy
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce); // đặt lại vận tốc theo trục y về jumpForce 

        }

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer); // kiểm tra va chạm với mặt đất bằng cách tạo một hình tròn nhỏ tại vị trí groundCheck và kiểm tra xem có va chạm với lớp groundLayer hay không
    }

    private void UpdateAnimator()
    {
        bool isRunning = Mathf.Abs(rb.linearVelocity.x) > 0.1f; // kiểm tra xem player có đang chạy hay không dựa trên vận tốc theo trục x
        bool isJumping = !isGrounded; // kiểm tra xem player có đang nhảy hay không dựa trên trạng thái isGrounded
        animator.SetBool("isRunning", isRunning); // cập nhật trạng thái isRunning trong Animator
        animator.SetBool("isJumping", isJumping); // cập nhật trạng thái isJumping trong Animator
    }
}
