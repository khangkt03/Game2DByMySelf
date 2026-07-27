using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    private int score = 0; // biến score để lưu trữ điểm số của người chơi
    [SerializeField] private TextMeshProUGUI scoreText; // biến scoreText để hiển thị điểm số trên giao diện người dùng
    [SerializeField] private GameObject gameOverUi; // biến gameOverUi để hiển thị giao diện kết thúc trò chơi
    private bool isGameOver = false; // biến isGameOver để kiểm tra xem trò chơi đã kết thúc hay chưa

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateScore(); // gọi phương thức UpdateScore để cập nhật điểm số trên giao diện người dùng 
        gameOverUi.SetActive(false); // ẩn giao diện kết thúc trò chơi khi bắt đầu
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddScore(int value) // phương thức AddScore để cộng điểm số
    {
        score += value; // cộng giá trị value vào biến score
        UpdateScore(); // gọi phương thức UpdateScore để cập nhật điểm số trên giao diện người dùng
    }

    private void UpdateScore() // phương thức UpdateScore để cập nhật điểm số trên giao diện người dùng
    {
        scoreText.text = "Score: " + score.ToString(); // cập nhật text của scoreText với giá trị của biến score
    }

    public void GameOver() // phương thức GameOver để kết thúc trò chơi
    {
        isGameOver = true; // đặt biến isGameOver thành true
        score = 0;
        Time.timeScale = 0f; // dừng thời gian trong trò chơi
        gameOverUi.SetActive(true); // hiển thị giao diện kết thúc trò chơi
    }
    public void RestartGame() // phương thức RestartGame để khởi động lại trò chơi
    {
        isGameOver = false; // đặt biến isGameOver thành false
        score = 0; // đặt biến score về 0
        UpdateScore(); // gọi phương thức UpdateScore để cập nhật điểm số trên giao diện người dùng
        Time.timeScale = 1f; // tiếp tục thời gian trong trò chơi
        SceneManager.LoadScene("Game"); // tải lại scene hiện tại để khởi động lại trò chơi

    }
}
