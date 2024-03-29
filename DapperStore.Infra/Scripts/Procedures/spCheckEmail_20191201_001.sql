CREATE OR REPLACE PROCEDURE spCheckEmail (
	p_Email VARCHAR2), cur OUT SYS_REFCURSOR
AS
BEGIN
	OPEN cur FOR SELECT CASE WHEN EXISTS (
		SELECT Id
		FROM Customer
		WHERE Email = p_Email
	)
	THEN CAST(1 AS NUMBER(1))
	ELSE CAST(0 AS NUMBER(1)) END FROM dual;
END;