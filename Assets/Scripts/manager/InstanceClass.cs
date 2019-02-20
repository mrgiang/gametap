using UnityEngine;
using System.Collections;

public class InstanceClass : MonoBehaviour {
    public static InstanceClass instance;
    public TextAssetManager TextAssetManager;
    void Awake()
    {
        instance = this;
        TextAssetManager = transform.GetComponent<TextAssetManager>();
    }	
}
