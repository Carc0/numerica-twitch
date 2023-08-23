using System;
using System.Collections;
using UnityEngine;

public class TalloController : MonoBehaviour
{
    [SerializeField] private MacetaController macetaController;

    [SerializeField] private HojaController hojaLeftController;
    [SerializeField] private HojaController hojaRightController;

    private bool isCreated;

    private int witherLeafSeconds = 60;
    private bool canPlantDie;

    public bool IsCreated { get => isCreated; set => isCreated = value; }
    public bool CanPlantDie { get => canPlantDie; set => canPlantDie = value; }
    public int WitherLeafSeconds { get => witherLeafSeconds; set => witherLeafSeconds = value; }


    private void Awake()
    {
        isCreated = false;
    }

    public void CreateTallo()
    {
        if (isCreated) return;

        if (macetaController.PointerTallo > 9) return;

        if (macetaController.WaterNumber < 1) return;

        gameObject.SetActive(true);

        isCreated = true;

        macetaController.CreatedTallo();
    }

    public void WaterHoja(PlantEnums.HojaType _hojaType)
    {
        if (!isCreated) return;

        if (macetaController.WaterNumber < 1) return;

        bool wateredHoja;

        if (_hojaType == PlantEnums.HojaType.Left)
            wateredHoja = hojaLeftController.SetWater();
        else
            wateredHoja = hojaRightController.SetWater();

        if (wateredHoja)
            macetaController.WateredHoja();
    }

    public void SetSecondsWitherLeaf(int _seconds)
    {
        hojaLeftController.DamageSeconds = _seconds;
        hojaRightController.DamageSeconds = _seconds;
    }

    public void SetPlantCanDie(bool _active)
    {
        hojaLeftController.CanDie = _active;
        hojaRightController.CanDie = _active;
    }
}