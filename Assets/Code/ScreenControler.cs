using UnityEngine;
using UnityEngine.Device;
using UnityEngine.UI;

public class ScreenControler : MonoBehaviour
{
    public GameObject screens;
    public GameObject SpelWereld;
    public GameObject WereldSelect;

    public Button exitWereld;
    public void ExitWereld()
    {
        SpelWereld.SetActive(false);
        WereldSelect.SetActive(true);
    }

    void Start()
    {
        SpelWereld = screens.transform.Find("SpelWereld").gameObject;

    }
}
