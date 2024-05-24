using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class IAPerception : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject Pawn;
    private Vector3 checkDirection;
    [SerializeField] private float distance;
    
    void CheckDistance()
    {
        checkDirection = Player.transform.position - Pawn.transform.position;
        RaycastHit hit;
        if (Physics.Raycast(Pawn.transform.position,checkDirection,out hit,distance))
        {
            if (hit.collider.gameObject.GetComponent<PlayerController>())
            {
                Pawn.GetComponentInChildren<IAController>().PlayerNear = true;
            }
            else
            {
                Pawn.GetComponentInChildren<IAController>().PlayerNear= false;
            }
        }
        else
        {
            Pawn.GetComponentInChildren<IAController>().PlayerNear = false;
        }
    }
}
