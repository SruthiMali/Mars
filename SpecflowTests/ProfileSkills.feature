Feature: ProfileSkills
	As a skill trader
	I want to add, edit, delete the Skills that I know

@mytag
@mytag
Scenario: Check if user could able to add a Skill
	Given I clicked on the Skills tab under Profile page
	When I add a new Skill
	Then that Skill should be displayed on my listings
