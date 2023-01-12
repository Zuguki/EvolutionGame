using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InfoChecker : MonoBehaviour
{
    [SerializeField] private GameObject infoObject;

    private TextMeshProUGUI _title;
    private TextMeshProUGUI _text;
    private Button _button;

    private static string _newText;
    private static bool _needsUpdate;

    public static void ChangeItems(string text)
    {
        _newText = text;
        _needsUpdate = true;
    }

    private void Awake()
    {
        _text = infoObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        _button = infoObject.transform.GetChild(1).GetComponent<Button>();
        
        _button.onClick.AddListener(() => infoObject.SetActive(false));
    }

    private void Update()
    {
        if (!_needsUpdate)
            return;

        _text.text = _newText;
        infoObject.SetActive(true);
        _needsUpdate = false;
    }
}
