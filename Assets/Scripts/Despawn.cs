using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Despawn : MonoBehaviour, IObservable<int>
{
    public TMP_InputField inputField;

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

    public void TextInput()
    {
        List<Enemy> enemies = FindObjectsOfType<Enemy>().ToList();
        string input = inputField.text;

        foreach (Enemy enemy in enemies)
        {
            string text = enemy.GetComponentInChildren<TextMeshPro>().text.Trim();

            if (input.Equals(text))
            {
                inputField.text = "";
                inputField.Select();

                ReturnScoreToObservers(enemy.scoreOnKill);
                Destroy(enemy.gameObject);
                return;
            }
        }
    }
}
