CREATE FUNCTION [dbo].[CountProjectsForTeam]
(
	@TeamId int
)
RETURNS INT
AS
BEGIN
	DECLARE @retval int;
	SELECT @retval = COUNT(DISTINCT Projects.Id) FROM Tasks,Assignments,Projects WHERE Assignments.TeamId=@TeamId AND Assignments.TaskId=Tasks.Id AND Tasks.ProjectId=Projects.Id;
	RETURN @retval;
END
