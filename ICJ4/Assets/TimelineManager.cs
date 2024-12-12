using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class TimelineManager : MonoBehaviour
{
    public bool startWithIntro = true;

    [SerializeField] TimelineAction introTimeLine;
    [SerializeField] TimelineAction alkoTimeline;

    public static TimelineManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (startWithIntro)
            StartCoroutine(PlayTimeLine(introTimeLine));

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayAlko()
    {
        StartCoroutine(PlayTimeLine(alkoTimeline));
    }

    IEnumerator PlayTimeLine(TimelineAction timeline)
    {
        timeline.timeLine.SetActive(true);

        timeline.onStart.Invoke();

        yield return new WaitForSeconds(timeline.timelineTimer);

        timeline.timeLine.SetActive(false);

        timeline.onEnd.Invoke();
    }

}

[Serializable]
public class TimelineAction
{
    public GameObject timeLine;
    public float timelineTimer;
    public UnityEvent onStart;
    public UnityEvent onEnd;
}