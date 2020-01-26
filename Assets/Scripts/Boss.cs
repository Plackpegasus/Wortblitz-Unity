using System;
using UnityEngine;
using TMPro;

public class Boss : MonoBehaviour, IObserver<int>
{
    private string text;
    private string hiddenText;
    private TextMeshPro tmProGUI;

    private IDisposable disposable;

    public virtual void Subscribe(IObservable<int> observable)
    {
        disposable = observable.Subscribe(this);
    }

    public virtual void Unsubscribe()
    {
        disposable.Dispose();
    }

    public void OnCompleted()
    {
        throw new NotImplementedException();
    }

    public void OnError(Exception error)
    {
        throw new NotImplementedException();
    }

    public void OnNext(int value)
    {
        int i = hiddenText.IndexOf('*');

        if (value != -1 && i >= 0)
        {
            char[] c = hiddenText.ToCharArray();
            char[] t = text.ToCharArray();
            c[i] = t[i];
            hiddenText = c.ArrayToString();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        GameObject gameManager = GameObject.Find("Game Manager");
        Despawn despawnScript = gameManager.GetComponent<Despawn>();

        tmProGUI = GetComponentInChildren<TextMeshPro>();
        text = tmProGUI.text;

        foreach (var _ in text)
        {
            hiddenText += "*";
        }

        tmProGUI.text = hiddenText;
        Subscribe(despawnScript);
    }

    // Update is called once per frame
    void Update()
    {
        tmProGUI.text = hiddenText;
    }
}
