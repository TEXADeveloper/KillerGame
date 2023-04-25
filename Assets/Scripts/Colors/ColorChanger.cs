using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] private Color[] colors;
    [SerializeField] private float changeSpeed;
    [SerializeField] private int type = 0;
    [SerializeField] private bool sync = true;
    private float lerp = 0;
    private float lerpSubstract = 0;
    private int colorSelected = 0;
    private SpriteRenderer sr;
    private TMP_Text text;
    private Image image;

    public void SetType(int value)
    {
        type = value;
    }

    public void SetSpeed(float value)
    {
        changeSpeed = value;
    }

    public void SetColors(Color[] array)
    {
        colors = array;
    }

    void Start()
    {
        if (type == 0)
            sr = this.GetComponent<SpriteRenderer>();
        else if (type == 1)
            text = this.GetComponent<TMP_Text>();
        else if (type == 2)
            image = this.GetComponent<Image>();
    }

    void Update()
    {
        changeColors();
    }

    void changeColors()
    {
        lerp = (sync) ? Time.time * changeSpeed - lerpSubstract : lerp + Time.deltaTime * changeSpeed;
        Color nextColor = colors[(colorSelected == colors.Length - 1) ? 0 : colorSelected + 1];
        if (type == 0)
            sr.color = Color.Lerp(colors[colorSelected], nextColor, lerp);
        else if (type == 1)
            text.color = Color.Lerp(colors[colorSelected], nextColor, lerp);
        else if (type == 2)
            image.color = Color.Lerp(colors[colorSelected], nextColor, lerp);

        if (lerp >= 1)
        {
            if (sync)
                lerpSubstract = Time.time * changeSpeed;
            else
                lerp = 0;
            colorSelected = (colorSelected + 1 == colors.Length) ? 0 : colorSelected + 1;
        }
    }
}
