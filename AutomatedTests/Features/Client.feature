@Client
Feature: Client
	CRUD operations for client

@CreateClients
Scenario: CreateCLients
	When going to bring data from DB
	Then verify if number of records is <ResultCount>

Examples:
	| Name      | PhoneNumber | CEP      | RegistrationNumber | state | city              |
	| Estêfenis | 85999665587 | 60822230 | 86487197041        | Ceará | Fortaleza         |
	| Maria     | 85999999905 | 60820240 | 71038696003        | Ceará | Canindé           |
	| Pedro     | 85998989865 | 60820220 | 12815644002        | Ceará | Porto de Galinhas |


@GetClients
Scenario: GetCLients
	When going to bring data from DB
	Then verify if number of records is <ResultCount>

Examples:
	| ResultCount |
	| 3           |


@UpdateClients
Scenario: UpdateClients
	Given 
	When 
	Then 

Examples:

	| Name      | PhoneNumber | CEP      |
	| Estêfenis | 85999665587 | 60822001 |
	| Maria     | 85999999905 | 60822002 |
	| Pedro     | 85998989865 | 60822003 |

@DeleteClients
Scenario: DeleteClients
	Given 
	When 
	Then 

Examples:

	| RegistrationNumber |
	| 86487197041        |
	| 71038696003        |
	| 12815644002        |