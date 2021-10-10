using System;

public class Card
{
	private string face;
	private Suite suite;

	public Card(string cardFace, Suite cardSuite)
	{
		face = cardFace;
		suite = cardSuite;
	}

	public override string toString()
	{
		return face + " of " + suite;
	}
}
