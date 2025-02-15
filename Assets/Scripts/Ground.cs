using UnityEngine;

public class Ground : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject gameObject = collision.gameObject;

        if (gameObject.name.Contains("boss"))
        {
            Debug.LogError("Game over");
        }

        Destroy(gameObject);
    }
}
