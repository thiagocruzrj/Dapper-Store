CREATE OR REPLACE PROCEDURE spCreateAddress (
    p_Id CHAR(36),
	p_CustomerId CHAR(36),
	p_Number VARCHAR2,
	p_Complement VARCHAR2,
	p_District VARCHAR2,
	p_City VARCHAR2,
	p_State CHAR,
	p_Country CHAR,
	p_ZipCode CHAR,
	p_Type NUMBER)
AS
BEGIN
    INSERT INTO Address (
        Id,
        CustomerId,
        Number,
        Complement,
        District,
        City,
        State,
        Country,
        ZipCode,
        Type
    ) VALUES (
        p_Id,
        p_CustomerId,
        p_Number,
        p_Complement,
        p_District,
        p_City,
        p_State,
        p_Country,
        p_ZipCode,
        p_Type
    );
END;