using UnityEngine;
using System.Collections;

public class CameraControllerWeb : MonoBehaviour
{
    public WebCamTexture mCamera = null;
    public GameObject plane;
    public ItemMap itemMap;
    public GameObject player;


    // Use this for initialization
    void Start()
    {
        Debug.Log("Script has been started");
        plane = GameObject.FindWithTag("WebcamDisplay");

        mCamera = new WebCamTexture();
        plane.GetComponent<Renderer>().material.mainTexture = mCamera;
        mCamera.Play();
        itemMap = new ItemMap();
        player = GameObject.FindObjectOfType<Player>().gameObject;

    }

    public IEnumerator TakePhoto()
    {

        // NOTE - you almost certainly have to do this here:

        yield return new WaitForEndOfFrame();

        // it's a rare case where the Unity doco is pretty clear,
        // http://docs.unity3d.com/ScriptReference/WaitForEndOfFrame.html
        // be sure to scroll down to the SECOND long example on that doco page 

        Texture2D photo = new Texture2D(mCamera.width, mCamera.height);
        photo.SetPixels(mCamera.GetPixels());
        photo.Apply();

        //Encode to a PNG
        byte[] bytes = photo.EncodeToPNG();

        string base64String = System.Convert.ToBase64String(bytes);

        string [] returnedKeys = API.recongize(base64String);
        foreach(var x in returnedKeys) {
            Debug.Log(x);
        }
        InventoryItem newItem = null;
        try
        {
            newItem = itemMap.getItem(returnedKeys);
        }
        catch
        {

        }

        player.SendMessage("addItem", newItem);
       
        //Write out the PNG. Of course you have to substitute your_path for something sensible
        //File.WriteAllBytes(your_path + "photo.png", bytes);
    }

    // Update is called once per frame
    void Update()
    {

    }
}