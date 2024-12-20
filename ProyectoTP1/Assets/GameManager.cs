using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O)) SceneManager.LoadScene("Lvl 1");
        if (Input.GetKeyDown(KeyCode.P)) SceneManager.LoadScene("Lvl 2");
        if (Input.GetKeyDown(KeyCode.R)) SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
