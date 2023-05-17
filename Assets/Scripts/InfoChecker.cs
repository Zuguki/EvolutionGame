using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class InfoChecker : MonoBehaviour
{
    [FormerlySerializedAs("infoObject")] [SerializeField] private GameObject simpleObject;
    [SerializeField] private GameObject mediumObject;

    private TextMeshProUGUI _simpleText;
    private Button _simpleButton;
    
    private TextMeshProUGUI _mediumTitle;
    private TextMeshProUGUI _mediumText;
    private Button _mediumButton;

    private static string _newTitle;
    private static string _newText;
    private static bool _needsUpdateSimple;
    private static bool _needsUpdateMedium;

    public static void ChangeSimpleItem(string text)
    {
        _newText = text;
        _needsUpdateSimple = true;
    }

    public static void ChangeMediumItem(string title, string text)
    {
        _newTitle = title;
        _newText = text;
        _needsUpdateMedium = true;
    }

    private void Awake()
    {
        _simpleText = simpleObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        _simpleButton = simpleObject.transform.GetChild(1).GetComponent<Button>();

        _mediumTitle = mediumObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        _mediumText = mediumObject.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
        _mediumButton = mediumObject.transform.GetChild(2).GetComponent<Button>();
        
        _simpleButton.onClick.AddListener(() => simpleObject.SetActive(false));
        _mediumButton.onClick.AddListener(() => mediumObject.SetActive(false));
    }

    private void Update()
    {
        if (!_needsUpdateSimple && !_needsUpdateMedium)
            return;

        if (_needsUpdateSimple)
        {
            _simpleText.text = _newText;
            simpleObject.SetActive(true);
            _needsUpdateSimple = false;
        }
        else if (_needsUpdateMedium)
        {
            _mediumTitle.text = _newTitle;
            _mediumText.text = _newText;
            mediumObject.SetActive(true);
            _needsUpdateMedium = false;
        }
    }
}
