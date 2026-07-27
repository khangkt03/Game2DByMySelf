using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private int score = 0; // biến score để lưu trữ điểm số của người chơi
    [SerializeField] private TextMeshProUGUI scoreText; // biến scoreText để hiển thị điểm số trên giao diện người dùng
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateScore(); // gọi phương thức UpdateScore để cập nhật điểm số trên giao diện người dùng
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
}
