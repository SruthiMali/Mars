Feature: ProfileSkills
	As a skill trader
	I want to add, edit, delete the Skills that I know

@mytag
@mytag
Scenario: Check if user could able to add a Skill
	Given I clicked on the Skills tab under Profile page
	When I add a new Skill
	Then that Skill should be displayed on my listings

	@mytag
Scenario: Check if user could able to add a duplicate Skill
	Given I clicked the Skill tab under Profile page
	When I add a duplicate Skill
	Then that Skill should not be displayed on my listings

	@mytag
Scenario: Check if user could able to add a Skill without selecting Skill level
	Given I clicked the Skills tab under the Profile page
	When I add a Skill without selecting skill level
	Then that Skill should not be displayed in my listings

	@mytag
Scenario: Check if user could able to Edit a Skill 
	Given I clicked on Skill tab under Profile page
	When I edit a Skill
	Then that Skill should get displayed on my listings

	Scenario: Check if user could able to Cancel while adding a skill
	Given I clicked on the Skill tab under the Profile 
	When I Cancel a skill
	Then that skill should not get displayed in my listings