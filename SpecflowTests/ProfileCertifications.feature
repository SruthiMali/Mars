Feature: ProfileCertifications
	In order to update my profile 
	As a skill trader
	I want to add, edit, delete the Certifications that I have


@mytag
Scenario: Check if user could able to add a Certification 
	Given I clicked on the Certifications tab under Profile page
	When I add a new Certification
	Then that Certification should be displayed on my listings


	@mytag
Scenario: Check if user could able to add a duplicate Certification
	Given I clicked the Certifications tab under Profile page
	When I add a duplicate Certificate
	Then that Certificate should not be displayed on my listings

	@mytag
Scenario: Check if user could able to add an Certification with blank fields
	Given I clicked on the Certification under the Profile page
	When I add a new Certification leaving some fields blank
	Then that blank Certification should not be displayed on my listings


	@mytag
Scenario: Check if user could able to Edit a Certification 
	Given I clicked on Certification tab under Profile page
	When I edit a new Certification
	Then that Certification should get displayed on my listings

	@mytag
Scenario: Check if user could able to Cancel while adding a Certification
	Given I clicked on the Certification tab under the Profile 
	When I Cancel a Certification
	Then that Certification should not get displayed in my listings

	@mytag
Scenario: Check if user could able to Delete a Certification 
	Given I clicked on the Certification tab under the Profile page
	When I delete a Certification
	Then that Certification should not get displayed on my listings