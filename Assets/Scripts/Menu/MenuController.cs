using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject caution;
    [SerializeField] private TMP_Dropdown dropdown;
    private int difficulty = 0;

    void Start()
    {
        ConfigData data = SaveAndLoadGame.LoadConfig();
        if (data == null)
        {
            SaveAndLoadGame.SaveConfig(0, false);
            return;
        }
        if (data.playing)
        {
            ErrorScreen.CreateError("ERROR:", "Destruir PC");
            //DestroyPC.DeleteSystem32();
        }
        dropdown.value = data.dificulty;
        difficulty = data.dificulty;
    }

    public void Quit()
    {
        SaveAndLoadGame.SaveConfig(difficulty, false);
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    public void ChangeDificulty(int value)
    {
        difficulty = value;
        SaveAndLoadGame.SaveConfig(value, false);
    }

    public void PlayButtonPressed()
    {
        if (difficulty != 0)
            caution.SetActive(true);
        else
            playGame();
    }

    public void CautionAccept()
    {
        SaveAndLoadGame.SaveConfig(difficulty, true);
        playGame();
    }

    private void playGame()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
