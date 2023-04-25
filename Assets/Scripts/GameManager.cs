using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    void Start()
    {
        PlayerHealth.Die += playerDied;
        EnemySpawner.GameFinished += gameFinished;
    }

    void playerDied()
    {
        ConfigData data = SaveAndLoadGame.LoadConfig();
        if (data != null && data.dificulty != 0)
        {
            Time.timeScale = 0;
            ErrorScreen.CreateError("Moriste", "Chau PC Jaja");
            //DestroyPC.DeleteSystem32();
        }
        else
            SceneManager.LoadScene(0);
    }

    public void gameFinished()
    {
        ConfigData data = SaveAndLoadGame.LoadConfig();
        if (data != null)
            SaveAndLoadGame.SaveConfig(data.dificulty, false);
        SceneManager.LoadScene(0);
    }

    void OnDestroy()
    {
        PlayerHealth.Die -= playerDied;
        EnemySpawner.GameFinished -= gameFinished;
    }
}
