CREATE EXTENSION IF NOT EXISTS "uuid-ossp";

CREATE TABLE "Items" (
 	item_id uuid DEFAULT uuid_generate_v4 (),
	item_owner int NOT NULL,
	category int NOT NULL,
	title varchar(50) NOT NULL,
	description varchar(255) NOT NULL,
	item_condition smallint NOT NULL,
	item_status smallint NOT NULL,
	price money NOT NULL,
	CONSTRAINT "PK_ITEM" PRIMARY KEY (item_id)
	)