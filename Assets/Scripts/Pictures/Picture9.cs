using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Picture9 : MonoBehaviour
{
    public GameObject correctForm9;
    private bool moving;

    private float startPosX;
    private float startPosY;

    private Vector3 resetPosition;
    public static bool finished;

    private void Start()
    {
        resetPosition = transform.localPosition;
    }

    void Update()
    {
        if (moving && !finished)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, gameObject.transform.localPosition.z);

        }
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPosX = mousePos.x - transform.localPosition.x;
            startPosY = mousePos.y - transform.localPosition.y;

            moving = true;
        }
    }

    private void OnMouseUp()
    {
        moving = false;

        if (Mathf.Abs(transform.localPosition.x - correctForm9.transform.localPosition.x) <= 0.5f &&
            Mathf.Abs(transform.localPosition.y - correctForm9.transform.localPosition.y) <= 0.5f)
        {
            transform.position = new Vector3(correctForm9.transform.position.x,
                                                correctForm9.transform.position.y,
                                                correctForm9.transform.position.z);
            finished = true;
        }
        else
            transform.localPosition = new Vector3(resetPosition.x, resetPosition.y, resetPosition.z);
    }

    public void ToggleVisibility9()
    {
        if (!finished)
            if (CollectingVisibilityControl.count == 3)
                gameObject.SetActive(true);
            else
                gameObject.SetActive(false);
        else
            gameObject.SetActive(true);
    }
}
