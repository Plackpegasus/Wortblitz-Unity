using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Despawn : MonoBehaviour, IObservable<int>
{
    public TMP_InputField inputField;
    private List<IObserver<int>> scoreObservers = new List<IObserver<int>>();

    public IDisposable Subscribe(IObserver<int> observer)
    {
        if (!scoreObservers.Contains(observer))
        {
            scoreObservers.Add(observer);
        }

        return null;
    }

    // Start is called before the first frame update
    void Start()
    {
        inputField.onValueChanged.AddListener(TextInputChange);
        inputField.Select();
    }

    // invoked on each input change on inputField
    public void TextInputChange(string inputFieldText)
    {
        List<Enemy> enemies = FindObjectsByType<Enemy>(0).ToList();

        foreach (Enemy enemy in enemies)
        {
            string text = enemy.GetComponentInChildren<TextMeshPro>().text.Trim();

            if (inputFieldText != text)
            {
                continue;
            }

            Destroy(enemy.gameObject);
            ReturnScoreToObservers(enemy.scoreOnKill);
            ClearInputField();
            return;
        }
    }

    private void ReturnScoreToObservers(int score)
    {
        foreach (var observer in scoreObservers)
        {
            observer.OnNext(score);
        }
    }

    private void ClearInputField()
    {
        inputField.text = "";
        inputField.Select();
    }

    private void OnDestroy()
    {
        inputField.onValueChanged.RemoveAllListeners();
    }
}
