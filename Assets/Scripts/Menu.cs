using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{
    public void PlayGame() // phương thức PlayGame để bắt đầu trò chơi
    {
        SceneManager.LoadScene("Game"); // tải scene game
    }

    public void QuitGame() // phương thức QuitGame để thoát trò chơi 
    {
        Application.Quit(); // thoát trò chơi
    }
}
