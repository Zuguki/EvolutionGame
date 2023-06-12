using System;
using UnityEngine;
using UnityEngine.Serialization;

public class SpritesManager : MonoBehaviour
{
    [SerializeField] private Sprite defaultPopulationSprite;
    
    [SerializeField] private Sprite humanSprite;
    [SerializeField] private Sprite humanSprite1;
    [SerializeField] private Sprite humanPopulationSprite2_10;
    [SerializeField] private Sprite humanPopulationSprite10_100;
    [SerializeField] private Sprite humanPopulationSprite100_1000;
    [SerializeField] private Sprite humanPopulationSprite1000_10000;
    [SerializeField] private Sprite humanPopulationSprite10000_100000;
    [SerializeField] private Sprite humanPopulationSprite100000_1000000;
    [SerializeField] private Sprite humanPopulationSprite1000000_10000000;
    [SerializeField] private Sprite humanPopulationSprite10000000_100000000;
    [SerializeField] private Sprite humanPopulationSprite100000000_1000000000;
    [SerializeField] private Sprite humanPopulationSprite1000000000_10000000000;
    
    [SerializeField] private Sprite fireHumanSprite;
    [SerializeField] private Sprite lockFireHumanSprite;
    [SerializeField] private Sprite fireHumanSprite1;
    [SerializeField] private Sprite fireHumanPopulationSprite2_10;
    [SerializeField] private Sprite fireHumanPopulationSprite10_100;
    [SerializeField] private Sprite fireHumanPopulationSprite100_1000;
    [SerializeField] private Sprite fireHumanPopulationSprite1000_10000;
    [SerializeField] private Sprite fireHumanPopulationSprite10000_100000;
    [SerializeField] private Sprite fireHumanPopulationSprite100000_1000000;
    [SerializeField] private Sprite fireHumanPopulationSprite1000000_10000000;
    [SerializeField] private Sprite fireHumanPopulationSprite10000000_100000000;
    [SerializeField] private Sprite fireHumanPopulationSprite100000000_1000000000;
    [SerializeField] private Sprite fireHumanPopulationSprite1000000000_10000000000;
    
    [SerializeField] private Sprite coldHumanSprite;
    [SerializeField] private Sprite lockColdHumanSprite;
    [SerializeField] private Sprite coldHumanSprite1;
    [SerializeField] private Sprite coldHumanPopulationSprite2_10;
    [SerializeField] private Sprite coldHumanPopulationSprite10_100;
    [SerializeField] private Sprite coldHumanPopulationSprite100_1000;
    [SerializeField] private Sprite coldHumanPopulationSprite1000_10000;
    [SerializeField] private Sprite coldHumanPopulationSprite10000_100000;
    [SerializeField] private Sprite coldHumanPopulationSprite100000_1000000;
    [SerializeField] private Sprite coldHumanPopulationSprite1000000_10000000;
    [SerializeField] private Sprite coldHumanPopulationSprite10000000_100000000;
    [SerializeField] private Sprite coldHumanPopulationSprite100000000_1000000000;
    [SerializeField] private Sprite coldHumanPopulationSprite1000000000_10000000000;
    
    [SerializeField] private Sprite radiationHumanSprite;
    [SerializeField] private Sprite lockRadiationHumanSprite;
    [SerializeField] private Sprite radiationHumanSprite1;
    [SerializeField] private Sprite radiationHumanPopulationSprite2_10;
    [SerializeField] private Sprite radiationHumanPopulationSprite10_100;
    [SerializeField] private Sprite radiationHumanPopulationSprite100_1000;
    [SerializeField] private Sprite radiationHumanPopulationSprite1000_10000;
    [SerializeField] private Sprite radiationHumanPopulationSprite10000_100000;
    [SerializeField] private Sprite radiationHumanPopulationSprite100000_1000000;
    [SerializeField] private Sprite radiationHumanPopulationSprite1000000_10000000;
    [SerializeField] private Sprite radiationHumanPopulationSprite10000000_100000000;
    [SerializeField] private Sprite radiationHumanPopulationSprite100000000_1000000000;
    [SerializeField] private Sprite radiationHumanPopulationSprite1000000000_10000000000;

