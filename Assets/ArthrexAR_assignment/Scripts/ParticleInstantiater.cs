using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class to create particles as per image pixels
/// </summary>

public class ParticleInstantiater : MonoBehaviour
{
    [Tooltip("Source texture to create particle array")]
    public Texture2D source;

    [Tooltip("Parent transform to do all intermediate calculation")]
    public Transform parent;

    [Tooltip("Scale factor across created particles for density")]
    public float scaleFactor = 6.5f;

    [Tooltip("Spawned prefab on tracked image")]
    public GameObject spherePrefab;

    [Tooltip("No of pixels to be drawn across screen")]
    public int pixelSpread;

    // Start is called before the first frame update
    void Start()
    {
        parent = Instantiate(parent.gameObject, this.transform).transform;

        // Nested for loop to start creating particle / instantiaing spheres across image

        for (int i = 0; i < source.width; i= i + pixelSpread)
            for (int j = 0; j < source.height; j = j + pixelSpread)
            {
                startCreatingParticles(i, j);
                if (i > source.width - pixelSpread - 1 && j > source.height - pixelSpread - 1)
                {
                    parent.localScale = new Vector3(1, 1, 1);
                    parent.localPosition = new Vector3(-4.5f, 0, -4.5f);

                    Debug.Log("Trackable Position :" + this.transform.position + " " + this.transform.rotation + " "
                        + "Trackable Local :" + this.transform.localPosition + " " + this.transform.localRotation + " " + this.transform.localScale);

                    Debug.Log("Parent Position :" + parent.transform.position + " " + parent.transform.rotation + " "
                        + "Parent Local :" + parent.transform.localPosition + " " + parent.transform.localRotation + " " + parent.transform.localScale);
                    //parent.Rotate(90.0f, 0.0f, 0.0f, Space.World);
                    StartCoroutine(addResetPositionObject());
                }
            }
    }

    // Method used to capture pixel color
    void startCreatingParticles(int x, int y)
    {
        Color tempcolor = source.GetPixel(x, y);
        StartCoroutine(addSpherewithColor(tempcolor, x, y));
    }

    //Courountine used to instantiate sphere with given color code and on respective position
    IEnumerator addSpherewithColor(Color texColor, int row, int column)
    {
        //Debug.Log(row + " " + column);
        GameObject sphere = Instantiate(spherePrefab,parent);
        
        sphere.transform.localPosition = new Vector3(row / scaleFactor, 0, column / scaleFactor);
        sphere.transform.localScale = new Vector3(0.14f * pixelSpread, 0.14f * pixelSpread, 0.14f * pixelSpread);
        
        Material sphereMat = new Material(Shader.Find("UI/Default"));
        sphereMat.color = texColor;
        sphere.GetComponent<Renderer>().material = sphereMat;
        yield return null;
    }

    //Coroutine to initiate bounce back effect
    IEnumerator addResetPositionObject()
    {
        Component[] allSpheres = GetComponentsInChildren<Rigidbody>();
        foreach (Component co in allSpheres)
        {
            co.gameObject.AddComponent<ResetPosition>();
        }
        yield return null;
    }
}
