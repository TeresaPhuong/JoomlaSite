Feature: ArticleFeature
	

Scenario: User can add new article
	Given I navigate to Joomlasite
	And I login with valid username and password
	When I click Articles button
	When I click New button
	When I enter title into title text box
	And I enter content into content textbox
	And I click Save and Close button
	Then Added Article Success Message display.
	And New Article is displayed in Articles Manager table
