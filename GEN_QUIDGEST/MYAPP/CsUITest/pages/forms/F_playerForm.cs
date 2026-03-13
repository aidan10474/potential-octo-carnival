using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class F_playerForm : Form
{
	/// <summary>
	/// Name
	/// </summary>
	public BaseInputControl PlayerName => new BaseInputControl(driver, ContainerLocator, "container-F_PLAYER__PLAYER__NAME", "#F_PLAYER__PLAYER__NAME");

	/// <summary>
	/// Birthdate
	/// </summary>
	public DateInputControl PlayerBirthdate => new DateInputControl(driver, ContainerLocator, "#F_PLAYER__PLAYER__BIRTHDATE");

	/// <summary>
	/// Gender
	/// </summary>
	public EnumControl PlayerGender => new EnumControl(driver, ContainerLocator, "container-F_PLAYER__PLAYER__GENDER");

	/// <summary>
	/// Height
	/// </summary>
	public BaseInputControl PlayerHeight_cm => new BaseInputControl(driver, ContainerLocator, "container-F_PLAYER__PLAYER__HEIGHT_CM", "#F_PLAYER__PLAYER__HEIGHT_CM");

	/// <summary>
	/// Position
	/// </summary>
	public EnumControl PlayerPosition => new EnumControl(driver, ContainerLocator, "container-F_PLAYER__PLAYER__POSITION");

	public F_playerForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "F_PLAYER", containerLocator: containerLocator) { }
}
