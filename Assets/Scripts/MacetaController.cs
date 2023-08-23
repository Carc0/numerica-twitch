using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class MacetaController : MonoBehaviour
{
    [SerializeField] private Image waterImage;

    [SerializeField] private TMP_InputField secondsInputField;
    [SerializeField] private Toggle plantInmunityToggle;

    [SerializeField] private TalloController[] talloControllers;

    private int waterNumber;

    private int pointerTallo;

    public int PointerTallo { get => pointerTallo; set => pointerTallo = value; }
    public int WaterNumber { get => waterNumber; set => waterNumber = value; }

    public event Action<int> OnSecondsWitherLeaf;
    public event Action<bool> OnCanPlantDie;


    private void Start()
    {
        pointerTallo = 0;

        waterNumber = 0;
        waterImage.fillAmount = 0;
    }

    public void WaterHojaCommand(int _response)
    {
        //if (waterNumber < 1) return;

        int talloNumber = Mathf.Abs(_response) - 1;

        PlantEnums.HojaType hojaType = (_response < 0) ? PlantEnums.HojaType.Left : PlantEnums.HojaType.Right;

        CommandQueue.Instance.AddCommand(new WaterHojaCommand(talloControllers[talloNumber], hojaType));
    }

    public void CreateTalloCommand()
    {
        if (pointerTallo > 9) return;

        //if (waterNumber < 1) return;

        CommandQueue.Instance.AddCommand(new CreateTalloCommand(talloControllers[pointerTallo]));

        //TakeOffWater();

        //pointerTallo++;
    }

    public void CreatedTallo()
    {
        pointerTallo++;

        TakeOffWater();
    }

    public void WateredHoja()
    {
        TakeOffWater();
    }

    public void FillWater()
    {
        waterNumber = 10;
        waterImage.fillAmount = 1;
    }

    private void TakeOffWater()
    {
        waterNumber--;

        waterNumber = Mathf.Max(0, waterNumber);

        waterImage.fillAmount = waterNumber / 10.0f;
    }

    public void SetSecondsWitherLeaf()
    {
        int seconds = int.Parse(secondsInputField.text);

        foreach (TalloController talloController in talloControllers)
        {
            talloController.SetSecondsWitherLeaf(seconds);
        }
    }

    public void SetCanPlantDie()
    {
        bool canPlantDie = plantInmunityToggle.isOn;

        foreach (TalloController talloController in talloControllers)
        {
            talloController.SetPlantCanDie(canPlantDie);
        }
    }
}
