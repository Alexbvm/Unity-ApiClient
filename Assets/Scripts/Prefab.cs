using UnityEngine;

public class Prefab : MonoBehaviour
{
    public Applicatie applicatie;
    public Vector3 spawnPositie;
    public GameObject prefab;
    public GameObject canvas;

    public void CreateInstanceOfPrefbad()
    {
        GameObject instanceOfPrefab = Instantiate(prefab, spawnPositie, Quaternion.identity);
        DiceGame diceGame = instanceOfPrefab.GetComponent<DiceGame>();
        diceGame.canvas = canvas;
        Object2D giveObject = new Object2D();
        giveObject.positionX = spawnPositie.x;
        giveObject.positionY = spawnPositie.y;
        giveObject.sortingLayer = 0;
        giveObject.rotationZ = prefab.transform.rotation.eulerAngles.z;
        giveObject.scaleX = prefab.transform.localScale.x;
        giveObject.scaleY = prefab.transform.localScale.y;
        giveObject.prefabId = prefab.name;
        applicatie.CreateObject2D(giveObject);  
    }


}
