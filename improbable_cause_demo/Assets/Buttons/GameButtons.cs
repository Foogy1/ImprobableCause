using UnityEngine;
using UnityEngine.UI;

public class GameButtons : MonoBehaviour
{
    private Topple[] topples;
    private IUsable[] iusables;
	private GameObject[] anchorPoints;
    private Button button;
    public BUTTONTYPE buttonType;
    private AudioSource Source;
    private CuckooClock clock;
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
        topples = FindObjectsOfType(typeof(Topple)) as Topple[];
        iusables = FindObjectsOfType(typeof(IUsable)) as IUsable[];
        clock = FindObjectOfType(typeof(CuckooClock)) as CuckooClock;
       // pauseAllActions();
        button = GetComponent<Button>();
		anchorPoints = GameObject.FindGameObjectsWithTag ("AnchorPoint");
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
        
    }

    public void startAllActions()
    {
        clock.OpenDoors();
        PlayStartSound(this.gameObject);
    }

    public void restart()
    {
       // pauseAllActions();
        clock.CloseDoors();
        foreach (IUsable usable in iusables)
        {
            usable.Restart();
        }

        foreach(Topple top in topples)
        {
            top.restart();
        }
        PlayRestartSound(this.gameObject);
		foreach(GameObject anchorP in anchorPoints)
		{
			anchorP.GetComponent<AnchorPoint> ().IsOccupied = false;
			//   usable.enabled = false;
		}
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