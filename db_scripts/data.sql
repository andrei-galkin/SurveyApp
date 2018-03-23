TRUNCATE TABLE SurveyQuestions
GO

INSERT INTO dbo.SurveyQuestions ([text], question_type) SELECT 'How likely is it that you would recommend this company to a friend or colleague?', 4
INSERT INTO dbo.SurveyQuestions ([text], question_type) SELECT 'Overall, how satisfied or dissatisfied are you with our company?', 1
INSERT INTO dbo.SurveyQuestions ([text], question_type) SELECT 'Which of the following words would you use to describe our products?', 2
INSERT INTO dbo.SurveyQuestions ([text], question_type) SELECT 'How well do our products meet your needs?', 1
INSERT INTO dbo.SurveyQuestions ([text], question_type) SELECT 'How would you rate the quality of the product?', 1
INSERT INTO dbo.SurveyQuestions ([text], question_type) SELECT 'How would you rate the value for money of the product?', 1
INSERT INTO dbo.SurveyQuestions ([text], question_type) SELECT 'How responsive have we been to your questions or concerns about our products?', 1
INSERT INTO dbo.SurveyQuestions ([text], question_type) SELECT 'How long have you been a customer of our company?', 1
INSERT INTO dbo.SurveyQuestions ([text], question_type) SELECT 'How likely are you to purchase any of our products again?', 1
INSERT INTO dbo.SurveyQuestions ([text], question_type) SELECT 'Do you have any other comments, questions, or concerns?', 3

TRUNCATE TABLE SurveyQuestionsInfo
GO

INSERT INTO SurveyQuestionsInfo (question_id, data) SELECT 1, '0'
INSERT INTO SurveyQuestionsInfo (question_id, data) SELECT 1, '1'
INSERT INTO SurveyQuestionsInfo (question_id, data) SELECT 1, '2'
INSERT INTO SurveyQuestionsInfo (question_id, data) SELECT 1, '3'
INSERT INTO SurveyQuestionsInfo (question_id, data) SELECT 1, '4'
INSERT INTO SurveyQuestionsInfo (question_id, data) SELECT 1, '5'
INSERT INTO SurveyQuestionsInfo (question_id, data) SELECT 1, '6'
INSERT INTO SurveyQuestionsInfo (question_id, data) SELECT 1, '7'
INSERT INTO SurveyQuestionsInfo (question_id, data) SELECT 1, '8'
INSERT INTO SurveyQuestionsInfo (question_id, data) SELECT 1, '9'
INSERT INTO SurveyQuestionsInfo (question_id, data) SELECT 1, '10'
INSERT INTO SurveyQuestionsInfo (question_id, data) SELECT 2, 'Very satisfied'
INSERT INTO SurveyQuestionsInfo (question_id, data) SELECT 2, 'Somewhat satisfied'
INSERT INTO SurveyQuestionsInfo (question_id, data) SELECT 2, 'Neither satisfied nor dissatisfied'
INSERT INTO SurveyQuestionsInfo (question_id, data) SELECT 2, 'Somewhat dissatisfied'
INSERT INTO SurveyQuestionsInfo (question_id, data) SELECT 2, 'Very dissatisfied'
INSERT INTO SurveyQuestionsInfo (question_id, data) SELECT 3, 'Reliable'
INSERT INTO SurveyQuestionsInfo (question_id, data) SELECT 3, 'High quality'
INSERT INTO SurveyQuestionsInfo (question_id, data) SELECT 3, 'Useful'
INSERT INTO SurveyQuestionsInfo (question_id, data) SELECT 3, 'Unique'
INSERT INTO SurveyQuestionsInfo (question_id, data) SELECT 3, 'Good value for money'
INSERT INTO SurveyQuestionsInfo (question_id, data) SELECT 3, 'Overpriced'
INSERT INTO SurveyQuestionsInfo (question_id, data) SELECT 3, 'Impractical'
INSERT INTO SurveyQuestionsInfo (question_id, data) SELECT 3, 'Ineffective'
INSERT INTO SurveyQuestionsInfo (question_id, data) SELECT 3, 'Poor quality'
INSERT INTO SurveyQuestionsInfo (question_id, data) SELECT 3, 'Unreliable'
INSERT INTO SurveyQuestionsInfo (question_id, data) SELECT 4, 'Extremely well'
INSERT INTO SurveyQuestionsInfo (question_id, data) SELECT 4, 'Very well'
INSERT INTO SurveyQuestionsInfo (question_id, data) SELECT 4, 'Somewhat well'
INSERT INTO SurveyQuestionsInfo (question_id, data) SELECT 4, 'Not so well'
INSERT INTO SurveyQuestionsInfo (question_id, data) SELECT 4, 'Not at all well'
INSERT INTO SurveyQuestionsInfo (question_id, data) SELECT 5, 'Very high quality'
INSERT INTO SurveyQuestionsInfo (question_id, data) SELECT 5, 'High quality'
INSERT INTO SurveyQuestionsInfo (question_id, data) SELECT 5, 'Neither high nor low quality'
INSERT INTO SurveyQuestionsInfo (question_id, data) SELECT 5, 'Low quality'
INSERT INTO SurveyQuestionsInfo (question_id, data) SELECT 5, 'Very low quality'
INSERT INTO SurveyQuestionsInfo (question_id, data) SELECT 6, 'Excellent'
INSERT INTO SurveyQuestionsInfo (question_id, data) SELECT 6, 'Above average'
INSERT INTO SurveyQuestionsInfo (question_id, data) SELECT 6, 'Average'
INSERT INTO SurveyQuestionsInfo (question_id, data) SELECT 6, 'Below average'
INSERT INTO SurveyQuestionsInfo (question_id, data) SELECT 6, 'Poor'
INSERT INTO SurveyQuestionsInfo (question_id, data) SELECT 7, 'Extremely responsive'
INSERT INTO SurveyQuestionsInfo (question_id, data) SELECT 7, 'Very responsive'
INSERT INTO SurveyQuestionsInfo (question_id, data) SELECT 7, 'Somewhat responsive'
INSERT INTO SurveyQuestionsInfo (question_id, data) SELECT 7, 'Not so responsive'
INSERT INTO SurveyQuestionsInfo (question_id, data) SELECT 7, 'Not at all responsive'
INSERT INTO SurveyQuestionsInfo (question_id, data) SELECT 7, 'Not applicable'
INSERT INTO SurveyQuestionsInfo (question_id, data) SELECT 8, 'This is my first purchase'
INSERT INTO SurveyQuestionsInfo (question_id, data) SELECT 8, 'Less than six months'
INSERT INTO SurveyQuestionsInfo (question_id, data) SELECT 8, 'Six months to a year'
INSERT INTO SurveyQuestionsInfo (question_id, data) SELECT 8, '1 - 2 years'
INSERT INTO SurveyQuestionsInfo (question_id, data) SELECT 8, '3 or more years'
INSERT INTO SurveyQuestionsInfo (question_id, data) SELECT 8, 'I haven''t made a purchase yet'
INSERT INTO SurveyQuestionsInfo (question_id, data) SELECT 9, 'Extremely likely'
INSERT INTO SurveyQuestionsInfo (question_id, data) SELECT 9, 'Very likely'
INSERT INTO SurveyQuestionsInfo (question_id, data) SELECT 9, 'Somewhat likely'
INSERT INTO SurveyQuestionsInfo (question_id, data) SELECT 9, 'Not so likely'
INSERT INTO SurveyQuestionsInfo (question_id, data) SELECT 9, 'Not at all likely'
INSERT INTO SurveyQuestionsInfo (question_id, data) SELECT 10, ''