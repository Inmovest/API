Feature: ProjectServiceTests
As a Developer
I want to add new Project through API
So that It can be available for applications.

    Background:
        Given the Endpoint https://localhost:5001/api/v1/projects is available
        And A Manager is already stored
          | Id | Name |
          | 1  | Jose |

    @project-adding
    Scenario: Add Project
        When A Post Request is sent
          | Name       | Description                 | PhotoUrl  | ManagerId |
          | Los Olivos | A beautiful place to invest | image.png | 1         |
        Then A Response with Status 200 is received
        And A Project Resource is included in Response
          | Name       | Description                 | PhotoUrl  | ManagerId |
          | Los Olivos | A beautiful place to invest | image.png | 1         |

    Scenario: Add Project with Invalid Manager
        When A Post Request is sent
          | Name         | Description             | PhotoUrl  | ManagerId |
          | Los Manzanos | A great place to invest | image.png | -5        |
        Then A Response with Status 400 is received
        And A Message of "Invalid Manager." is included in Response Body