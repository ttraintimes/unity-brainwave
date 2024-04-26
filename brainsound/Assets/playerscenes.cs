using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerscenes : MonoBehaviour
{
    GameObject raycastedObj;
    ObjectInteraction referencedScript;
    public Image allyE;
    public Image tanakhE;
    public Image daniE;
    public Image ttE;

    [SerializeField] private int InteractionRange = 2;
    [SerializeField] private LayerMask scenetransitionLayer;

    // Update is called once per frame


    void Start()
    {
        allyE.enabled = false;
        tanakhE.enabled = false;
        ttE.enabled = false;
        daniE.enabled = false;
    }

    void Update()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, fwd, out hit, InteractionRange, scenetransitionLayer.value))
        {
            if (hit.collider.CompareTag("ally"))
            {
                allyE.enabled = true;
                raycastedObj = hit.collider.gameObject;
                referencedScript = raycastedObj.GetComponent<ObjectInteraction>();

                if (Input.GetKeyDown("e") && (referencedScript != null))
                {
                    referencedScript.interact();
                    raycastedObj = null;
                    referencedScript = null;
                    raycastedObj = null;
                }
            }
            if (hit.collider.CompareTag("tanakh"))
            {
                tanakhE.enabled = true;
                raycastedObj = hit.collider.gameObject;
                referencedScript = raycastedObj.GetComponent<ObjectInteraction>();

                if (Input.GetKeyDown("e") && (referencedScript != null))
                {
                    referencedScript.interact();
                    raycastedObj = null;
                    referencedScript = null;
                    raycastedObj = null;
                }
            }
            if (hit.collider.CompareTag("tt"))
            {
                ttE.enabled = true;
                raycastedObj = hit.collider.gameObject;
                referencedScript = raycastedObj.GetComponent<ObjectInteraction>();

                if (Input.GetKeyDown("e") && (referencedScript != null))
                {
                    referencedScript.interact();
                    raycastedObj = null;
                    referencedScript = null;
                    raycastedObj = null;
                }
            }
            if (hit.collider.CompareTag("dani"))
            {
                daniE.enabled = true;
                raycastedObj = hit.collider.gameObject;
                referencedScript = raycastedObj.GetComponent<ObjectInteraction>();

                if (Input.GetKeyDown("e") && (referencedScript != null))
                {
                    referencedScript.interact();
                    raycastedObj = null;
                    referencedScript = null;
                    raycastedObj = null;
                }
            }
        }
        else
        {
            allyE.enabled = false;
        tanakhE.enabled = false;
        ttE.enabled = false;
        daniE.enabled = false;
        }

    }
}
