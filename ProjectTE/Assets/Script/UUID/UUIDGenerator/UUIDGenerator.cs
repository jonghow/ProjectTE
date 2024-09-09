using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UUIDGenerator<T>
{
    private static UUIDGenerator<T> _instance;
    private UniqueIDGenerateAlgorithm<T> _algorithm;
    private UUIDGenerator() { }

    public static UUIDGenerator<T> GetInstance()
    {
        if (_instance == null)
            _instance = new UUIDGenerator<T>();

        _instance._algorithm = new TwitterSnowFlakeAlgorithm(0, 0) as UniqueIDGenerateAlgorithm<T>;
        return _instance;
    }

    public T Generate()
    {
        return _algorithm.Generate();
    }
}

public abstract class UniqueIDGenerateAlgorithm<T>
{
    public abstract T Generate();
}

public class TwitterSnowFlakeAlgorithm : UniqueIDGenerateAlgorithm<long>
{
    private static readonly long Epoch = 1288834974657L; // 기준 시간 (2010-11-04)
    private static readonly long DatacenterIdBits = 5L;
    private static readonly long WorkerIdBits = 5L;
    private static readonly long SequenceBits = 12L;

    private static readonly long MaxDatacenterId = -1L ^ (-1L << (int)DatacenterIdBits);
    private static readonly long MaxWorkerId = -1L ^ (-1L << (int)WorkerIdBits);
    private static readonly long SequenceMask = -1L ^ (-1L << (int)SequenceBits);

    private long datacenterId;
    private long workerId;
    private long sequence = 0L;
    private long lastTimestamp = -1L;

    public TwitterSnowFlakeAlgorithm(long datacenterId, long workerId)
    {
        if (datacenterId > MaxDatacenterId || datacenterId < 0)
            throw new ArgumentException($"Datacenter Id can't be greater than {MaxDatacenterId} or less than 0");

        if (workerId > MaxWorkerId || workerId < 0)
            throw new ArgumentException($"Worker Id can't be greater than {MaxWorkerId} or less than 0");

        this.datacenterId = datacenterId;
        this.workerId = workerId;
    }

    public long NextId()
    {
        // Snowflake 알고리즘 구현 
        lock (this)
        {
            long timestamp = GetTimestamp();

            if (timestamp < lastTimestamp)
                throw new InvalidOperationException("Clock moved backwards.");

            if (lastTimestamp == timestamp)
            {
                sequence = (sequence + 1) & SequenceMask;
                if (sequence == 0)
                    timestamp = WaitForNextMillis(lastTimestamp);
            }
            else
            {
                sequence = 0L;
            }

            lastTimestamp = timestamp;
            return ((timestamp - Epoch) << (int)(DatacenterIdBits + WorkerIdBits + SequenceBits))
                | (datacenterId << (int)(WorkerIdBits + SequenceBits))
                | (workerId << (int)SequenceBits)
                | sequence;
        }
    }

    private long GetTimestamp()
    {
        return DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
    }

    private long WaitForNextMillis(long lastTimestamp)
    {
        long timestamp = GetTimestamp();
        while (timestamp <= lastTimestamp)
            timestamp = GetTimestamp();
        return timestamp;
    }


    public override long Generate()
    {
        // 결과값 반환
        return NextId();
    }
}

public class UniversalUniqueIDAlgorithm : UniqueIDGenerateAlgorithm<string>
{
    public override string Generate()
    {
        // UUID 알고리즘 구현
        return Guid.NewGuid().ToString();
    }
}