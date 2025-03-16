using _Game;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(TextMeshProUGUI))]
public class FillText : MonoBehaviour
{
    [SerializeField] private Image _image; 
    private TextMeshProUGUI _text;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        Fill.OnFillChange += Show;
        Show();
    }

    private void OnDisable()
    {
        Fill.OnFillChange -= Show;
    }

    private void Show(float value = 0)
    {
        _image.fillAmount = Fill.fill;
        var fill = (int) (Fill.fill * 100f);
        _text.SetText(fill.ToString() + "%");
    }
}
