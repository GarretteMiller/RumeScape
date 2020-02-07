using UnityEngine;

[System.Serializable]

public class Interactable : MonoBehaviour
{
    public Camera cam;
    public float radius = 0.7f;
    Renderer m_Renderer;
    Material temp;
    public Material newMaterial;
    public float dist;

    protected virtual void Start()
    {
        m_Renderer = GetComponent<MeshRenderer>();
        temp = m_Renderer.material;
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PlayerController>().cam;
    }

    protected virtual void Update()
    {
        dist = Vector3.Distance(cam.transform.position, transform.position);
        TriggerOutline();
    }

    void TriggerOutline()
    {
        if (dist <= radius)
        {
            m_Renderer.material = newMaterial;
        }
        else
        {
            m_Renderer.material = temp;
        }
    }
}
