@Client
Feature: Client
	CRUD operations for client

@GetClients
Scenario: GetCLients
	When going to bring data from DB
	Then verify if number of records is <ResultCount>

	Examples:
		| ResultCount |
		| 3           |