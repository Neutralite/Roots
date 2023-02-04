using UnityEngine;

public class ObjectDetection : MonoBehaviour
{
    // Bit shift the index of the layer to get a bit mask
    int rootNodeLayerMask = 1 << 6,
        ghostNodeLayerMask = 1<<7;


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
            Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray,out hit,15,rootNodeLayerMask))
            {
                Debug.Log($"{hit.collider.name} Detected",
                    hit.collider.gameObject);

                hit.collider.GetComponent<RootNode>().SelectRoot();
            }

            if (Physics.Raycast(ray, out hit, 15, ghostNodeLayerMask))
            {
                Debug.Log($"{hit.collider.name} Detected",
                    hit.collider.gameObject);

                hit.collider.GetComponent<GhostNode>().GrowRoot();
            }
        }
        else if (Input.GetMouseButtonDown(1))
        {
            Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 15, rootNodeLayerMask))
            {
                Debug.Log($"{hit.collider.name} Detected",
                    hit.collider.gameObject);

                hit.collider.GetComponent<RootNode>().DeleteRoot();
            }
        }
    }
}