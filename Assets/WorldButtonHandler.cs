using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;
using UnityEngine.Device;

public class WorldButtonHandler : MonoBehaviour
{
    public TMP_InputField wereld1;
    public TMP_InputField wereld2;
    public TMP_InputField wereld3;
    public TMP_InputField wereld4;
    public TMP_InputField wereld5;

    public Applicatie applicatie;

    public Button knopWereld1;
    public Button knopWereld2;
    public Button knopWereld3;
    public Button knopWereld4;
    public Button knopWereld5;

    public Button deleteKnopWereld1;
    public Button deleteKnopWereld2;
    public Button deleteKnopWereld3;
    public Button deleteKnopWereld4;
    public Button deleteKnopWereld5;

    private GameObject SpelWereld;
    private GameObject WereldSelect;
    public GameObject screens;
    void Start()
    {
        WereldSelect = screens.transform.Find("WereldSelect").gameObject;
        SpelWereld = screens.transform.Find("SpelWereld").gameObject;
    }

    [SerializeField] private Environment2DApiClient environment;

    public string huidigeKnopText;
    public int huidigeKnop;
    public void knop1Ingedrukt()
    {
        huidigeKnop = 1;
        applicatie.ReadObject2Ds(0);
        Debug.Log(wereld1.text);
        WereldSelect.SetActive(false);
        SpelWereld.SetActive(true);
    }
    public void DeleteKnop1Ingedrukt()
    {
        applicatie.DeleteEnvironment2D(applicatie.wereld1Id);
    }
    public void knop2Ingedrukt()
    {
        huidigeKnop = 2;
        applicatie.ReadObject2Ds(1);
        WereldSelect.SetActive(false);
        SpelWereld.SetActive(true);
    }
    public void DeleteKnop2Ingedrukt()
    {
        applicatie.DeleteEnvironment2D(applicatie.wereld2Id);
    }
    public void knop3Ingedrukt()
    {
        huidigeKnop = 3;
        applicatie.ReadObject2Ds(2);
        WereldSelect.SetActive(false);
        SpelWereld.SetActive(true);
    }
    public void DeleteKnop3Ingedrukt()
    {
        applicatie.DeleteEnvironment2D(applicatie.wereld3Id);
    }
    public void knop4Ingedrukt()
    {
        huidigeKnop = 4;
        applicatie.ReadObject2Ds(3);
        WereldSelect.SetActive(false);
        SpelWereld.SetActive(true);
    }
    public void DeleteKnop4Ingedrukt()
    {
        applicatie.DeleteEnvironment2D(applicatie.wereld4Id);
    }
    public void knop5Ingedrukt()
    {
        huidigeKnop = 5;
        applicatie.ReadObject2Ds(4);
        WereldSelect.SetActive(false);
        SpelWereld.SetActive(true);
    }
    public void DeleteKnop5Ingedrukt()
    {
        applicatie.DeleteEnvironment2D(applicatie.wereld5Id);
    }

    public void Wereld1AanMaken()
    {
        huidigeKnop = 1;
        applicatie.CreateEnvironment2D();
    }

    public void Wereld2AanMaken()
    {
        huidigeKnop = 2;
        applicatie.CreateEnvironment2D();
    }

    public void Wereld3AanMaken()
    {
        huidigeKnop = 3;
        applicatie.CreateEnvironment2D();
    }

    public void Wereld4AanMaken()
    {
        huidigeKnop = 4;
        applicatie.CreateEnvironment2D();
    }

    public void Wereld5AanMaken()
    {
        huidigeKnop = 5;
        applicatie.CreateEnvironment2D();
    }


    public string wereldAanmaken()
    {
        if(huidigeKnop == 1)
        {
           huidigeKnopText = wereld1.text;
            Debug.Log("huidigeknop 1 test");
           return wereld1.text;
        }
        if (huidigeKnop == 2)
        { 
            huidigeKnopText = wereld2.text;
            
            return wereld2.text;
        }
        if (huidigeKnop == 3)
        {
            huidigeKnopText = wereld3.text;
            return wereld3.text;
        }
        if (huidigeKnop == 4)
        {
            huidigeKnopText = wereld4.text;
            return wereld4.text;
        }
        else if (huidigeKnop == 5)
        {
            huidigeKnopText = wereld5.text;
            return wereld5.text;
        }
        return "kaas";
    }
}
