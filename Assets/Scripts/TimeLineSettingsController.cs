using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimeLineSettingsController : MonoBehaviour
{
    [SerializeField] private Slider daysSlider;
    [SerializeField] private TMP_InputField daysValue;
    
    public void Start()
    {
        daysValue.onEndEdit.AddListener(value =>
        {
            if (Program.InProcess)
                return;
            
            TimeController.DaysCount = value.ToIntDef(1) ?? 1;
            daysValue.text = TimeController.DaysCount.ToString();
            daysSlider.value = TimeController.DaysCount;
        });
        daysSlider.onValueChanged.AddListener(value =>
        {
            if (Program.InProcess)
                return;
            
            TimeController.DaysCount = (int) value;
            daysValue.text = TimeController.DaysCount.ToString();
            daysSlider.value = TimeController.DaysCount;
        });
    }
}