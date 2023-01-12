using System;
using UnityEngine;

public class SpritesManager : MonoBehaviour
{
    [SerializeField] private Sprite humanSprite;
    [SerializeField] private Sprite fireHumanSprite;
    [SerializeField] private Sprite coldHumanSprite;
    [SerializeField] private Sprite radiationHumanSprite;
    
     [SerializeField] private Sprite lockFireHumanSprite;
     [SerializeField] private Sprite lockColdHumanSprite;
     [SerializeField] private Sprite lockRadiationHumanSprite;   

    [SerializeField] private Sprite humanPopulationSprite;
    [SerializeField] private Sprite fireHumanPopulationSprite;
    [SerializeField] private Sprite coldHumanPopulationSprite;
    [SerializeField] private Sprite radiationHumanPopulationSprite;
    [SerializeField] private Sprite defaultPopulationSprite;

    public static Sprite HumanSprite;
    public static Sprite FireHumanSprite;
    public static Sprite ColdHumanSprite;
    public static Sprite RadiationHumanSprite;

    public static Sprite LockFireHumanSprite;
    public static Sprite LockColdHumanSprite;
    public static Sprite LockRadiationHumanSprite;
    
    public static Sprite HumanPopulationSprite;
    public static Sprite FireHumanPopulationSprite;
    public static Sprite ColdHumanPopulationSprite;
    public static Sprite RadiationHumanPopulationSprite;
    public static Sprite DefaultPopulationSprite;

    private void Start()
    {
        HumanSprite = humanSprite;
        FireHumanSprite = fireHumanSprite;
        ColdHumanSprite = coldHumanSprite;
        RadiationHumanSprite = radiationHumanSprite;

        LockFireHumanSprite = lockFireHumanSprite;
        LockColdHumanSprite = lockColdHumanSprite;
        LockRadiationHumanSprite = lockRadiationHumanSprite;

        HumanPopulationSprite = humanPopulationSprite;
        FireHumanPopulationSprite = fireHumanPopulationSprite;
        ColdHumanPopulationSprite = coldHumanPopulationSprite;
        RadiationHumanPopulationSprite = radiationHumanPopulationSprite;
        DefaultPopulationSprite = defaultPopulationSprite;
    }
}