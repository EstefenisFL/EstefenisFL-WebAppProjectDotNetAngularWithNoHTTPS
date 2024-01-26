@Client
Feature: Client
	CRUD operations for client

@CreateClients
Scenario: CreateCLients
	Given I want to create new client with <Name>
	And the phoneNumber is <PhoneNumber>
	And the cep is <CEP>
	And the registrationNumber is <RegistrationNumber>
	And the state is <state>
	And the city is <city>
	And the option is <option>
	When the object for newClient was created
	Then I verify if the status code for this operation request is: 200

Examples:
	| Name      | PhoneNumber | CEP      | RegistrationNumber | state | city              | option |
	| Estêfenis | 85999665587 | 60822230 | 86487197041        | Ceará | Fortaleza         | 2      |
	| Maria     | 85999999905 | 60820240 | 71038696003        | Ceará | Canindé           | 2      |
	| Pedro     | 85998989865 | 60820220 | 12815644002        | Ceará | Porto de Galinhas | 2      |


@GetClients
Scenario: GetCLients
	When going to bring data from DB
	Then verify if number of records is <ResultCount>

Examples:
	| ResultCount |
	| 3           |


@UpdateClient
Scenario: UpdateClient
	Given I want to update a client
	And the phoneNumber for update is <PhoneNumber>
	And the cep for update is <CEP>
	When the values for update Client was catched
	Then I verify if the status code for update operation request is: 200 

Examples:

	| PhoneNumber | CEP      |
	| 85999665587 | 60822001 |

@Deleteclient
Scenario: Deleteclient
	Given I want to delete a specific client
	Then I verify if the status code for delete operation request is: 200