using Parameters;
using Population;
using Population.Implementation;
using TMPro;
using UnityEngine;

public class PopulationCountSetting : MonoBehaviour
{
    [SerializeField] private TMP_InputField populationCount;

    public void Start()
    {
        populationCount.text = PopulationCount.DefaultValue.ToString();
        PopulationCount.Value = PopulationCount.DefaultValue;
        
        populationCount.onEndEdit.AddListener(value =>
        {
            // PopulationCount.Value = null;
            populationCount.text = value;
            // Program.Population.Parameters.Count = PopulationCount.Value;
        });
    }
}
