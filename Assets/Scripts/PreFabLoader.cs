using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UIElements;

public class PrefabLoader : MonoBehaviour
{
    public GameObject Prefab1;
    public GameObject Prefab2;
    public GameObject Prefab3;
    public GameObject Prefab4;
    public GameObject Prefab5;
    public GameObject Prefab6;
    private GameObject UsedPrefab;

    public GameObject canvas;

    private Vector3 position;

    public void LoadPrefab(Object2D object2D)
    {
        switch (object2D.prefabId)
        {
            case "Square 1":
                UsedPrefab = Prefab1;
                break;
            case "Square 2":
                UsedPrefab = Prefab2;
                break;
            case "Square 3":
                UsedPrefab = Prefab3;
                break;
            case "Square 4":
                UsedPrefab = Prefab4;
                break;
            case "Square 5":
                UsedPrefab = Prefab5;
                break;
            case "Square 6":
                UsedPrefab = Prefab6;
                break;
            default:
                throw new System.NotImplementedException("Geen prefabs gevonden voor prefabId: " + object2D);
        }
        position.x = object2D.positionX;
        position.y = object2D.positionY;
        position.z = 0;
        GameObject newObject = Instantiate(UsedPrefab, position, Quaternion.identity);
        DiceGame diceGame = newObject.GetComponent<DiceGame>();
        diceGame.canvas = canvas;
        diceGame.isDragging = false;
        Debug.Log("Object Geplaatst");

    }
}