using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class F_player_statsForm : Form
{
	/// <summary>
	/// 
	/// </summary>
	public CollapsibleZoneControl PseudNewgrp01 => new CollapsibleZoneControl(driver, ContainerLocator, "#F_PLAYER_STATS__PSEUD__NEWGRP01-container");

	/// <summary>
	/// Name
	/// </summary>
	public LookupControl PlayerName => new LookupControl(driver, ContainerLocator, "container-F_PLAYER_STATS__PLAYER__NAME");
	public SeeMorePage PlayerNameSeeMorePage => new SeeMorePage(driver, "F_PLAYER_STATS", "F_PLAYER_STATS__PLAYER__NAME");

	/// <summary>
	/// points
	/// </summary>
	public BaseInputControl StatsPoints => new BaseInputControl(driver, ContainerLocator, "container-F_PLAYER_STATS__STATS__POINTS", "#F_PLAYER_STATS__STATS__POINTS");

	/// <summary>
	/// assists
	/// </summary>
	public BaseInputControl StatsAssists => new BaseInputControl(driver, ContainerLocator, "container-F_PLAYER_STATS__STATS__ASSISTS", "#F_PLAYER_STATS__STATS__ASSISTS");

	/// <summary>
	/// rebounds
	/// </summary>
	public BaseInputControl StatsRebounds => new BaseInputControl(driver, ContainerLocator, "container-F_PLAYER_STATS__STATS__REBOUNDS", "#F_PLAYER_STATS__STATS__REBOUNDS");

	/// <summary>
	/// games_played
	/// </summary>
	public BaseInputControl StatsGames_played => new BaseInputControl(driver, ContainerLocator, "container-F_PLAYER_STATS__STATS__GAMES_PLAYED", "#F_PLAYER_STATS__STATS__GAMES_PLAYED");

	public F_player_statsForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "F_PLAYER_STATS", containerLocator: containerLocator) { }
}
