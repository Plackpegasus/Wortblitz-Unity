using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{
    public string text;
    public int scoreOnKill = 20;
    public Vector2 dropSpeedMinMax;

    private float randomSpeed;

    // Start is called before the first frame update
    void Start()
    {
        GetComponentInChildren<TextMeshPro>().text = text;

        randomSpeed = Random.Range(dropSpeedMinMax.x, dropSpeedMinMax.y);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float speed = -randomSpeed * Time.fixedDeltaTime;
        transform.Translate(new Vector2(0f, speed));
    }
}
