using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class Conteiners : MonoBehaviour
{
    public string tagCorrecto;
    public GameManager gameManager;

    public Color colorCheck = Color.green;
    public Color colorWrong = Color.red;

    public AudioSource audioSource;
    public AudioClip correctSound;
    public AudioClip wrongSound;

    public Transform puntoDeRetorno; 

    private XRSocketInteractor socket;
    private Renderer rend;
    private Color originalColor;

    void Start()
    {
        socket = GetComponent<XRSocketInteractor>();
        socket.selectEntered.AddListener(ObjetoColocado);

        rend = GetComponent<Renderer>();
        originalColor = rend.material.color;
    }

    void ObjetoColocado(SelectEnterEventArgs args)
    {
        var obj = args.interactableObject.transform;
        var rb = obj.GetComponent<Rigidbody>();

        if (obj.CompareTag(tagCorrecto))
        {
            gameManager.AddScore();

            rend.material.color = colorCheck;

            if (audioSource && correctSound)
                audioSource.PlayOneShot(correctSound);

            Destroy(obj.gameObject, 0.2f);
        }
        else
        {
            rend.material.color = colorWrong;

            if (audioSource && wrongSound)
                audioSource.PlayOneShot(wrongSound);

            obj.position = puntoDeRetorno.position;
        }
    }

    
}
