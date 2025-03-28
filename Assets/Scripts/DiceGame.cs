using System;
using Unity.VisualScripting;
using UnityEngine;

/*
* The GameObject also needs a collider otherwise OnMouseUpAsButton() can not be detected.
*/
public class DiceGame : MonoBehaviour
{
    public Transform trans;

    public bool isDragging = true;
    public GameObject canvas;

    public Object2D giveObject;

    public void StartDragging()
    {
        isDragging = true;
    }

    public void Update()
    {
        if (isDragging)
        {
            trans.position = GetMousePosition();
            canvas.SetActive(false);
        }
        else
        {
            canvas.SetActive(true);
        }
    }
    

    private void OnMouseUpAsButton()
    {
        isDragging = !isDragging;
        Applicatie applicatie = FindFirstObjectByType<Applicatie>();
 
        if (!isDragging)
        {
            giveObject.positionX = trans.position.x;
            giveObject.positionY = trans.position.y;

            applicatie.CreateObject2D(giveObject);
            // Stopped dragging. Add any logic here that you need for this scenario.
        }
    }

    private Vector3 GetMousePosition()
    {
        Vector3 positionInWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        positionInWorld.z = 0;
        return positionInWorld;
    }

}
