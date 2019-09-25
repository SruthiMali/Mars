Feature: SpecFlowFeature1
	In order to update my profile 
	As a skill trader
	I want to add, edit, delete the languages that I know

@mytag
Scenario: Check if user could able to add a language 
	Given I clicked on the Language tab under Profile page
	When I add a new language
	Then that language should be displayed on my listings

	Scenario Outline: Check if user could able to add a language with Scenario Outline
	Given I clicked on the Language tab under Profile 
	When I add a new language < AddLanguage>
	Then that language should displayed on my listings < AddLanguage>
	Examples: 
	| AddLanguage |
	| English     |
	| Telugu      |
	| Tamil       |
	| Kannada     |
	

@mytag
Scenario: Check if user could able to add a duplicate language
	Given I clicked the Language tab under Profile page
	When I add a duplicate Language
	Then that language should not be displayed on my listings


@mytag
Scenario: Check if user could able to add a language without selecting language level
	Given I clicked the Language tab under the Profile page
	When I add a Language without selecting language level
	Then that language should not be displayed in my listings

@mytag
Scenario: Check if user could able to Edit a language 
	Given I clicked on Language tab under Profile page
	When I edit a new language
	Then that language should get displayed on my listings

@mytag
Scenario: Check if user could able to Cancel while adding a language
	Given I clicked on the Language tab under the Profile 
	When I Cancel a language
	Then that language should not get displayed in my listings

	@mytag
Scenario: Check if user could able to Delete a language 
	Given I clicked on the Language tab under the Profile page
	When I delete a language
	Then that language should not get displayed on my listings

	

