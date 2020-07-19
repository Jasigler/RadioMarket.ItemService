CREATE TABLE "Items" (
 	item_id BIGSERIAL,
	item_owner int NOT NULL,
	category int NOT NULL,
	title varchar(50) NOT NULL,
	description varchar(255) NOT NULL,
	item_condition smallint NOT NULL,
	item_status smallint NOT NULL,
	price varchar(10) NOT NULL,
	CONSTRAINT "PK_ITEM" PRIMARY KEY (item_id)
	)