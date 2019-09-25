Feature: ProfileEducation
	In order to update my profile 
	As a skill trader
	I want to add, edit, delete the Education that I have

@mytag
Scenario: Check if user could able to add an Education
	Given I clicked on the Education tab under Profile page
	When I add a new Education
	Then that Education should be displayed on my listings

	@mytag
Scenario: Check if user could able to add a duplicate Education
	Given I clicked the Education tab under Profile page
	When I add a duplicate Education
	Then that Education should not be displayed on my listings

	@mytag
Scenario: Check if user could able to add an Education with blank fields
	Given I clicked on the Education under the Profile page
	When I add a new Education leaving some fields blank
	Then that blank Education should not be displayed on my listings

	@mytag
Scenario: Check if user could able to Edit an Education
	Given I clicked on Education tab under Profile page
	When I edit an education
	Then that education should get displayed on my listings


	@mytag
Scenario: Check if user could able to Delete an Education
	Given I clicked on the Education tab under the Profile page
	When I delete an education
	Then that Education should not get displayed on my listings