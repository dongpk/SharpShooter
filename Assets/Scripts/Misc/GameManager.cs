using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
using StarterAssets;

public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_Text enemiesLeftText;
    [SerializeField] GameObject youWinText;
    [SerializeField] GameObject crosshair;
    
    int enemiesLeft=0;

    const string ENEMIES_LEFT_TEXT = "Enemies Left: ";
    public void AjustEnemiesLeftText(int amount)
    {
        enemiesLeft += amount;
        enemiesLeftText.text = ENEMIES_LEFT_TEXT + enemiesLeft.ToString();
        if (enemiesLeft <= 0)
        {
            
            enemiesLeftText.gameObject.SetActive(false);
            StarterAssetsInputs starterAssetsInputs = FindFirstObjectByType<StarterAssetsInputs>();
            starterAssetsInputs.SetCursorState(false);
            crosshair.SetActive(false);
            youWinText.SetActive(true);
        }

    }
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