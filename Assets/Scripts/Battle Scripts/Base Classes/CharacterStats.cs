using System.Collections;
using System.Collections.Generic;

public class CharacterStats
{
	public int Lv { get; set; }
	public int HP { get; set; }
	public int MP { get; set; }
	public int Strength { get; set; }
	public int Intelligence { get; set; }
	public int Defense { get; set; }
	public int Spirit { get; set; }
	public int Speed { get; set; }
	public int Luck { get; set; }


	public CharacterStats()
	{
	}

	public CharacterStats(int lv, int hp, int mp,int str, int intel, int def, int spr, int spd, int lck)
	{
		lv = Lv;
		hp = HP;
		mp = MP;
		str = Strength;
		intel = Intelligence;
		def = Defense;
		spr = Spirit;
		spd = Speed;
		lck = Luck;
	}
}
