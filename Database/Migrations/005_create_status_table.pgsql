CREATE TABLE status_codes (
    status_id SERIAL,
    status_name varchar(20)
    CONSTRAINT "PK_StatusCode" PRIMARY KEY (status_id)
)

INSERT INTO status_codes (status_name)
VALUES ('Active'), ('On Hold'), ('Pending'), ('Sold')