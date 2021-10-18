using System;

public class Card
{
	private string face;
	private Suite suite;
	private Uri imagePath;
	private int cardValue;

	public Card(string cardFace, Suite cardSuite, int cardValue)
	{
		face = cardFace;
		suite = cardSuite;
		this.cardValue = cardValue;
	}

	public Card(string cardFace, Suite cardSuite)
	{
		face = cardFace;
		suite = cardSuite;
	}


	public Uri ImagePath
    {
		get
        {
			return imagePath;
        }
		set
        {
			imagePath = value;
        }
    }

	public Suite Suite
    {
		get
        {
			return suite;
        }
		set
        {
			suite = value;
        }
    }

	public string Face
    {
		get
        {
			return face;
        }
		set
        {
			face = value;
        }
    }

	public int CardValue
    {
		get
        {
			return cardValue;
        }

		set
        {
			cardValue = value;
        }
    }

	public override string ToString()
    {
        if (imagePath != null)
        {
			return new string(Suite.ToString() + " " + face + " - imgPath: " + imagePath.ToString() + "Value: " + CardValue);
		}
		else
        {
			return new string(Suite.ToString() + " " + face + " Value: " + CardValue);
		}
		
    }
}
