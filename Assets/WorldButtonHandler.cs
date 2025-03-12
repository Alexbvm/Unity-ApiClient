using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

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



    [SerializeField] private Environment2DApiClient environment;

    public string huidigeKnopText;
    public int huidigeKnop;
    public void knop1Ingedrukt()
    {
        huidigeKnop = 1;
        applicatie.CreateEnvironment2D();
        applicatie.ReadObject2Ds();
        Debug.Log(wereld1.text);
    }
    public void DeleteKnop1Ingedrukt()
    {
        applicatie.DeleteEnvironment2D(applicatie.wereld1Id);
    }
    public void knop2Ingedrukt()
    {
        huidigeKnop = 2;
        applicatie.CreateEnvironment2D();
    }
    public void DeleteKnop2Ingedrukt()
    {
        applicatie.DeleteEnvironment2D(applicatie.wereld2Id);
    }
    public void knop3Ingedrukt()
    {
        huidigeKnop = 3;
        applicatie.CreateEnvironment2D();
    }
    public void DeleteKnop3Ingedrukt()
    {
        applicatie.DeleteEnvironment2D(applicatie.wereld3Id);
    }
    public void knop4Ingedrukt()
    {
        huidigeKnop = 4;
        applicatie.CreateEnvironment2D();
    }
    public void DeleteKnop4Ingedrukt()
    {
        applicatie.DeleteEnvironment2D(applicatie.wereld4Id);
    }
    public void knop5Ingedrukt()
    {
        huidigeKnop = 5;
        applicatie.CreateEnvironment2D();
    }
    public void DeleteKnop5Ingedrukt()
    {
        applicatie.DeleteEnvironment2D(applicatie.wereld5Id);
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
