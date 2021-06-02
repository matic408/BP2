CREATE PROCEDURE TeamsOnProject

AS
	DECLARE useless CURSOR
	FOR SELECT Id FROM Projects
	DECLARE
		@i int ,
		@toPrint int
	BEGIN
		OPEN useless;
		WHILE @@FETCH_STATUS = 0
			BEGIN	
				SELECT @toPrint = COUNT(DISTINCT Assignments.TeamId) FROM Assignments, Tasks WHERE Assignments.TaskId=Tasks.Id AND Tasks.ProjectId=@i;
				FETCH NEXT FROM useless INTO @i;
				PRINT @toPrint;
			END
		CLOSE useless;
		DEALLOCATE useless;
	END