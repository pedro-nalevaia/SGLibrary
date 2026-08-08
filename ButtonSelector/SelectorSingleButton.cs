using Godot;

public partial class SelectorSingleButton: TextureButton
{
	int IdToSendToSelector;
	ButtonSelector MySelector;

	public void Configure(int Id, ButtonSelector selector) 
	{
		IdToSendToSelector = Id;

		//Connect the signal
		ButtonUp += MyButtonUp;
		MySelector = selector;

		MySelector = selector;

	}
	public void MyButtonUp()
	{
		MySelector.PressedButton(IdToSendToSelector);
	}
}
