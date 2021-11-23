Feature: CampaignServiceTests
As a Developer
I want to add new Campaign through API
So that It can be available for applications.

    Background:
        Given the Endpoint https://localhost:5001/api/v1/campaigns is available
        And A Project is already stored
          | Id | Name       | Description                 | PhotoUrl  | ManagerId |
          | 1  | Los Olivos | A beautiful place to invest | image.png | 1         |

    @campaign-adding
    Scenario: Add Campaign
        When A Post Campaign Request is sent
          | Name                         | MinAmount | MaxAmount | ProjectId |
          | Invest in this great project | 200       | 1000      | 1         |
        Then A Response with Status 200 is received
        And A Campaign Resource is included in Response
          | Name                         | MinAmount | MaxAmount | ProjectId |
          | Invest in this great project | 200       | 1000      | 1         |

    Scenario: Add Campaign with Invalid Project
        When A Post Campaign Request is sent
          | Name                         | MinAmount | MaxAmount | ProjectId |
          | Invest in this great project | 200       | 1000      | -10       |
        Then A Response with Status 400 is received
        And A Message of "Invalid Project." is included in Response Body