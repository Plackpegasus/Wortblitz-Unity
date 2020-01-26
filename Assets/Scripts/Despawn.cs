using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Despawn : MonoBehaviour, IObservable<int>
{
    public TMP_InputField inputField;

    private string newInput;
    private string lastInput;
    private List<IObserver<int>> observers = new List<IObserver<int>>();

    public IDisposable Subscribe(IObserver<int> observer)
    {
        if (!observers.Contains(observer))
        {
            observers.Add(observer);
        }

        return null;
    }


    // Start is called before the first frame update
    void Start()
    {
        inputField.Select();
        lastInput = "";
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void ReturnScoreToObservers(int score)
    {
        foreach (var observer in observers)
        {
            observer.OnNext(score);
        }
    }

    public void TextInputChange()
    {
        List<Enemy> enemies = FindObjectsOfType<Enemy>().ToList();
        newInput = inputField.text;

        if (newInput.Length >= lastInput.Length)
        {
            foreach (Enemy enemy in enemies)
            {
                string text = enemy.GetComponentInChildren<TextMeshPro>().text.Trim();

                if (newInput.Equals(text))
                {
                    Destroy(enemy.gameObject);
                    ReturnScoreToObservers(enemy.scoreOnKill);
                    Clear();
                    return;
                }
            }
        }
        else
        {
            ReturnScoreToObservers(-1);
        }

        lastInput = newInput;
    }

    private void Clear()
    {
        newInput = "";
        lastInput = "";
        inputField.text = "";
        inputField.Select();
    }
}
