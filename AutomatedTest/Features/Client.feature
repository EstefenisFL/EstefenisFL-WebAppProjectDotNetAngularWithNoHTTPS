@Client
Feature: Client
	CRUD operations for client

@GetClients
Scenario: GetCLients
	When the retrieval is done
	Then verify if number of records is <ResultCount>

	Examples:
	| ResultCount |
	| 5           |