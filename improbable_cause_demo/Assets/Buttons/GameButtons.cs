using UnityEngine;
using UnityEngine.UI;

public class GameButtons : MonoBehaviour
{
    private IUsable[] iusables;
    private Button button;
    public BUTTONTYPE buttonType;
    private AudioSource Source;
    public AudioClip StartSound;
    public AudioClip RestartSound;


    public enum BUTTONTYPE
    {
        Start,
        Pause,
        Restart,
        LeftCamera,
        RightCamera
    }

    private void Start()
    {
        iusables = FindObjectsOfType(typeof(IUsable)) as IUsable[];
       // pauseAllActions();
        button = GetComponent<Button>();
        switch (buttonType)
        {
            case BUTTONTYPE.Start:
                button.onClick.AddListener(() => startAllActions());
                break;

            case BUTTONTYPE.Pause:
                button.onClick.AddListener(() => pauseAllActions());
                break;

            case BUTTONTYPE.Restart:
                button.onClick.AddListener(() => restart());
                break;
            case BUTTONTYPE.LeftCamera:
                break;
            case BUTTONTYPE.RightCamera:
                break;

        }
    }


    public void pauseAllActions()
    {
        foreach(IUsable usable in iusables)
        {
            usable.Restart();
         //   usable.enabled = false;
        }
        
    }

    public void startAllActions()
    {
        // foreach
        PlayStartSound(this.gameObject);
    }

    public void restart()
    {
        pauseAllActions();
        PlayRestartSound(this.gameObject);
    }

    public void PlayStartSound(GameObject Object)
    {
        Debug.Log("Play sound");
        Source = Object.GetComponent<AudioSource>();
        try
        {
            Source.PlayOneShot(StartSound, 1.0f);
        }
        catch
        {
            Debug.LogError("You have not attached the Audio Source to the Game Object");
        }

    }

    public void PlayRestartSound(GameObject Object)
    {
        Debug.Log("Play sound");
        Source = Object.GetComponent<AudioSource>();
        try
        {
            Source.PlayOneShot(RestartSound, 1.0f);
        }
        catch
        {
            Debug.LogError("You have not attached the Audio Source to the Game Object");
        }

    }


}