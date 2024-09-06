using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    EntityInfo _info;
    public EntityInfo Info => _info;

    EntityContoller _controller;
    public EntityContoller Controller => _controller;

    long _uid;
    public long UID => _uid;

    GlobalTypeJob _eJobType;
    public GlobalTypeJob JobType => _eJobType;

    int _jobID;
    public int JobID => _jobID;


    public Entity(EntityCategory eCategory, int _jobID)
    {
        InitializeBaseStat();

        this._jobID = JobID;
        this._eJobType = (GlobalTypeJob)_jobID;

        if (eCategory == EntityCategory.PlayerTeam)
        {

        }



    }

    private void InitializeBaseStat()
    {

    }
}
