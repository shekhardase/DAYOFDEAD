using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingColor : MonoBehaviour
{
    [SerializeField] private float timer;

    private Color32 matColor;
    private Material objMat;
    // Start is called before the first frame update
    void Start()
    {
        
        //objMat = gameObject.GetComponent<MeshRenderer>().material;
        //objMat = new Color32(0, 0, 0, 1);
        StartCoroutine("ChangeMatColor", this.timer);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StopCoroutine("ChangeMatColor");
        }
    }

    IEnumerator ChangeMatColor(float timer)
    {
        yield return new WaitForSeconds(timer);

        matColor = new Color32((byte)Random.Range(0, 255), (byte)Random.Range(0, 255), (byte)Random.Range(0, 255), 1);
        objMat.color = matColor;
        StartCoroutine("ChangeMatColor", this.timer);
    }
}
