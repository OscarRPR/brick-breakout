﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Brick {
	public enum TypeBrick {NONE, NORMAL, XRES, XXRES, INVERSE, MULTIPLE_BALLS, SLOW_BALLS, FAST_BALLS};
	public enum ObjectBrick {
		[StringValue("")] NONE = 0,
		[StringValue("InversePaddleObject")] INVERSE = 1,
		[StringValue("MultipleBallsObject")] MULTIPLE_BALLS = 2,
		[StringValue("SlowBallsObject")] SLOW_BALLS = 3,
		[StringValue("FastBallsObject")] FAST_BALLS = 4,
	};

	public TypeBrick typeBrick;
	public ObjectBrick objectBrick;

	protected int points;
	protected int neededHits;
	protected int currentHits;

	public Brick() {
		typeBrick = TypeBrick.NONE;
		objectBrick = ObjectBrick.NONE;
		neededHits = 0;
		currentHits = 0;
	}

	public Brick Clone()
	{
		return (Brick)MemberwiseClone();
	}

	public TypeBrick getType() {
		return typeBrick;
	}

	public ObjectBrick getObject() {
		return objectBrick;
	}

	public int getNeededHits() {
		return neededHits;
	}

	public int getCurrentHits() {
		return currentHits;
	}

	public int getPoints() {
		return points;
	}

	public virtual void addHits() {
		currentHits += 1;
	}
}
