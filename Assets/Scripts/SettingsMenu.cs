using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [Header("UI Elements")]
    public Button returnBtn;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.SetActive(false);
        returnBtn.onClick.AddListener(ReturnToMenu);
    }

    private void ReturnToMenu() 
    {
        gameObject.SetActive(false);
    }
}
