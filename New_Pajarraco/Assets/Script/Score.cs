using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    private void OnTriggerEnter2D()
    {
        GameManager.Instance.IncreaseScore();

    }
}
