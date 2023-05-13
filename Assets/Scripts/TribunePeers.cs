using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TribunePeers : MonoBehaviour
{

    private GameObject[] peers;

    private List<Material> materials;

    private string folderPath = "Materials/Materials/Colours";



    void Awake()
    {
        peers = GameObject.FindGameObjectsWithTag("Peer Body");
        materials = new List<Material>();
        LoadMaterialsFromFolder();
    }

    // Start is called before the first frame update
    void Start()
    {
        peers = GameObject.FindGameObjectsWithTag("Peer Body");
        materials = new List<Material>();
        LoadMaterialsFromFolder();

        foreach (GameObject peer in peers)
        {
            peer.GetComponent<Renderer>().material = RandomColour();
        }
    }

    Material RandomColour()
    {

        if (materials.Count == 0)
        {
            Debug.Log("No materials found");
            return null;
        }
        else
        {

            Material material = materials[Random.Range(0, materials.Count)];
            return material;
        }
    }

    void LoadMaterialsFromFolder()
    {
        Object[] obj = Resources.LoadAll(folderPath, typeof(Material));
        foreach (Object o in obj)
        {
            materials.Add((Material)o);
        }
    }


}
