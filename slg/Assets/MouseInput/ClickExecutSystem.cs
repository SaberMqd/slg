using Unity.Entities;
using slg.controler;
using slg.Round;
using slg.character.attribute;
using slg;
using UnityEngine;

public class ClickExecutSystem
{
	struct Group
	{
		public int Length;
		public EntityArray entity;
		public ComponentDataArray<MouseClick> mouseClick;
	}
}
