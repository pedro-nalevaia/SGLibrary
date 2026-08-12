using Godot;
using System;
using UsefulEnums;

public partial class ButtonSelector : Control
{
	SelectorSingleButton[] Buttons;
	public int CurrSelectedId = -1;
	Vector2I SelectorDimensions;
	Vector2 QueryDrawSelectorPos;

	//Put the grid in integers, so a roll would be a 
	//10x1
	public unsafe void Initialize(Vector2 StartingPos, 
				Vector2I Grid, 
				Vector2I ButtonDimensions,
				int NoOfButtons,
				Texture2D[] TexturePtr,
				ENUM_READING_ORDER ReadingOrder,
				float HorizDistBetweenButtons,
				float VertDistBetweenButtons)
	{

		SelectorDimensions = ButtonDimensions + 
			new Vector2I(1,1);
		QueryDrawSelectorPos = new Vector2(-1,-1);

		Buttons = new SelectorSingleButton[NoOfButtons];
		Vector2 ButtonPosBuff;

		for (int k=0; k < Buttons.Length; k++)
		{
			ButtonPosBuff = SetButtonPos(
					ReadingOrder,
					Grid,
					ButtonDimensions,
					HorizDistBetweenButtons,
					VertDistBetweenButtons,
					k);
			
			Buttons[k] = new SelectorSingleButton();
			AddChild(Buttons[k]);
			Buttons[k].Position = ButtonPosBuff;
			
			//put the texture or hide
			if (k < TexturePtr.Length)
			{
				Buttons[k].TextureNormal = TexturePtr[k];
				Buttons[k].Visible = true;
				SetButtonLogic(k);
			}
			else 
			{
				Buttons[k].Visible = false;
			}
		}
	}
	public Vector2 SetButtonPos(
			ENUM_READING_ORDER ReadingOrder, 
			Vector2I Grid,
			Vector2I ButtonDimensions,
			float HorizDistBetweenButtons,
			float VertDistBetweenButtons,
			int k)
	{

		int CurrButtonGridX=0;
		int CurrButtonGridY=0;

		float CurrButtonX;
		float CurrButtonY;

			if (ReadingOrder == ENUM_READING_ORDER.LEFT_RIGHT)
			{
				CurrButtonGridX =
					k % Grid[0];
				CurrButtonGridY =
					(k - CurrButtonGridX) / Grid[1];
			}
			else 
			{
				CurrButtonGridY =
					k % Grid[1];
				CurrButtonGridX =
					(k - CurrButtonGridY) / Grid[0];
			}

			CurrButtonX = 
				CurrButtonGridX * (ButtonDimensions[0] +
						HorizDistBetweenButtons);
			CurrButtonY =
				CurrButtonGridY * (ButtonDimensions[1] +
						VertDistBetweenButtons);

			Vector2 Pos = new Vector2(CurrButtonX, CurrButtonY);
			return Pos;
	}
	//set the logic for button with index k
	public void SetButtonLogic(int k)
	{
		//this k is the id the button is going to store
		//as a property
		Buttons[k].Configure(k, this);
	}
	public void PressedButton(int ButtonId)
	{
		QueryDrawSelectorPos = Buttons[ButtonId].Position -= 
			new Vector2(1,1);
		QueueRedraw();
		CurrSelectedId = ButtonId;

	}
	public override void _Draw()
	{
		DrawRect(new Rect2(
				QueryDrawSelectorPos[0],
				QueryDrawSelectorPos[1],
				SelectorDimensions[0],
				SelectorDimensions[1]),
				Colors.Green,
				false,
				1.0f);
	}

}

