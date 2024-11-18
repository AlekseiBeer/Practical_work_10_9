using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallAddJoint : MonoBehaviour
{
    [SerializeField]
    private float _breakForce = 50;
    [SerializeField]
    private float _breakTorque = 50;
    private GameObject[] _bricks;

    void Start()
    {
        ConnectBricks();
    }

    void Update()
    {
        
    }

    void ConnectBricks()
    {
        _bricks = GameObject.FindGameObjectsWithTag("Brick");

        foreach (GameObject brick in _bricks)
        {
            Collider[] neighbors = Physics.OverlapSphere(brick.transform.position,0.30f);
            foreach (Collider neighbor in neighbors)
            {
                if (neighbor.gameObject != brick)
                {
                    AddFixedJointIfNeeded(brick, neighbor.gameObject);
                }
            }
        }
    }

    void AddFixedJointIfNeeded(GameObject brick, GameObject neighbor)
    {
        FixedJoint[] joints = brick.GetComponents<FixedJoint>();
        foreach (FixedJoint joint in joints)
        {
            if (joint.connectedBody == neighbor.GetComponent<Rigidbody>())
            {
                return;
            }
        }
        FixedJoint newJoint = brick.AddComponent<FixedJoint>();
        newJoint.connectedBody = neighbor.GetComponent<Rigidbody>();
        newJoint.breakForce = _breakForce;
        newJoint.breakTorque = _breakTorque;
    }
}
