using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float juoksuNopeus = 3f;
    public float hiirenNopeus = 3f;
    public float hyppyNopeus = 10f;
    public float painovoima = 10f;

    public float maxKaannosAsteet = 60f;
    public CursorLockMode haluttuMoodi;


    private float vertikaalinenPyorinta = 0f;
    private float horisontaalinenPyorinta = 0f;
    private Vector3 liikesuunta = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = haluttuMoodi;

        Cursor.visible = (CursorLockMode.Locked != haluttuMoodi);
    }

    // Update is called once per frame
    void Update()
    {
        horisontaalinenPyorinta += Input.GetAxis("Mouse X") * hiirenNopeus;
        vertikaalinenPyorinta -= Input.GetAxis("Mouse Y") * hiirenNopeus;

        vertikaalinenPyorinta = Mathf.Clamp(vertikaalinenPyorinta, -maxKaannosAsteet, maxKaannosAsteet);

        Camera.main.transform.localRotation = Quaternion.Euler(vertikaalinenPyorinta, horisontaalinenPyorinta, 0);
    }
}
