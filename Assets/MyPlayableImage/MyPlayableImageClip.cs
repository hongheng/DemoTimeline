using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[Serializable]
public class MyPlayableImageClip : PlayableAsset, ITimelineClipAsset
{
    public MyPlayableImageBehaviour template = new MyPlayableImageBehaviour ();

    public ClipCaps clipCaps
    {
        get { return ClipCaps.Blending; }
    }

    public override Playable CreatePlayable (PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<MyPlayableImageBehaviour>.Create (graph, template);
        return playable;
    }
}
