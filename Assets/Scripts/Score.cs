using System;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour, IObserver<int>
{
    public int playerScore = 0;
    public int faultScore = 0;
    public int scoreToBoss = 200;
    public Despawn despawnScript;
    public TextMeshProUGUI text;

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
        playerScore += value;
        Debug.Log("player gained: " + value + "; current score: " + playerScore);
    }


    // Start is called before the first frame update
    void Start()
    {
        Subscribe(despawnScript);
    }

    // Update is called once per frame
    void Update()
    {
        text.text = playerScore.ToString();
    }
}
