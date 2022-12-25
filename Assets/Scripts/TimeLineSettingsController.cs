using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimeLineSettingsController : MonoBehaviour
{
    private TMP_InputField _daysValue;
    private Slider _daysSlider;
    private TMP_InputField _monthValue;
    private Slider _monthSlider;
    private TMP_InputField _yearsValue;
    private Slider _yearsSlider;

    private Button _resetButton;
    
    private void Awake()
    {
        _daysValue = transform.GetChild(1).GetChild(2).GetComponent<TMP_InputField>();
        _daysSlider = transform.GetChild(1).GetChild(1).GetComponent<Slider>();
        _monthValue = transform.GetChild(2).GetChild(2).GetComponent<TMP_InputField>();
        _monthSlider = transform.GetChild(2).GetChild(1).GetComponent<Slider>();
        _yearsValue = transform.GetChild(3).GetChild(2).GetComponent<TMP_InputField>();
        _yearsSlider = transform.GetChild(3).GetChild(1).GetComponent<Slider>();
        
        _resetButton = transform.GetChild(4).GetChild(0).GetComponent<Button>();
    }
    
    public void Start()
    {
        _daysValue.onValueChanged.AddListener(value => TimeController.DaysCount = int.Parse(value));
        _daysSlider.onValueChanged.AddListener(value => TimeController.DaysCount = (int) value);
        
        _monthValue.onValueChanged.AddListener(value => TimeController.MonthCount = int.Parse(value));
        _monthSlider.onValueChanged.AddListener(value => TimeController.MonthCount = (int) value);
        
        _yearsValue.onValueChanged.AddListener(value => TimeController.YearsCount = int.Parse(value));
        _yearsSlider.onValueChanged.AddListener(value => TimeController.YearsCount = (int) value);
        
        _resetButton.onClick.AddListener(ResetValues);
    }
    
    private void Update()
    {
        UpdateTextPanels();
        UpdateSliderValues();
        if (TimeController.DaysLeft <= 0)
            TimeController.Day = 0;
    }

    private void UpdateTextPanels()
    {
        _daysValue.text = TimeController.DaysCount.ToString(CultureInfo.InvariantCulture);
        _monthValue.text = TimeController.MonthCount.ToString(CultureInfo.InvariantCulture);
        _yearsValue.text = TimeController.YearsCount.ToString(CultureInfo.InvariantCulture);
    }

    private void UpdateSliderValues()
    {
        _daysSlider.value = TimeController.DaysCount;
        _monthSlider.value = TimeController.MonthCount;
        _yearsSlider.value = TimeController.YearsCount;
    }

    private static void ResetValues()
    {
        TimeController.DaysCount = 0;
        TimeController.MonthCount = 0;
        TimeController.YearsCount = 0;
    }
}
