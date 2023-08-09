using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPosition : MonoBehaviour
{
    [SerializeField]
    private Vector3 myTransform;

    public float dragMultiplier = 1f;

    private bool toActivate;

    // Start is called before the first frame update
    void Start()
    {
        myTransform = this.transform.position;
        toActivate = true;
    }

    // Update is called once per frame
    // Reseting particle position
    void Update()
    {
        if (toActivate)
            transform.position = Vector3.Lerp(myTransform, transform.position, Time.deltaTime * dragMultiplier);
    }

    public void waitonActivation()
    {
        toActivate = false;
        StartCoroutine(reverseActivation());
    }

    // Corountine used to create bunce back effect
    IEnumerator reverseActivation()
    {
        yield return new WaitForSeconds(5f);
        toActivate = true;
    }
}
