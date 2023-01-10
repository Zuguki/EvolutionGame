using System.Collections.Generic;
using Population;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DrawPopulationMenu : MonoBehaviour
{
    public static bool NeedsDraw;
    public static bool NeedsDestroy;
    
    [SerializeField] private GameObject prefab;

    private readonly List<GameObject> _destroyObjects = new();

    private void Update()
    {
        if (NeedsDestroy)
        {
            foreach (var destroyObject in _destroyObjects)
                Destroy(destroyObject);
            NeedsDestroy = false;
        }
        if (!NeedsDraw)
            return;

        foreach (var population in Program.OpenPopulations)
            _destroyObjects.Add(Instantiate(UpdatePrefabByPopulation(population), transform));
        foreach (var unionPopulation in Program.TryOpenPopulations)
            _destroyObjects.Add(Instantiate(UpdatePrefabByPopulation(unionPopulation), transform));

        NeedsDraw = false;
    }

    // ReSharper disable Unity.PerformanceAnalysis
    private GameObject UpdatePrefabByPopulation(IPopulation population)
    {
        var prefabObject = prefab;
        var button = prefabObject.transform.GetChild(0).GetComponent<Button>();

        if (Program.OpenPopulations.Contains(population))
        {
            button.onClick.AddListener(() => Program.Population = population);
            button.image.color = Color.white;
        }
        else
            button.image.color = Color.red;
        prefabObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = population.Name;

        return prefabObject;
    }
}
