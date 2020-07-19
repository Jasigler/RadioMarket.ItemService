CREATE TABLE condition_codes (
    condition_id SERIAL PRIMARY KEY,
    condition_name varchar(20),
    CONSTRAINT "PK_ConditionCode" PRIMARY KEY (condition_id)
)

INSERT INTO condition_codes (condition_name)
VALUES ('New'),('Excellent'),('Good'),('Acceptable'),('Not_Working'),('Refurbished_By_User')