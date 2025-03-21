using UnityEngine;
using UnityEngine.Device;
using UnityEngine.UI;

public class ScreenControler : MonoBehaviour
{
    public GameObject screens;
    public GameObject SpelWereld;
    public GameObject WereldSelect;

    public Button exitWereld;

    public void ClearPrefabs()
    {
        DiceGame[] draggableObjects = FindObjectsByType<DiceGame>(FindObjectsSortMode.None);

        foreach (DiceGame draggable in draggableObjects)
        {
            Destroy(draggable.gameObject);
        }

    }

    public void ExitWereld()
    {
        ClearPrefabs();   
        SpelWereld.SetActive(false);
        WereldSelect.SetActive(true);
    }

    void Start()
    {
        SpelWereld = screens.transform.Find("SpelWereld").gameObject;

    }
}
