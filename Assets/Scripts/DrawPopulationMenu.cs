using System.Collections.Generic;
using System.Linq;
using Population;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DrawPopulationMenu : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private GameObject layout;
    
    private static GameObject _prefab;
    private static GameObject _layout;
    private static readonly List<GameObject> ObjectsForDestroy = new();

    public static void DestroyObjects()
    {
        foreach (var destroyObject in ObjectsForDestroy)
            Destroy(destroyObject);
    }

    public void Start()
    {
        _prefab = prefab;
        _layout = layout;
    }

    // ReSharper disable Unity.PerformanceAnalysis
    private static GameObject UpdatePrefabByPopulation(IPopulation population)
    {
        var prefabObject = _prefab;
        prefabObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = population.Name;

        return prefabObject;
    }

    public static void DrawObjects()
    {
        foreach (var population in Program.OpenPopulations)
        {
            var instance = Instantiate(UpdatePrefabByPopulation(population), _layout.transform);
            var button = instance.transform.GetChild(0).GetComponent<Button>();
            button.image.sprite = population.Sprites.SpriteOfMenu;
            button.onClick.AddListener(() => AddButtonManager(population));
            ObjectsForDestroy.Add(instance);
        }

        foreach (var unionPopulation in Program.TryOpenPopulations.Where(population =>
                     !Program.OpenPopulations.Contains(population))) 
        {
            var instance = Instantiate(UpdatePrefabByPopulation(unionPopulation), _layout.transform);
            var button = instance.transform.GetChild(0).GetComponent<Button>();
            button.image.sprite = unionPopulation.Sprites.LockSpriteMenu;
            ObjectsForDestroy.Add(instance);
        }
    }

    private static void AddButtonManager(IPopulation population)
    {
        if (!Program.OpenPopulations.Contains(population))
            return;
        
        UpdateCurrentPopulation.CurrentPopulation = population;
        UpdateCurrentPopulation.NeedsUpdatePopulation = true;
    }
}
