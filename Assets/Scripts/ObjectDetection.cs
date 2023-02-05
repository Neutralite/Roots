using UnityEngine;

public class ObjectDetection : MonoBehaviour
{
    // Bit shift the index of the layer to get a bit mask
    int rootLayer = 1 << 6;

    private Camera mainCam;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        DetectObjectWithRaycast();
    }

    public void DetectObjectWithRaycast()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Board.instance.availableNodes == 0)
            {
                Board.instance.ReloadScene();
            }

            Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray,out hit,15,rootLayer))
            {
                Debug.Log($"{hit.collider.transform.parent.name} Detected");

                hit.collider.GetComponentInParent<GroundNode>().SelectNode();
            }
            else
            {
                Board.instance.selectedNode.UnSelectRoot();
            }
        }
    }
}