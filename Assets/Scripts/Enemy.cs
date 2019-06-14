using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{
    public Vector2 dropSpeedMinMax;
    public string text;

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
