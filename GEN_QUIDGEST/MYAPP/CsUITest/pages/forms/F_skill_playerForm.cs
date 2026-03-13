using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class F_skill_playerForm : Form
{
	/// <summary>
	/// Name
	/// </summary>
	public LookupControl PlayerName => new LookupControl(driver, ContainerLocator, "container-F_SKILL_PLAYER__PLAYER__NAME");
	public SeeMorePage PlayerNameSeeMorePage => new SeeMorePage(driver, "F_SKILL_PLAYER", "F_SKILL_PLAYER__PLAYER__NAME");

	/// <summary>
	/// Rating
	/// </summary>
	public BaseInputControl Skill_playerRating => new BaseInputControl(driver, ContainerLocator, "container-F_SKILL_PLAYER__SKILL_PLAYER__RATING", "#F_SKILL_PLAYER__SKILL_PLAYER__RATING");

	public F_skill_playerForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "F_SKILL_PLAYER", containerLocator: containerLocator) { }
}
