using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("UI Elements")]
    public Button playBtn;
    public Button quitBtn;
    public Button settingsBtn;

    [Header("Sub Menus")]
    public GameObject settingsMenu;

    private void Start()
    {
        playBtn.onClick.AddListener(PlayGame);
        quitBtn.onClick.AddListener(QuitGame);
        settingsBtn.onClick.AddListener(OpenSettingsMenu);
    }

    private void PlayGame() 
    {
        SceneManager.LoadScene("SampleLevel");
    }

    private void QuitGame() 
    {
        #if UNITY_STANDALONE
            Application.Quit();
        #endif
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
    private void OpenSettingsMenu() 
    {
        settingsMenu.SetActive(true);
    }

    void OnDestroy()
    {
        playBtn.onClick.RemoveAllListeners();
        quitBtn.onClick.RemoveAllListeners();
        settingsBtn.onClick.RemoveAllListeners();
    }
}
