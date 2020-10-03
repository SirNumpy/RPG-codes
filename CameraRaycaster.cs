using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRaycaster : MonoBehaviour
{

    public Layer[] layerProperties =
    {
        Layer.walkable,
        Layer.enemy,
    };
    private RaycastHit m_hit;
    public RaycastHit hit { get { return m_hit; }  }
    Layer m_layer;
    public Layer layer { get { return m_layer; }  }
    void Start()
    {
        viewcamera = Camera.main;
        
        
        
    }
    Camera viewcamera;


    void Update()
    {
        foreach (Layer layer in layerProperties)
        {
            RaycastHit ? hit = RaycstHit(layer) ;
            if (hit.HasValue)
            {
                m_hit = hit.Value;
                m_layer = layer;
                return;
            }
            m_hit.distance = 100f;
            m_layer = Layer.layerstop;

        }
    }
    private RaycastHit? RaycstHit(Layer layer)
    {
        RaycastHit hit;
        int layermask = 1 << (int)layer;
        Ray ray = viewcamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 100f, layermask))
        { return hit; 
        }
        return null;
    }
}
