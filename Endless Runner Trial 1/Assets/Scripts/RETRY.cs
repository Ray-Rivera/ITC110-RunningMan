using UnityEngine;
using UnityEngine.SceneManagement;

public class RETRY : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void retryGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
