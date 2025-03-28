using UnityEngine;

public class Prefab : MonoBehaviour
{
    public Applicatie applicatie;
    public Vector3 spawnPositie;
    public GameObject prefab;
    public GameObject canvas;
    //public Object2D giveObject = new Object2D();
    

    public void CreateInstanceOfPrefbad()
    {
        GameObject instanceOfPrefab = Instantiate(prefab, spawnPositie, Quaternion.identity);
        DiceGame diceGame = instanceOfPrefab.GetComponent<DiceGame>();
        diceGame.canvas = canvas;

        diceGame.giveObject.positionX = spawnPositie.x;
        diceGame.giveObject.positionY = spawnPositie.y;
        diceGame.giveObject.sortingLayer = 0;
        diceGame.giveObject.rotationZ = prefab.transform.rotation.eulerAngles.z;
        diceGame.giveObject.scaleX = prefab.transform.localScale.x;
        diceGame.giveObject.scaleY = prefab.transform.localScale.y;
        diceGame.giveObject.prefabId = prefab.name;
    }


}
