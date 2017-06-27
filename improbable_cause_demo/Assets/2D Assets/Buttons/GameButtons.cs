using UnityEngine;
using UnityEngine.UI;

public class GameButtons : MonoBehaviour
{
    private BaseObject[] objects;
	private GameObject[] anchorPoints;
    private Button button;
    public BUTTONTYPE buttonType;
    private AudioSource Source;
    private CuckooClock clock;
    public AudioClip StartSound;
    public AudioClip RestartSound;


    public enum BUTTONTYPE
    {
        Play,
        Pause,
        Restart,
        LeftCamera,
        RightCamera
    }

    private void Start()
    {
        objects = FindObjectsOfType(typeof(BaseObject)) as BaseObject[];
        clock = FindObjectOfType(typeof(CuckooClock)) as CuckooClock;
       // pauseAllActions();
        button = GetComponent<Button>();
		anchorPoints = GameObject.FindGameObjectsWithTag ("AnchorPoint");
        switch (buttonType)
        {
            case BUTTONTYPE.Play:
                button.onClick.AddListener(() => Play());
                break;

            case BUTTONTYPE.Pause:
                button.onClick.AddListener(() => Pause());
                break;

            case BUTTONTYPE.Restart:
                button.onClick.AddListener(() => Restart());
                break;
            case BUTTONTYPE.LeftCamera:
                break;
            case BUTTONTYPE.RightCamera:
                break;

        }
    }

    public void Play()
    {
        clock.OpenDoors();
        PlayStartSound(this.gameObject);

        foreach (BaseObject baseobject in objects)
        {
            baseobject.Play();
        }
    }

    public void Pause()
    {
        foreach (BaseObject baseobject in objects)
        {
            baseobject.Pause();
        }
    }

    public void Restart()
    {
       // pauseAllActions();
        clock.CloseDoors();
        foreach (BaseObject baseobject in objects)
        {
            baseobject.Restart();
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