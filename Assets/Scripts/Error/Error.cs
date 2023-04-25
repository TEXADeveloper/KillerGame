using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Error : MonoBehaviour
{
    [SerializeField] private TMP_Text titleText;
    [SerializeField] private TMP_Text messageText;
    [SerializeField] private Button button;

    void OnEnable()
    {
        ErrorScreen.SetError(titleText, messageText);
        button.Select();
    }

    public void OK()
    {
        SceneManager.UnloadSceneAsync("Scenes/ErrorScene");
    }
}