    public static Sprite DefaultPopulationSprite;
    
    public static Sprite HumanSprite;
    public static Sprite HumanSprite1;
    public static Sprite HumanPopulationSprite2_10;
    public static Sprite HumanPopulationSprite10_100;
    public static Sprite HumanPopulationSprite100_1000;
    public static Sprite HumanPopulationSprite1000_10000;
    public static Sprite HumanPopulationSprite10000_100000;
    public static Sprite HumanPopulationSprite100000_1000000;
    public static Sprite HumanPopulationSprite1000000_10000000;
    public static Sprite HumanPopulationSprite10000000_100000000;
    public static Sprite HumanPopulationSprite100000000_1000000000;
    public static Sprite HumanPopulationSprite1000000000_10000000000;
    
    public static Sprite FireHumanSprite;
    public static Sprite LockFireHumanSprite;
    public static Sprite FireHumanSprite1;
    public static Sprite FireHumanPopulationSprite2_10;
    public static Sprite FireHumanPopulationSprite10_100;
    public static Sprite FireHumanPopulationSprite100_1000;
    public static Sprite FireHumanPopulationSprite1000_10000;
    public static Sprite FireHumanPopulationSprite10000_100000;
    public static Sprite FireHumanPopulationSprite100000_1000000;
    public static Sprite FireHumanPopulationSprite1000000_10000000;
    public static Sprite FireHumanPopulationSprite10000000_100000000;
    public static Sprite FireHumanPopulationSprite100000000_1000000000;
    public static Sprite FireHumanPopulationSprite1000000000_10000000000;
    
    public static Sprite ColdHumanSprite;
    public static Sprite LockColdHumanSprite;
    public static Sprite ColdHumanSprite1;
    public static Sprite ColdHumanPopulationSprite2_10;
    public static Sprite ColdHumanPopulationSprite10_100;
    public static Sprite ColdHumanPopulationSprite100_1000;
    public static Sprite ColdHumanPopulationSprite1000_10000;
    public static Sprite ColdHumanPopulationSprite10000_100000;
    public static Sprite ColdHumanPopulationSprite100000_1000000;
    public static Sprite ColdHumanPopulationSprite1000000_10000000;
    public static Sprite ColdHumanPopulationSprite10000000_100000000;
    public static Sprite ColdHumanPopulationSprite100000000_1000000000;
    public static Sprite ColdHumanPopulationSprite1000000000_10000000000;
    
    public static Sprite RadiationHumanSprite;
    public static Sprite LockRadiationHumanSprite;
    public static Sprite RadiationHumanSprite1;
    public static Sprite RadiationHumanPopulationSprite2_10;
    public static Sprite RadiationHumanPopulationSprite10_100;
    public static Sprite RadiationHumanPopulationSprite100_1000;
    public static Sprite RadiationHumanPopulationSprite1000_10000;
    public static Sprite RadiationHumanPopulationSprite10000_100000;
    public static Sprite RadiationHumanPopulationSprite100000_1000000;
    public static Sprite RadiationHumanPopulationSprite1000000_10000000;
    public static Sprite RadiationHumanPopulationSprite10000000_100000000;
    public static Sprite RadiationHumanPopulationSprite100000000_1000000000;
    public static Sprite RadiationHumanPopulationSprite1000000000_10000000000;

