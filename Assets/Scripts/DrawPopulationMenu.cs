using System.Collections.Generic;
using UnityEngine;

public class DrawPopulationMenu : MonoBehaviour
{
    public static bool NeedsDraw;
    public static bool NeedsDestroy;
    
    [SerializeField] private GameObject prefab;
    [SerializeField] private GameObject populationMenu;

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
            _destroyObjects.Add(Instantiate(prefab, transform));

        NeedsDraw = false;
    }
}
