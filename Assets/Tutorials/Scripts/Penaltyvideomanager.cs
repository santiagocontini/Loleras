using UnityEngine;
using UnityEngine.Video;

public class PenaltyVideoManager : MonoBehaviour
{
    public GameObject videoPanel;
    public VideoPlayer videoPlayer;

    void Start()
    {
        videoPanel.SetActive(false);
    }

    public void ReproducirVideo()
    {
        videoPanel.SetActive(true);

        videoPlayer.Stop();
        videoPlayer.Play();

        Invoke(nameof(OcultarVideo),
            (float)videoPlayer.length);
    }

    void OcultarVideo()
    {
        videoPanel.SetActive(false);
    }
}