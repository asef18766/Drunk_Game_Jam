using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject endmenu;
    public void ShowEndMenu()
    {
        endmenu.SetActive(true);
    }
    public void RestartGame()
    {
         SceneManager.LoadScene("Fish");
    }
    public void LoadGame(string str)
    {
         SceneManager.LoadScene(str);
    }
    public void OpenUrl(string url)
    {
        Application.OpenURL(url);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
