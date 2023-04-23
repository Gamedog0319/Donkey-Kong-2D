using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    private int lives;
    private int level;
    private int score;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        NewGame();
    }

    private void NewGame()
    {
        lives = 3;
        score = 0;
        LoadLevel(1);
    }

    private void LoadLevel(int index)
    {
        level = index;
        Camera camera = Camera.main;

        if (camera != null)
        {
            camera.cullingMask = 0;
        }

        Invoke(nameof(LoadScene), 1f);
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(level);
    }

    public void LevelComplete()
    {
        score += 1000;

        int nextLevel = level + 1; 

        if(nextLevel < SceneManager.sceneCountInBuildSettings)
        {
            LoadLevel(nextLevel);
        }else
        {
            LoadLevel(level);
        }
    }

    public void LevelFailed()
    {
        lives--;
        if(lives <= 0)
        {
            NewGame();
        }else
        {
            LoadLevel(level); 
        }
    }
}
