using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour , IObserver<int>
{
    public int playerScore = 0;
    public int faultScore = 0;
    public int scoreToBoss = 200;
    public Despawn despawn;
    public TextMeshProUGUI text;

    private IDisposable unsubscribe;
    // private bool firstTime = true;
    // private int lastValue;

    public virtual void Subscribe(IObservable<int> provider)
    {
        unsubscribe = provider.Subscribe(this);
    }

    public virtual void Unsubscribe()
    {
        unsubscribe.Dispose();
    }

    public void OnCompleted()
    {
        // don't know yet
    }

    public void OnError(Exception error)
    {
        // don't know yet
    }

    public void OnNext(int value)
    {
        playerScore += value;
        Debug.Log("player gained " + value + "; current score: " + playerScore);
    }


    // Start is called before the first frame update
    void Start()
    {
        Subscribe(despawn);
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "";
        text.text = playerScore.ToString();
    }
}