    private void Start()
    {
        DefaultPopulationSprite = defaultPopulationSprite;
        
        HumanSprite = humanSprite;
        HumanSprite1 = humanSprite1;
        HumanPopulationSprite2_10 = humanPopulationSprite2_10;
        HumanPopulationSprite10_100 = humanPopulationSprite10_100;
        HumanPopulationSprite100_1000 = humanPopulationSprite100_1000;
        HumanPopulationSprite1000_10000 = humanPopulationSprite1000_10000;
        HumanPopulationSprite10000_100000 = humanPopulationSprite10000_100000;
        HumanPopulationSprite100000_1000000 = humanPopulationSprite100000_1000000;
        HumanPopulationSprite1000000_10000000 = humanPopulationSprite1000000_10000000;
        HumanPopulationSprite10000000_100000000 = humanPopulationSprite10000000_100000000;
        HumanPopulationSprite100000000_1000000000 = humanPopulationSprite100000000_1000000000;
        HumanPopulationSprite1000000000_10000000000 = humanPopulationSprite1000000000_10000000000;

        FireHumanSprite = fireHumanSprite;
        LockFireHumanSprite = lockFireHumanSprite;
        FireHumanSprite1 = fireHumanSprite1;
        FireHumanPopulationSprite2_10 = fireHumanPopulationSprite2_10;
        FireHumanPopulationSprite10_100 = fireHumanPopulationSprite10_100;
        FireHumanPopulationSprite100_1000 = fireHumanPopulationSprite100_1000;
        FireHumanPopulationSprite1000_10000 = fireHumanPopulationSprite1000_10000;
        FireHumanPopulationSprite10000_100000 = fireHumanPopulationSprite10000_100000;
        FireHumanPopulationSprite100000_1000000 = fireHumanPopulationSprite100000_1000000;
        FireHumanPopulationSprite1000000_10000000 = fireHumanPopulationSprite1000000_10000000;
        FireHumanPopulationSprite10000000_100000000 = fireHumanPopulationSprite10000000_100000000;
        FireHumanPopulationSprite100000000_1000000000 = fireHumanPopulationSprite100000000_1000000000;
        FireHumanPopulationSprite1000000000_10000000000 = fireHumanPopulationSprite1000000000_10000000000;
        
        ColdHumanSprite = coldHumanSprite;
        LockColdHumanSprite = lockColdHumanSprite;
        ColdHumanSprite1 = coldHumanSprite1;
        ColdHumanPopulationSprite2_10 = coldHumanPopulationSprite2_10;
        ColdHumanPopulationSprite10_100 = coldHumanPopulationSprite10_100;
        ColdHumanPopulationSprite100_1000 = coldHumanPopulationSprite100_1000;
        ColdHumanPopulationSprite1000_10000 = coldHumanPopulationSprite1000_10000;
        ColdHumanPopulationSprite10000_100000 = coldHumanPopulationSprite10000_100000;
        ColdHumanPopulationSprite100000_1000000 = coldHumanPopulationSprite100000_1000000;
        ColdHumanPopulationSprite1000000_10000000 = coldHumanPopulationSprite1000000_10000000;
        ColdHumanPopulationSprite10000000_100000000 = coldHumanPopulationSprite10000000_100000000;
        ColdHumanPopulationSprite100000000_1000000000 = coldHumanPopulationSprite100000000_1000000000;
        ColdHumanPopulationSprite1000000000_10000000000 = coldHumanPopulationSprite1000000000_10000000000;
        
        RadiationHumanSprite = radiationHumanSprite;
        LockRadiationHumanSprite = lockRadiationHumanSprite;
        RadiationHumanSprite1 = radiationHumanSprite1;
        RadiationHumanPopulationSprite2_10 = radiationHumanPopulationSprite2_10;
        RadiationHumanPopulationSprite10_100 = radiationHumanPopulationSprite10_100;
        RadiationHumanPopulationSprite100_1000 = radiationHumanPopulationSprite100_1000;
        RadiationHumanPopulationSprite1000_10000 = radiationHumanPopulationSprite1000_10000;
        RadiationHumanPopulationSprite10000_100000 = radiationHumanPopulationSprite10000_100000;
        RadiationHumanPopulationSprite100000_1000000 = radiationHumanPopulationSprite100000_1000000;
        RadiationHumanPopulationSprite1000000_10000000 = radiationHumanPopulationSprite1000000_10000000;
        RadiationHumanPopulationSprite10000000_100000000 = radiationHumanPopulationSprite10000000_100000000;
        RadiationHumanPopulationSprite100000000_1000000000 = radiationHumanPopulationSprite100000000_1000000000;
        RadiationHumanPopulationSprite1000000000_10000000000 = radiationHumanPopulationSprite1000000000_10000000000;
    }
}