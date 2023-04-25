using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerHealth : MonoBehaviour
{
    public static event Action Die;
    [SerializeField] private int maxHealth;
    [SerializeField] private RectTransform parent;
    [SerializeField] private Sprite sprite;
    [SerializeField] private Vector2 firstPos;
    [SerializeField] private Vector2 size;
    [SerializeField] private Vector3 rotation;
    [SerializeField] private float distance;
    [SerializeField] private Color[] colors;
    private GameObject[] display;
    private int health;

    void Start()
    {
        health = maxHealth;
        display = new GameObject[maxHealth];
        spawnHealthDisplay();
    }

    private void spawnHealthDisplay()
    {
        for (int i = 0; i < maxHealth; i++)
        {
            GameObject go = new GameObject();

            go.transform.parent = parent;
            RectTransform rT = go.AddComponent<RectTransform>();
            rT.anchorMin = Vector2.up;
            rT.anchorMax = Vector2.up;
            rT.anchoredPosition = firstPos + Vector2.right * i * distance;
            rT.sizeDelta = size;
            rT.localScale = new Vector3(1, 1, 1);
            rT.rotation = Quaternion.Euler(rotation);

            Image image = go.AddComponent<Image>();
            image.sprite = sprite;

            ColorChanger cC = go.AddComponent<ColorChanger>();
            cC.SetType(2);
            cC.SetColors(colors);
            cC.SetSpeed(.1f);

            display[i] = go;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.CompareTag("Enemy"))
        {
            health--;
            Destroy(display[health]);
            if (health <= 0)
                Die?.Invoke();
        }
    }
}
