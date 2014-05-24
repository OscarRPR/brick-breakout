﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BrickFactory {

	private static readonly Dictionary<Brick.TypeBrick, Brick> bricks
		= new Dictionary<Brick.TypeBrick, Brick>
	{
		{ Brick.TypeBrick.NONE, new Brick() },
		{ Brick.TypeBrick.NORMAL, new NormalBrick() }
	};

	public static Brick getBrick(Brick.TypeBrick type) {
		Brick brick = bricks[type];
		return brick.Clone();
	}
}