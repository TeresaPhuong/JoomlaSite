Feature: ArticleFeature
	

Scenario: Login successfully
	Given I navigate to http://192.168.189.119/abyssal/administrator/
	When I enter username phuong.thi.tran
	And I enter password 123456
	And I click Login button
