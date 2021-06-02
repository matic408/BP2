CREATE TRIGGER AutoDeleteTask
ON Tasks
INSTEAD OF DELETE
AS
DECLARE 
	@targetId int
BEGIN
	SELECT @targetId = i.Id FROM deleted i;
	DELETE FROM Assignments WHERE Assignments.TaskId=@targetId;
	DELETE FROM Tasks WHERE Tasks.Id=@targetId;
END
