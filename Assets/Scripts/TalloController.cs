using System.Collections;
using UnityEngine;

public class TalloController : MonoBehaviour
{
    [SerializeField] private HojaController leftHojaController;
    [SerializeField] private HojaController rightHojaController;

    private bool isCreated;

    public bool IsCreated { get => isCreated; set => isCreated = value; }


    private void Awake()
    {
        isCreated = false;
    }

    public void CreateTallo()
    {
        gameObject.SetActive(true);

        isCreated = true;
    }

    public bool SetWaterHoja(int _response)
    {
        if (!isCreated) return false;

        bool setWater = false;

        if (_response < 0)
            setWater = leftHojaController.SetWater();
        else
            setWater = rightHojaController.SetWater();

        return setWater;
    }

    public void SetSecondsWitherLeaf(int _seconds)
    {
        leftHojaController.DamageSeconds = _seconds;
        rightHojaController.DamageSeconds = _seconds;
    }
}