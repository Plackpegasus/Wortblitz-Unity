using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

public class Despawn : MonoBehaviour
{
    public TMP_InputField inputField;

    // Start is called before the first frame update
    void Start()
    {
        inputField.Select();
    }

    // Update is called once per frame
    void Update()
    {
        
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

                Destroy(enemy.gameObject);
                return;
            }
        }
    }
}
