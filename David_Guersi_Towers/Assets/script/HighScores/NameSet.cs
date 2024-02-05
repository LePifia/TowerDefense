using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NameSet : MonoBehaviour
{
    public string NameDisplay;
    public string NameSetted;
    [SerializeField] GameObject inputField;


    // Start is called before the first frame update

    private void Awake()
    {
        NameSetted = PlayerPrefs.GetString("NameRank");
    }
    public void NameSetter()
    {

        NameDisplay = inputField.GetComponent<TextMeshProUGUI>().text;

        PlayerPrefs.SetString("NameRank", NameDisplay);
    }

    public string Name()
    {
        return NameSetted;
    }
}
