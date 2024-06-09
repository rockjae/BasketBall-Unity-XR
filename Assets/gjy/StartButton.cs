using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class StartButton : MonoBehaviour
{
    public BasketBallManager basketBallManager;

    Vector3 firstPos;
    Quaternion firstQUA;

    private void Start()
    {
        firstPos = transform.position;
        firstQUA = transform.rotation;
    }

    public void OnSelectBall(SelectEnterEventArgs args)
    {
        if (!basketBallManager.isPlaying)
        {
            Debug.Log("Object selected!");
            basketBallManager.StartGame();
        }
    }

    private void Update()
    {
        transform.position = firstPos;
        transform.rotation = firstQUA;
    }
}
