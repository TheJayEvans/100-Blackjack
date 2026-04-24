using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void loadGame()
    {
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }

    public void loadMenu()
    {
        SceneManager.LoadScene("Main Menu", LoadSceneMode.Single);
    }

    public void credits()
    {
        SceneManager.LoadScene("Credits", LoadSceneMode.Single);
    }
}

