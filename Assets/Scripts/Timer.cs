using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer
{
	private float time;
	private float interval;

	public void BeginTimer(float interval)
	{
		time = Time.time;
		this.interval = interval;
	}

	public bool IsTime()
	{
		return Time.time >= time + interval;
	}

	public float Interval()
	{
		return Time.time - time;
	}
	public float ReverseInterval()
	{
		return time + interval + 1 - Time.time;
	}
}
