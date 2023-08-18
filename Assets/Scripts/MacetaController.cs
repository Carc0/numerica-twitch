using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MacetaController : MonoBehaviour
{
    [SerializeField] private Image waterImage;
    [SerializeField] private TalloController[] talloControllerArray;

    [SerializeField] private TMP_InputField secondsInputField;

    private int waterNumber;

    private int pointerTallo;


    private void Start()
    {
        pointerTallo = 0;
        waterNumber = 0;

        waterImage.fillAmount = 0;
    }

    public void SetWaterHoja(int _response)
    {
        if (waterNumber == 0) return;

        int talloNumber = Mathf.Abs(_response) - 1;

        bool takeOffWater = talloControllerArray[talloNumber].SetWaterHoja(_response);

        if (takeOffWater)
            TakeOffWater();
    }

    public void CreateTallo()
    {
        if (pointerTallo > 9) return;

        if (waterNumber == 0) return;

        talloControllerArray[pointerTallo].CreateTallo();

        TakeOffWater();

        pointerTallo++;
    }

    public void FillWater()
    {
        waterNumber = 10;
        waterImage.fillAmount = 1;
    }

    private void TakeOffWater()
    {
        waterNumber--;
        waterImage.fillAmount = waterNumber / 10.0f;
    }

    public void SetSecondsWitherLeaf()
    {
        int seconds = int.Parse(secondsInputField.text);

        foreach (TalloController talloController in talloControllerArray)
        {
            talloController.SetSecondsWitherLeaf(seconds);
        }
    }
}
