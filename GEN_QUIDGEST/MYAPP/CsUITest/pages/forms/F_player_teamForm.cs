using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class F_player_teamForm : Form
{
	/// <summary>
	/// Name
	/// </summary>
	public LookupControl PlayerName => new LookupControl(driver, ContainerLocator, "container-F_PLAYER_TEAM__PLAYER__NAME");
	public SeeMorePage PlayerNameSeeMorePage => new SeeMorePage(driver, "F_PLAYER_TEAM", "F_PLAYER_TEAM__PLAYER__NAME");

	/// <summary>
	/// date_started
	/// </summary>
	public DateInputControl Player_teamDate_started => new DateInputControl(driver, ContainerLocator, "#F_PLAYER_TEAM__PLAYER_TEAM__DATE_STARTED");

	/// <summary>
	/// date_ended
	/// </summary>
	public DateInputControl Player_teamDate_ended => new DateInputControl(driver, ContainerLocator, "#F_PLAYER_TEAM__PLAYER_TEAM__DATE_ENDED");

	public F_player_teamForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "F_PLAYER_TEAM", containerLocator: containerLocator) { }
}
