using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnableInfo : MonoBehaviour
{
    public TextMeshProUGUI DescriptionLabel;
    public string Description;
    public float TimeInSeconds;
    //public Sprite Logo;

    public void InitiateDescriptionLabel(TextMeshProUGUI label)
    {
        DescriptionLabel = label;
        DescriptionLabel.text = Description;
    }
    public void SetLogo()
    {

    }
}
