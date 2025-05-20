using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public void RestartGame()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }
    
    public void QuitGame()
    {
         Debug.LogWarning("Khong thoat ra dc trong unity editor");
        Application.Quit();
       
    }
}