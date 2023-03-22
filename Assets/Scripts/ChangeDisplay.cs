using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeDisplay : MonoBehaviour
{


    private Vector2 startTouchPosition;
    private Vector2 currentPosition;
    private Vector2 endTouchPosition;
    private bool stopTouch = false;
    [SerializeField] List<Material> listSkyBoxs = new List<Material>();
    int currentSkyBox = 0;

    public float swipeRange;
    public float tapRange;

    private void Start()
    {
        currentSkyBox = PlayerPrefs.GetInt("background");
        RenderSettings.skybox = listSkyBoxs[currentSkyBox];
    }
    private void Update()
    {
        Swipe();
    }

    public void Swipe()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPosition = Input.GetTouch(0).position;
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            currentPosition = Input.GetTouch(0).position;
            Vector2 distance = currentPosition - startTouchPosition;

            if (!stopTouch)
            {
                if (distance.x < -swipeRange)
                {
                    
                    if (currentSkyBox == 0)
                    {
                        currentSkyBox = listSkyBoxs.Count - 1;
                    }
                    else
                    {
                        currentSkyBox -= 1;
                    }
                    RenderSettings.skybox = listSkyBoxs[currentSkyBox];
                    stopTouch = true;
                }
                else if (distance.x > swipeRange)
                {
                    
                    if (currentSkyBox == listSkyBoxs.Count - 1)
                    {
                        currentSkyBox = 0;
                    }
                    else
                    {
                        currentSkyBox += 1;
                    }
                    RenderSettings.skybox = listSkyBoxs[currentSkyBox];
                    stopTouch = true;
                }
                else if (distance.y < -swipeRange) //вниз
                {
                   
                    stopTouch = true;
                }
                else if (distance.y > swipeRange) //вверх 
                {
                    stopTouch = true;
                }
            }
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            PlayerPrefs.SetInt("background", currentSkyBox);
            stopTouch = false;
            endTouchPosition = Input.GetTouch(0).position;

            Vector2 distance = endTouchPosition - startTouchPosition;

            if (Mathf.Abs(distance.x) < tapRange && Mathf.Abs(distance.y) < tapRange) // тап
            {
            }
        }
    }
    
}
