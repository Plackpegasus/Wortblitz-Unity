using System;
using UnityEngine;
using TMPro;

public class Boss : MonoBehaviour, IObserver<int>
{
    public Despawn despawnScript;

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
        
    }

    // Start is called before the first frame update
    void Start()
    {
        tmProGUI = GetComponentInChildren<TextMeshPro>();
        Debug.Log(tmProGUI);
        text = tmProGUI.text;

        foreach (var _ in text)
        {
            hiddenText += "X";
        }

        tmProGUI.text = hiddenText;
        Subscribe(despawnScript);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
