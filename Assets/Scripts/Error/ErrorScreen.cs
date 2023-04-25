using UnityEngine.SceneManagement;
using TMPro;

public class ErrorScreen
{
    private static string staticTitle = "";
    private static string staticMessage = "";

    public static void CreateError(string title, string message)
    {
        SceneManager.LoadScene("Scenes/ErrorScene", LoadSceneMode.Additive);
        staticTitle = title;
        staticMessage = message;
    }

    public static void SetError(TMP_Text titleText, TMP_Text messageText)
    {
        messageText.text = staticMessage;
        titleText.text = staticTitle;
    }
}
