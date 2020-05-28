Feature: ParseJsonService
	In order to process requests
	As a lazy, stupid user
	I want bad requests to be automatically 'rejected'
	And valid requests to be automatically populated

Scenario: Create and Site requests are correctly identified by their request 'header'
	Given I receive data to create a site
	When I parse the new request
	Then the request should be identified as a create site request

Scenario: Update and Facility requests are correctly identified by their request 'header'
	Given I receive data to update a facility
	When I parse the new request
	Then the request should be identified as an update facility request

Scenario: Assigning a site id to a new create site request
	Given I receive data to create a site with no site id
	When I parse the new request
	Then the request should have a site id

Scenario: Rejecting a new update site request with no valid site id
	Given I receive data to update a site with no site id
	When I parse the new request
	Then the request should be rejected

Scenario: Rejecting a new update facility request with no valid facility ids
	Given I receive data to update facilities with no facility ids
	When I parse the new request
	Then the request should be rejected

#Scenario: Partially valid facility data
